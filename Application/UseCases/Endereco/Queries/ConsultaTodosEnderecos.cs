using FollowMe.Application.UseCases.Endereco.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Application.UseCases.Endereco.Queries
{
    public sealed record ConsultaTodosEnderecos(int skip, int take) : IRequest<List<ReadEnderecoResponse>>;
}
