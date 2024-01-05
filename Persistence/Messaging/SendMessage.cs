using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Persistence.Messaging
{
    public class SendMessage
    {
        public string? RoutingKey { get; set; }
        public string? Payload { get; set; }
    }
}
