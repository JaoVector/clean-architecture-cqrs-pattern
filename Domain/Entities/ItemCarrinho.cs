using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FollowMe.Domain.Entities
{
    public class ItemCarrinho : BaseEntity
    {
       
        [Key]
        public Guid ItemCarrinhoId { get; set; }

        public Guid CarrinhoId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public Carrinho? Carrinho { get; set; }

        public Guid CodProduto { get; set; }
        public Produto Produto { get; set; }

        public int Quantidade { get; set; }
    }
}
