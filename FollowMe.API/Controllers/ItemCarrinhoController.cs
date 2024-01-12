using FollowMe.Application.UseCases.ItemCarrinho.Commands;
using FollowMe.Application.UseCases.ItemCarrinho.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FollowMe.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ItemCarrinhoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemCarrinhoController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<ActionResult<AddItemCarrinhoResponse>> AdicionaItemCarrinho(AddItemCarrinhoRequest request, CancellationToken cancellation) 
        {
            var response = await _mediator.Send(request, cancellation);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteItemCarrinhoResponse>> DeletaItemCarrinho(Guid? id, CancellationToken cancellation) 
        {
            if (id is null) return BadRequest("Id Não pode ser Nulo");

            var request = new DeleteItemCarrinhoRequest(id.Value);

            var response = await _mediator.Send(request, cancellation);

            return Ok(response);
        }
       
    }
}