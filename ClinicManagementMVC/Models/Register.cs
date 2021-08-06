using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementMVC.Models
{
    public class Register
    {
        [Key]
        [Required(ErrorMessage = "Enter Username")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "special characters are not allowed.")]
        [Display(Name ="User Name")]
        public string Username { get; set; }
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
