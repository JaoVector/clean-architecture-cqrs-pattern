using FollowMe.Application.UseCases.Endereco.Commands;
using FollowMe.Application.UseCases.Usuario.Responses;
using FollowMe.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Application.UseCases.Usuario.Commands
{
    public sealed record CreateUserRequest(string Nome, string Email) : IRequest<CreateUserResponse>;
}
