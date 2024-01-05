using FollowMe.Application.UseCases.ItemCarrinho.Responses;
using FollowMe.Application.UseCases.Produto.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FollowMe.Application.UseCases.Carrinho.Responses
{
    public sealed record ReadCarrinhoResponse
    {
        public Guid CarrinhoId { get; set; }
        public ICollection<ReadItemCarrinhoResponse>? Itens { get; set; }
    }
}
