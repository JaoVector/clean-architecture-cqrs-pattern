using FollowMe.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Usuario? Usuario { get; set; }

        public Guid EnderecoId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Endereco? Endereco { get; set; }

        public virtual ICollection<ItemPedido> ItensPedido { get; set; }
    }
}
