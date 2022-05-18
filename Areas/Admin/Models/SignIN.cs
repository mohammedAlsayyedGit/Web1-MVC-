using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Areas.Admin.Models
{
    public class SignIN
    {
        
        [Required(ErrorMessage ="Please Enter the Username")]
        public  string Username { get; set; }
        [Required(ErrorMessage = "Please Enter the password")]
        public string Password { get; set; }

    }
}
