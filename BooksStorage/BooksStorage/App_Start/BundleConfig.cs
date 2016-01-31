using System.Web.Optimization;

namespace BooksStorage
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/jquery.validate.unobtrusive.js",
                        "~/Scripts/common.js"));



            bundles.Add(new StyleBundle("~/bundles/styles").Include(
                      "~/Content/site.css",
                      "~/Content/themes/base/*.css"));




            BundleTable.EnableOptimizations = true;
        }
    }
}
