using FollowMe.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Domain.Entities
{
    public class Pedido : BaseEntity
    {
        [Key]
        public Guid CodPedido { get; set; }
        [Required]
        public string? CodRastreio { get; set; }
        public StatusPedido Status { get; set; } = StatusPedido.Feito;

        public Guid UsuarioId { get; set; }
        public virtual Usuario? Usuario { get; set; }
    }
}
