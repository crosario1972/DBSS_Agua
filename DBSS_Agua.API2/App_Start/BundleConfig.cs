using System.Web;
using System.Web.Optimization;

namespace DBSS_Agua.API2
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        //public static void RegisterBundles(BundleCollection bundles)
        //{
        //    bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
        //                "~/Scripts/jquery-{version}.js"));

        //    // Use the development version of Modernizr to develop with and learn from. Then, when you're
        //    // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
        //    bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
        //                "~/Scripts/modernizr-*"));

        //    bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
        //              "~/Scripts/bootstrap.js"));

        //    bundles.Add(new StyleBundle("~/Content/css").Include(
        //              "~/Content/bootstrap.css",
        //              "~/Content/site.css"));
        //}

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // GeliÃ…ÂŸtirme yapmak ve ÃƒÂ¶Ã„ÂŸrenme kaynaÃ„ÂŸÃ„Â± olarak yararlanmak iÃƒÂ§in Modernizr uygulamasÃ„Â±nÃ„Â±n geliÃ…ÂŸtirme sÃƒÂ¼rÃƒÂ¼mÃƒÂ¼nÃƒÂ¼ kullanÃ„Â±n. ArdÃ„Â±ndan
            // ÃƒÂ¼retim iÃƒÂ§in hazÃ„Â±r. https://modernizr.com adresinde derleme aracÃ„Â±nÃ„Â± kullanarak yalnÃ„Â±zca ihtiyacÃ„Â±nÃ„Â±z olan testleri seÃƒÂ§in.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                       "~/Scripts/bootstrap.js",
                       "~/Scripts/respond.js",
                       "~/Content/site.css"));
        }
    }
}
