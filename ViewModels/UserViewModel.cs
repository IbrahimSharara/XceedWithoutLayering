using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategory.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [MinLength(5, ErrorMessage = "Please enter Valid name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression("(010|012|011|015)[0-9]{8}", ErrorMessage = "Please enter Valid Phone")]
        public string Phone { get; set; }
        [Required]
        [RegularExpression("[a-z0-9.]+@[a-z]+\\.[a-z]{2,3}", ErrorMessage = "please enter a valid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your password")]
        [MinLength(6 , ErrorMessage ="Please enter valid password")]
        public string PassWord { get; set; }
        [Required(ErrorMessage = "Please enter your password")]
        [Compare("PassWord", ErrorMessage = "Password And Confirm Password are not the same")]
        [MinLength(6)]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Address { get; set; }

        public bool RememberMe { get; set; }
    }
}
