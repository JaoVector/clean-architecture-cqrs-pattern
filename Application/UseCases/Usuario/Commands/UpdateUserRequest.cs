using FollowMe.Application.UseCases.Endereco.Commands;
using FollowMe.Application.UseCases.Usuario.Responses;
using FollowMe.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Application.UseCases.Usuario.Requests
{
    public sealed record UpdateUserRequest : IRequest<CreateUserResponse>
    {
        public Guid UsuarioId { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public CreateEnderecoRequest? Endereco { get; set; }
    } 
}
