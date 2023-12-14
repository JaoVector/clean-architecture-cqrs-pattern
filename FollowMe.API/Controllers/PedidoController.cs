using FollowMe.Application.UseCases.Pedido.Commands;
using FollowMe.Application.UseCases.Pedido.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FollowMe.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PedidoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<CreatePedidoResponse>> CriaPedido(CreatePedidoRequest request, CancellationToken cancellation) 
        {
            var response = await _mediator.Send(request, cancellation);

            return Ok(response);
        }

        [HttpPost(nameof(AtualizaStatusPedido))]
        public async Task<ActionResult<UpdateStatusPedidoResponse>> AtualizaStatusPedido(UpdateStatusPedidoRequest request, CancellationToken cancellation) 
        {
            var response = await _mediator.Send(request, cancellation);

            return Ok(response);
        }
    }
}
