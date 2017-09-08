using System.ComponentModel.DataAnnotations;

namespace guisfits.HealthTrack.Presentation.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O campo E-mail é requerido")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Senha é requerido")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
