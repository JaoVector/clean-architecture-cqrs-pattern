using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Application.UseCases.ItemCarrinho.Responses
{
    public sealed record DeleteItemCarrinhoResponse
    {
        public Guid ItemCarrinhoId { get; set; }
    }
}
