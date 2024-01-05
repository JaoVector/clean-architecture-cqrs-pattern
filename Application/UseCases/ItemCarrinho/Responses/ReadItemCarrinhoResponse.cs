using FollowMe.Application.UseCases.Produto.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FollowMe.Application.UseCases.ItemCarrinho.Responses
{
    public sealed record ReadItemCarrinhoResponse
    {
        public Guid ItemCarrinhoId { get; set; }
        public ReadProdutoResponse? Produto { get; set; }
    }
}
