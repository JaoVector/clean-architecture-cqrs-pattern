using FollowMe.Application.UseCases.Endereco.Commands;
using FollowMe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Application.Shared.Extensions
{
    public static class EnderecoExtensions
    {
        public static void AtualizaEndereco(this Endereco endereco, UpdateEnderecoRequest request) 
        {
            endereco.Cep = request.Cep;
            endereco.Rua = request.Rua;
            endereco.Bairro = request.Bairro;
            endereco.Numero = request.Numero;
            endereco.UsuarioId = request.UsuarioId;
        }
    }
}
