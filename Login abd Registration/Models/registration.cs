using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Login_abd_Registration.Models
{
    public class registration
    {
        [Key]
        public int LoginId { get; set; }

        [Required(ErrorMessage ="First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="LastName is Reuired")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Email is Require")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3]\.)|(([\w-]+\.)+))([a-zA-Z{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter valid email.")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage ="Password")]
        [DataType(DataType.Password)]
        public string ConfirmPasword { get; set; }
    }
}