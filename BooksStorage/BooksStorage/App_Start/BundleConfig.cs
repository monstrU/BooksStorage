using System.Web.Optimization;

namespace BooksStorage
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/master").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/jquery.validate.unobtrusive.js",
						"~/Scripts/bootstrap.*"
                        ));



	        bundles.Add(new StyleBundle("~/bundles/styles")
		        .IncludeDirectory("~/Content", "*.css"));

        }
    }
}
