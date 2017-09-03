using System.Collections.Generic;
using System.Web.Optimization;

namespace guisfits.HealthTrack.Presentation.Helpers
{
    public class AsIsBundleOrderer : IBundleOrderer
    {
        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            return files;
        }
    }
}