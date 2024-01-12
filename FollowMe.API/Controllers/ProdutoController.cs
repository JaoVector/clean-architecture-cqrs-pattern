using FollowMe.Application.UseCases.Produto.Commands;
using FollowMe.Application.UseCases.Produto.Queries;
using FollowMe.Application.UseCases.Produto.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FollowMe.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public ProdutoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<CreateProdutoResponse>> CriaProduto(CreateProdutoRequest request, CancellationToken cancellation) 
        {
            var response = await _mediator.Send(request, cancellation);

            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<ReadProdutoResponse>>> ConsultaProdutos([FromQuery] ConsultaTodosProdutos request, CancellationToken cancellation) 
        {
            var response = await _mediator.Send(request, cancellation);

            return Ok(response);
        }

        [HttpGet("{CodProduto}")]
        public async Task<ActionResult<ReadProdutoResponse>> ConsultaProduto(Guid? CodProduto, CancellationToken cancellation) 
        {
            if (CodProduto is null) return BadRequest("O Id precisa estar preenchido");

            var request = new ConsultaProdutoPorId(CodProduto.Value);

            var response = await _mediator.Send(request, cancellation);

            return Ok(response);
        }

        [HttpPut("{CodProduto}")]
        public async Task<ActionResult<UpdateProdutoResponse>> AtualizaProduto(Guid? CodProduto, UpdateProdutoRequest request, CancellationToken cancellation) 
        {
            if (CodProduto != request.CodProduto) return BadRequest("Os Ids precisam ser iguais");

            var response = await _mediator.Send(request, cancellation);

            return Ok(response);
        }

        [HttpDelete("{CodProduto}")]
        public async Task<ActionResult<DeleteProdutoResponse>> ExcluiProduto(Guid? CodProduto, CancellationToken cancellation) 
        {

            if (CodProduto is null) return BadRequest("O Id precisa estar preenchido");

            var request = new DeleteProdutoRequest(CodProduto.Value);

            var response = await _mediator.Send(request, cancellation);

            return Ok(response);
        } 
    }
}
