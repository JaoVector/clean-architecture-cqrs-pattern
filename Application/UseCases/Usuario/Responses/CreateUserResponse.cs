using FollowMe.Application.UseCases.Endereco.Responses;
using FollowMe.Application.UseCases.Produto.Responses;
using FollowMe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Application.UseCases.Usuario.Responses
{
    public sealed record CreateUserResponse
    {
        public Guid UsuarioId { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public ReadEnderecoResponse? Endereco { get; set; }
    }
}
