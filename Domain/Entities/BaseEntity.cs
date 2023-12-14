using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Domain.Entities
{
    public abstract class BaseEntity
    {
        public DateTimeOffset DataCriacao { get; set; }
        public DateTimeOffset? DataAtualizacao { get; set; }
        public DateTimeOffset? DataExclusao { get; set; }
    }
}
