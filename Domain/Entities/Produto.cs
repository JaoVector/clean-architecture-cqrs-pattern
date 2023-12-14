using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
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
        [Required]
        public int Quantidade { get; set; }
        public Guid UsuarioId { get; set; }
        public virtual Usuario? Usuario { get; set; }
    }
}
