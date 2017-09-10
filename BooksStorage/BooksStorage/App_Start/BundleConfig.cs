using System.Web.Optimization;

namespace BooksStorage
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/master").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.*",
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.unobtrusive*"
                        )
						.IncludeDirectory("~/Scripts/Utils", "*.js"));



	        bundles.Add(new StyleBundle("~/bundles/styles")
		        .IncludeDirectory("~/Content", "*.css"));

        }
    }
}
