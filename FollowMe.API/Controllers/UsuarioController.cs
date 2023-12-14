using FollowMe.Application.UseCases.Usuario.Commands;
using FollowMe.Application.UseCases.Usuario.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FollowMe.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<CreateUserResponse>> CriaUsuario(CreateUserRequest request, CancellationToken cancellation) 
        {
            var response = await _mediator.Send(request, cancellation);

            return Ok(response);
        }
    }
}
