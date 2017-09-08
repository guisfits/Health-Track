using System.ComponentModel.DataAnnotations;

namespace guisfits.HealthTrack.Presentation.ViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
