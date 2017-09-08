using System.ComponentModel.DataAnnotations;

namespace guisfits.HealthTrack.Presentation.ViewModels
{

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
