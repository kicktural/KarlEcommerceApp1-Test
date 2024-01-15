using System.ComponentModel.DataAnnotations;

namespace WebUI.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare("Password")]
        public string PasswordConfirmation { get; set; }
        public string? Address { get; set; }
    }
}
