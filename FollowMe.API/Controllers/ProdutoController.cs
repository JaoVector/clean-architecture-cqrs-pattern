using FollowMe.Application.UseCases.Produto.Commands;
using FollowMe.Application.UseCases.Produto.Queries;
using FollowMe.Application.UseCases.Produto.Responses;
using FollowMe.Persistence.Messaging;
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
    }
}
