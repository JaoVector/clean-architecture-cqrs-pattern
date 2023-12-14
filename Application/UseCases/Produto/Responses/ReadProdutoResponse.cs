using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Application.UseCases.Produto.Responses
{
    public sealed record ReadProdutoResponse
    {
        public Guid CodProduto { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
    }
}
