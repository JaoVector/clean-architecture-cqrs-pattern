using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FollowMe.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusPedido
    {
        Feito,
        Enviado,
        SaiuParaEntrega,
        Entregue,
        Concluido,
        Excluido
    }
}
