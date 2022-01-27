using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRMDesktopUI.Library.Models
{
    public class CreateUserModel
    {
        [Required]
        [DisplayName("FirstName")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("last naem")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [DisplayName("email")]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [DisplayName("confim pass")]
        [Compare(nameof(Password), ErrorMessage ="The password do not match")]
        public string ConfirmPassword { get; set; }
    }
}
