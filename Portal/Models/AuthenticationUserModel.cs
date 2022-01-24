using System.ComponentModel.DataAnnotations;

namespace Portal.Models
{
    public class AuthenticationUserModel
    {
        [Required(ErrorMessage = "email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage ="passwrod is required.")]
        public string Password { get; set; }
    }
}
