using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FollowMe.Domain.Entities
{
    public class Produto : BaseEntity
    {
        [Key]
        public Guid CodProduto { get; set; }
        [Required]
        [StringLength(100)]
        public string? Nome { get; set; }
        [Required]
        [StringLength(250)]
        public string? Descricao { get; set; }
        [Required]
        public double Preco { get; set; }

    }
}
