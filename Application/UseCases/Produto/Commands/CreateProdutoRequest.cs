using FollowMe.Application.UseCases.Produto.Responses;
using FollowMe.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Application.UseCases.Produto.Commands
{
    public sealed record CreateProdutoRequest : IRequest<ReadProdutoResponse>
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
