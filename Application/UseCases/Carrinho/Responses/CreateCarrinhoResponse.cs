using FollowMe.Application.UseCases.Produto.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Application.UseCases.Carrinho.Responses
{
    public sealed record CreateCarrinhoResponse
    {
        public Guid UsuarioId { get; set; }
        public Guid CarrinhoId { get; set; }
    }
}
