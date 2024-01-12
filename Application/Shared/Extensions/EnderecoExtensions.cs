using FollowMe.Application.UseCases.Endereco.Commands;
using FollowMe.Domain.Entities;

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
