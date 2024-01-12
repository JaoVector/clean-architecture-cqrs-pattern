using FollowMe.Application.Eventos;
using FollowMe.Application.Shared.Exceptions;
using FollowMe.Application.UseCases.ItemCarrinho.Responses;
using FollowMe.Application.UseCases.Produto.Responses;
using FollowMe.Domain.Entities;
using MassTransit;

namespace FollowMe.Persistence.Messaging
{
    public static class PublicaMensagensUsuarios
    {
        public static void PublicaUsuario(IBusControl bus, Usuario payload) 
        {
            try
            {
                var usuario = new UsuarioEventos
                {
                    Nome = payload.Nome,
                    Email = payload.Email,
                    Mensagem = "Bem-Vindo(a) ao Nosso Site!!!"
                };

                PublishMethod.Publica(bus, usuario, "usuario");
            }
            catch (Exception ex)
            {

                throw new ErroAoGerarMensagemUsuaurio($"Erro ao Gerar a Mensagem para Publicar Usuario {ex}");
            }
            
        }

        public static void PublicaItemAdicionadoNoCarrinho(IBusControl bus, ItemCarrinho? itemCarrinho, Usuario? usuario) 
        {
            try
            {
                var item = new ItemAdicionadoNoCarrinho()
                {
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    Item = new ReadItemCarrinhoResponse
                    {
                        ItemCarrinhoId = itemCarrinho.ItemCarrinhoId,
                        Produto = new ReadProdutoResponse
                        {
                            CodProduto = itemCarrinho.CodProduto,
                            Nome = itemCarrinho.Produto.Nome,
                            Descricao = itemCarrinho.Produto.Descricao,
                            Preco = itemCarrinho.Produto.Preco
                        }
                    }
                };

                PublishMethod.Publica(bus, item, "usuario");
            }
            catch (Exception ex)
            {

                throw new ErroAoGerarMensagemUsuaurio($"Erro ao Gerar a Mensagem de Item Adicionado no Carrinho {ex}");
            }
            
        }

        public static void UsuarioAtualizado(IBusControl bus, Usuario payload) 
        {
            try
            {
                var usuario = new UsuarioEventos
                {
                    Nome = payload.Nome,
                    Email = payload.Email,
                    Mensagem = "O Usuario Foi Atualizado com Sucesso!!!"
                };

                PublishMethod.Publica(bus, usuario, "usuario");
            }
            catch (Exception ex)
            {

                throw new ErroAoGerarMensagemUsuaurio($"Erro ao Gerar Mensagem de Usuario Atualizado {ex}");
            }
            
        }

        public static void UsuarioExcluido(IBusControl bus, Usuario payload) 
        {
            try
            {
                var usuario = new UsuarioEventos
                {
                    Nome = payload.Nome,
                    Email = payload.Email,
                    Mensagem = "O Usuario Foi Excluido !!!"
                };

                PublishMethod.Publica(bus, usuario, "usuario");
            }
            catch (Exception ex)
            {

                throw new ErroAoGerarMensagemUsuaurio($"Erro ao Gerar Mensagem de Usuario Excluido {ex}");
            }
        }
    }
}
