using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace In_Client.auth
{
    public class JWTJson
    {
        public int code { get; set; }
        public string token { get; set; }
        public DateTime expire { get; set; }   
    }
}
