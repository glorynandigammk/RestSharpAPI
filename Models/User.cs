using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPI.Models
{
    public class User
    {
        public long Id { get; set; }

        [MinLength(1)]
        [MaxLength(60)]
        public string Username { get; set; }

        [MinLength(1)]
        [MaxLength(60)]
        public string FirstName { get; set; }

        [MinLength(1)]
        [MaxLength(60)]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public int UserStatus { get; set; }
    }
}
    