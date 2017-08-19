using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace guisfits.HealthTrack.Presentation.Helpers
{
    public static class PermissionHelper
    {
        public static MvcHtmlString IfClaimHelper(this MvcHtmlString value, string claimName, string claimValue)
        {
            return ValidationPermission(claimName, claimValue) ? value : MvcHtmlString.Empty;
        }

        public static string IfClaimShow(this WebViewPage value, string claimName, string claimValue)
        {
            return !ValidationPermission(claimName, claimValue) ? "disabled" : "";
        }

        private static bool ValidationPermission(string claimName, string claimValue)
        {
            var identity = (ClaimsIdentity) HttpContext.Current.User.Identity;
            var claim = identity.Claims.FirstOrDefault(c => c.Type == claimName);
            return claim != null && claim.Value.Contains(claimValue);
        }
    }
}