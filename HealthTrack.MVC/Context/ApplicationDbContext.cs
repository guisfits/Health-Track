using HealthTrack.MVC.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HealthTrack.MVC.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("IdentityConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}