using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FollowMe.Application.Shared.Exceptions.Middleware
{
    public class ExceptionMiddleware : IMiddleware
    {

        private readonly ILogger _logger;

        public ExceptionMiddleware(ILogger logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {

                _logger.LogError($"Ocorreu um Erro {ex}");
                await HandlerException(context, ex);
            }
        }

        private static Task HandlerException(HttpContext context, Exception ex)
        {
            int statusCode = StatusCodes.Status500InternalServerError;

            statusCode = ex switch
            {
                NotFoundExceptions _ => StatusCodes.Status404NotFound,
                BadRequestException _ => StatusCodes.Status400BadRequest,
                ErroNoBanco _ => StatusCodes.Status503ServiceUnavailable,
                ErroAoConsultarCarrinho _ => StatusCodes.Status400BadRequest,
                ErroSistemico _ => StatusCodes.Status500InternalServerError,
                _ => StatusCodes.Status500InternalServerError
            };

            var errorResp = new ErrorsMap
            {
                StatusCode = statusCode,
                ErrorMessage = ex.Message
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            return context.Response.WriteAsync(errorResp.ToString());
        }
    }
}
