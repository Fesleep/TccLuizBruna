using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Nome { get; set; }

        [NotMapped]
        public string Role { get; set; }

    }
}
