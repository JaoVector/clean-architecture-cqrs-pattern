using FollowMe.Application.Shared.Exceptions;
using FollowMe.Application.UseCases.Endereco.Responses;
using FollowMe.Application.UseCases.Pedido.Queries;
using FollowMe.Application.UseCases.Pedido.Responses;
using FollowMe.Application.UseCases.Produto.Responses;
using FollowMe.Application.UseCases.Usuario.Responses;
using FollowMe.Domain.Interfaces;
using MediatR;

namespace FollowMe.Application.UseCases.Pedido.QueryHandlers
{
    public class ConsultaPedidoPorIdHandler : IRequestHandler<ConsultaPedidoPorId, ReadPedidoResponse>
    {
        private readonly IPedidoRepository _pedidoRepo;

        public ConsultaPedidoPorIdHandler(IPedidoRepository pedidoRepo)
        {
            _pedidoRepo = pedidoRepo;
        }

        public async Task<ReadPedidoResponse> Handle(ConsultaPedidoPorId request, CancellationToken cancellationToken)
        {
            var pedido = await _pedidoRepo.ConsultaPedidoPorId(request.PedidoId, cancellationToken);

            if (pedido is null) throw new PedidoNotFound($"Pedido de Id {request.PedidoId} não Encontrado");

            return new ReadPedidoResponse 
            {
                CodPedido = pedido.CodPedido,
                CodRastreio = pedido.CodRastreio,
                Status = pedido.Status,
                Usuario = new ReadUserPedidoResponse 
                {
                    UsuarioId = pedido.Usuario.UsuarioId,
                    Email = pedido.Usuario?.Email,
                    Nome = pedido.Usuario?.Nome
                },

                Endereco = new ReadEnderecoResponse 
                {
                    EnderecoId= pedido.Endereco.EnderecoId,
                    Cep = pedido.Endereco?.Cep,
                    Rua = pedido.Endereco?.Rua,
                    Numero = pedido.Endereco?.Numero,
                    Bairro = pedido.Endereco?.Bairro
                },

                ItensPedido = (from item in pedido.ItensPedido select new ItemPedidoResponse 
                {
                    ItemPedidoId = item.ItemPedidoId,
                    Produto = new ReadProdutoResponse 
                    {
                        CodProduto = item.Produto.CodProduto,
                        Nome = item.Produto?.Nome,
                        Descricao = item.Produto?.Descricao,
                        Preco = item.Produto.Preco
                    },

                    Quantidade = item.Quantidade,

                }).ToList(),

            };
        }
    }
}
