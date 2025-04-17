using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPI.Models
{
    public enum PetStatus
    {
        available,
        pending,
        sold
    }

    public class Pet
    {
        public long id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
    }
}
