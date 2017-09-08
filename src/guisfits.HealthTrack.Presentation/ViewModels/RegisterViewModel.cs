using System.ComponentModel.DataAnnotations;

namespace guisfits.HealthTrack.Presentation.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "O campo E-mail é requerido")]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo senha é requerido")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Required(ErrorMessage = "A confirmação da senha é requerida")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmação")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
