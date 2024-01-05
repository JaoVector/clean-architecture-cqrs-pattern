using FollowMe.Application.UseCases.Carrinho.Commands;
using FollowMe.Application.UseCases.Carrinho.Queries;
using FollowMe.Application.UseCases.Carrinho.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FollowMe.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CarrinhoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarrinhoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<CreateCarrinhoResponse>> CriaCarrinho(CreateCarrinhoRequest request, CancellationToken cancellation) 
        {
            var response = await _mediator.Send(request, cancellation);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadCarrinhoResponse>> ConsultaProdutosCarrinho(Guid? id, CancellationToken cancellation) 
        {
            if (id is null) return BadRequest("Id não pode ser Nulo");

            var request = new ConsultaCarrinho(id.Value);

            var response = await _mediator.Send(request, cancellation);

            return Ok(response);
        }
       
    }
}
