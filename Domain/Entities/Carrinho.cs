using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace FollowMe.Domain.Entities
{
    public class Carrinho : BaseEntity
    {
        
        [Key]
        public Guid CarrinhoId { get; set; }
        
        public Guid UsuarioId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Usuario? Usuario { get; set; }

        public virtual ICollection<ItemCarrinho> Items { get; set; }

    }
}

