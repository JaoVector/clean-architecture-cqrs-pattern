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
    public class ItemPedido
    {
        [Key]
        public Guid ItemPedidoId { get; set; }

        public Guid PedidoId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public Pedido? Pedido { get; set;}

        public Guid CodProduto { get; set; }
        public Produto Produto { get; set; }

        public int Quantidade { get; set; }
    }
}
