using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPI.Models
{
    public class Pet
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }
}
