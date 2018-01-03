using System.ComponentModel.DataAnnotations;

namespace HealthTrack.MVC.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "A senha deve ter pelo menos {2} caracteres", MinimumLength = 6)]
        [DataType(DataType.Password, ErrorMessage = "O campo n�o corresponde a uma senha")]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirma��o")]
        [Compare("Password", ErrorMessage = "A senha e sua confirma��o n�o correspondem")]
        public string ConfirmPassword { get; set; }
    }
}