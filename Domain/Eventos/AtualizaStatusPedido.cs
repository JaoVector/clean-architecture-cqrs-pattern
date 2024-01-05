using FollowMe.Domain.Entities;
using FollowMe.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Domain.Eventos
{
    public sealed record AtualizaStatusPedido 
    {
        public string? CodRastreio { get; set; }
        public StatusPedido Status { get; set; }
        public object? Usuario { get; set; }
    };
}
