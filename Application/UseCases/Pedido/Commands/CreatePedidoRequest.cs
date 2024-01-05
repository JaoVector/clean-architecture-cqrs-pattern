using FollowMe.Application.UseCases.Pedido.Responses;
using FollowMe.Domain.Entities;
using MediatR;

namespace FollowMe.Application.UseCases.Pedido.Commands
{
    public sealed record CreatePedidoRequest : IRequest<CreatePedidoResponse> 
    {
        public Guid UsuarioId { get; set; }

        public Guid EnderecoId { get; set; }
        
        public Guid CarrinhoId { get; set; }
    }
}
