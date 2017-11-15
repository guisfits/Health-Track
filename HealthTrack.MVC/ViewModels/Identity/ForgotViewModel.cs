using System.ComponentModel.DataAnnotations;

namespace HealthTrack.MVC.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}