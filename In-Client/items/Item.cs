using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace In_Client.items
{
    public class Item
    {
        public int? ID { get; set; }
        public string? name { get; set; }
        public string? productName { get; set; }
        public string? serialNumber { get; set; }
        public auth.User? owner { get; set; }
    }
}
