using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPI.Models
{
    public class Order
    {
        public long id { get; set; }
        public long petId { get; set; }
        public int quantity { get; set; }
        public DateTime shipDate { get; set; }
        public string status { get; set; }
        public bool complete { get; set; }
    }
}
