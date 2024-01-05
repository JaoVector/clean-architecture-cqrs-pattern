using FollowMe.Application.UseCases.Endereco.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Application.UseCases.Endereco.Commands
{
    public sealed record DeleteEnderecoRequest(Guid EnderecoId) : IRequest<ReadEnderecoResponse>;
}
