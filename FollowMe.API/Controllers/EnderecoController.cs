using FollowMe.Application.UseCases.Endereco.Commands;
using FollowMe.Application.UseCases.Endereco.Queries;
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

        [HttpGet("{EnderecoId}")]
        public async Task<ActionResult<ReadEnderecoResponse>> ConsultaEnderecoPorId(Guid? EnderecoId, CancellationToken cancellation) 
        {
            if (EnderecoId is null) return BadRequest("O Id do Endereco não pode ser nulo");

            var enderocoId = new ConsultaEnderecoPorId(EnderecoId.Value);

            var response = await _mediator.Send(enderocoId, cancellation);

            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<ReadEnderecoResponse>>> ConsultaEnderecos([FromQuery] ConsultaTodosEnderecos request, CancellationToken cancellation) 
        {
            var response = await _mediator.Send(request, cancellation);

            return Ok(response);
        }

        [HttpPut("{EnderecoId}")]
        public async Task<ActionResult<UpdateEnderecoResponse>> AtualizaEndereco(Guid? EnderecoId, UpdateEnderecoRequest request, CancellationToken cancellation) 
        {
            if (EnderecoId != request.EnderecoId) return BadRequest("Os Ids precisam ser iguais");

            var response = await _mediator.Send(request, cancellation);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ReadEnderecoResponse>> DeletaEndereco([FromQuery] DeleteEnderecoRequest request, CancellationToken cancellation) 
        {
            var response = await _mediator.Send(request, cancellation);

            return Ok(response);
        }
    }
}
