using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategory.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter your email")]
        [RegularExpression("[a-z0-9.]+@[a-z]+\\.[a-z]{2,3}", ErrorMessage = "please enter a valid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your password")]
        public string PassWord { get; set; }
        public bool RememberMe { get; set; }
    }
}
