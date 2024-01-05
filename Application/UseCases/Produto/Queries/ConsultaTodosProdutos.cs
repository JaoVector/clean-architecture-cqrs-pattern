using FollowMe.Application.UseCases.Produto.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Application.UseCases.Produto.Queries
{
    public sealed record ConsultaTodosProdutos(int skip, int take) : IRequest<List<ReadProdutoResponse>>;
}
