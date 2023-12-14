﻿using FollowMe.Application.UseCases.Endereco.Responses;
using FollowMe.Application.UseCases.Produto.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Application.UseCases.Usuario.Responses
{
    public sealed record ReadUserResponse
    {
        public Guid UsuarioId { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public ReadEnderecoResponse? Endereco { get; set; }
        public ICollection<ReadProdutoResponse>? Produtos { get; set; }
    }
}
