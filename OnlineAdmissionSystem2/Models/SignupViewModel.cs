using System.ComponentModel.DataAnnotations;

namespace OnlineAdmissionSystem2.Models
{
    public class SignupViewModel
    {
        [Required(ErrorMessage = "You must enter a name")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(10)]
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public IFormFile PhotoFile { get; set; }

    }
}
