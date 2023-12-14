using FollowMe.Application.UseCases.Endereco.Commands;
using FollowMe.Application.UseCases.Endereco.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FollowMe.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EnderecoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<CreateEnderecoResponse>> CriaEndereco(CreateEnderecoRequest request, CancellationToken cancellation) 
        {
            var resp = await _mediator.Send(request, cancellation);

            return Ok(resp);
        }
    }
}
