using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Application.UseCases.ItemCarrinho.Responses
{
    public sealed record AddItemCarrinhoResponse
    {
        public Guid ItemCarrinhoId { get; set; }
        public Guid CarrinhoId { get; set; }
        public Guid CodProduto { get; set; }
        public int Quantidade { get; set; }

    }
}
