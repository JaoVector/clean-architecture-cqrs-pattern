using FollowMe.Application.UseCases.Endereco.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Application.UseCases.Endereco.Commands
{
    public sealed record CreateEnderecoRequest : IRequest<CreateEnderecoResponse>
    {
        public string? Cep { get; set; }
        public string? Rua { get; set; }
        public string? Bairro { get; set; }
        public int Numero { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
