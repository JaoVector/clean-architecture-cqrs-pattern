using System.ComponentModel.DataAnnotations;

namespace FollowMe.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        [Key]
        public Guid UsuarioId { get; set; }
        [Required]
        [StringLength(100)]
        public string? Nome { get; set; }
        [Required]
        [StringLength(100)]
        public string? Email { get; set; }

        public virtual ICollection<Endereco>? Enderecos { get; set; }

        public virtual Carrinho? Carrinho { get; set; }
    }
}
