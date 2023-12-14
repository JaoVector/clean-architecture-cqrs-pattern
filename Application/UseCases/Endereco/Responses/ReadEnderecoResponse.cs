using FollowMe.Application.UseCases.Usuario.Responses;
using FollowMe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Application.UseCases.Endereco.Responses
{
    public sealed record ReadEnderecoResponse
    {
        public Guid EnderecoId { get; set; }
        public string? Cep { get; set; }
        public string? Rua { get; set; }
        public string? Bairro { get; set; }
        public int Numero { get; set; }
    }
}
