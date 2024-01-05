using AutoMapper;
using FollowMe.Application.UseCases.Carrinho.Responses;
using FollowMe.Application.UseCases.Endereco.Responses;
using FollowMe.Application.UseCases.ItemCarrinho.Responses;
using FollowMe.Application.UseCases.Produto.Responses;
using FollowMe.Application.UseCases.Usuario.Queries;
using FollowMe.Application.UseCases.Usuario.Responses;
using FollowMe.Domain.Interfaces;
using MediatR;

namespace Application.UseCases.Usuario.QueryHandlers
{
    public class ConsultaUserPorIdHandler : IRequestHandler<ConsultaUsuarioPorId, ReadUserResponse>
    {

        private readonly IUsuarioRepository _usuarioRepo;
        
        public ConsultaUserPorIdHandler(IUsuarioRepository usuario, IMapper mapper)
        {
            _usuarioRepo = usuario;
            
        }

        public async Task<ReadUserResponse> Handle(ConsultaUsuarioPorId request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepo.ConsultaUsuarioPorId(request.UsuarioId, cancellationToken);
            
            if (usuario is null) return default;

            return new ReadUserResponse
            {
                UsuarioId = usuario.UsuarioId,
                Nome = usuario.Nome,
                Email = usuario.Email,

                Enderecos = (from e in usuario.Enderecos select new ReadEnderecoResponse
                {
                    EnderecoId = e.EnderecoId,
                    Cep = e.Cep,
                    Rua = e.Rua,
                    Bairro = e.Bairro,
                    Numero = e.Numero,

                }).ToList(),

                Carrinho = new ReadCarrinhoResponse 
                {
                    CarrinhoId = usuario.Carrinho.CarrinhoId,
                    Itens = (from i in usuario.Carrinho.Items select new ReadItemCarrinhoResponse 
                    {
                        ItemCarrinhoId = i.ItemCarrinhoId,
                        Produto = new ReadProdutoResponse
                        {
                            CodProduto = i.Produto.CodProduto,
                            Nome = i.Produto?.Nome,
                            Descricao = i.Produto?.Descricao,
                            Preco = i.Produto.Preco
                        }
                    }).ToList(),
                    
                }

            };
        }
    }
}

/*
                Produtos = (from p in usuario.Produtos select new ReadProdutoResponse
                {
                     CodProduto = p.CodProduto,
                     Nome = p.Nome,
                     Descricao = p.Descricao,
                     Preco = p.Preco,
                     Quantidade = p.Quantidade

                }).ToList()
                */