using FollowMe.Application.UseCases.ItemCarrinho.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Application.UseCases.ItemCarrinho.Commands
{
    public sealed record DeleteItemCarrinhoRequest(Guid ItemCarrinhoId) : IRequest<DeleteItemCarrinhoResponse>;
}
