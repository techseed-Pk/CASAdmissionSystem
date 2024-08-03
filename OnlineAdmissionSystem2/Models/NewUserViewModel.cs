using System.ComponentModel.DataAnnotations;

namespace OnlineAdmissionSystem2.Models
{
    public class NewUserViewModel
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[@#\\$%\\^&\\+=!])[A-Za-z\\d@#\\$%\\^&\\+=!]{10,}$", ErrorMessage = "Your password must be 10 characters long with at least one upper case letter, one digit and a special character.")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
