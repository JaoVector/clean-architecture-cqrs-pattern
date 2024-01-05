using FollowMe.Application.UseCases.Usuario.Commands;
using FollowMe.Application.UseCases.Usuario.Queries;
using FollowMe.Application.UseCases.Usuario.Requests;
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

        [HttpGet(nameof(ConsultaUsuarioPorId))]
        public async Task<ActionResult<ReadUserResponse>> ConsultaUsuarioPorId([FromQuery] ConsultaUsuarioPorId request, CancellationToken cancellation)
        {
            var response = await _mediator.Send(request, cancellation);

            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<ReadAllUserResponse>>> ConsultaUsuarios([FromQuery] ConsultaTodosUsuarios request, CancellationToken cancellation) 
        {
            var response = await _mediator.Send(request, cancellation);

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateUserResponse>> AtualizaUsuario(UpdateUserRequest request, CancellationToken cancellation) 
        {
            var response = await _mediator.Send(request, cancellation);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ReadAllUserResponse>> DeletaUsuario([FromQuery] DeleteUserRequest request, CancellationToken cancellation) 
        {
            var response = await _mediator.Send(request, cancellation);

            return Ok(response);
        }
    }
}
