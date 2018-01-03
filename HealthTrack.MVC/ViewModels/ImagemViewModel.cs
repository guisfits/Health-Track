using System.Web;

namespace HealthTrack.MVC.ViewModels
{
    public class ImagemViewModel
    {
        public string ImagemPath { get; set; }
        public HttpPostedFileBase File { get; set; }
    }
}