using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPI.Models
{
    public class Pet
    {
        public long Id { get; set; }

        [MinLength(1)]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Status { get; set; }
    }
}
