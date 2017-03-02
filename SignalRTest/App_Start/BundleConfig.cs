using System.Web.Optimization;

namespace SignalRTest
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Theme/CSS").Include(
                "~/Content/themes/base/jquery-ui.min.css",
                "~/Content/Site.css",
                "~/Content/bootstrap.min.css"
                ));

            bundles.Add(new ScriptBundle("~/Theme/JS").Include(
                "~/Scripts/jquery-1.12.4.min.js"
            ));

            bundles.Add(new ScriptBundle("~/Theme/jQueryUI").Include(
                "~/Scripts/jquery-ui-1.12.1.min.js",
                "~/Scripts/bootstrap.min.js"
            ));

            BundleTable.EnableOptimizations = false;
        }
    }
}
