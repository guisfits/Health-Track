using System.ComponentModel.DataAnnotations;

namespace HealthTrack.MVC.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "A {0} deve ter pelo menos {2} caracteres", MinimumLength = 6)]
        [DataType(DataType.Password, ErrorMessage = "O campo não corresponde a uma senha")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "A senha e sua confirmação não correspondem")]
        public string ConfirmPassword { get; set; }
    }
}