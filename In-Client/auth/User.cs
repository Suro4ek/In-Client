using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace In_Client.auth
{
    public class User
    {
        public int? ID { get; set; }
        public string? name { get; set; }
        public string? familia { get; set; }
        public string? role { get; set; }
        public string? username { get; set; }

        public override string ToString()
        {
            return familia + " " +name;
        }
    }
}
