using FollowMe.Application.UseCases.Carrinho.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Application.UseCases.Carrinho.Queries
{
    public sealed record ConsultaCarrinho(Guid CarrinhoId) : IRequest<ReadCarrinhoResponse>;
}
