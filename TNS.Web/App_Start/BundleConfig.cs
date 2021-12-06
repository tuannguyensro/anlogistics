using System.Web.Optimization;

namespace TNS.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;
            bundles.Add(new ScriptBundle("~/js/jquery")
                .Include("~/Assets/libs/jquery/dist/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/js/bootstrap")
               .Include("~/Assets/libs/bootstrap/dist/js/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/js/etalage")
              .Include("~/Assets/Client/js/jquery.etalage.min.js"));

            bundles.Add(new ScriptBundle("~/js/liveLocation")
              .Include("~/Assets/Client/js/controllers/liveLocation.js"));

            #region~/bundles/googleapis
            var cdnPath = "~/https://maps.googleapis.com/maps/api/js?key=AIzaSyBzoQXEpc3J26EnYucyoyNFQsUDYL4Rpls";
            bundles.Add(new ScriptBundle("~/bundles/googleapis",
                "https://maps.googleapis.com/maps/api/js?key=AIzaSyBzoQXEpc3J26EnYucyoyNFQsUDYL4Rpls")
                .Include(cdnPath));
            #endregion
            #region~/bundles/bsvalidator
            bundles.Add(new ScriptBundle("~/bundles/bsvalidator")
                .Include("~/Assets/libs/bootstrapValidator/dist/js/bootstrapValidator.min.js"));
            #endregion

            #region~/bundles/mustache
            bundles.Add(new ScriptBundle("~/bundles/mustache")
                .Include("~/Assets/libs/mustache/mustache.min.js"));
            #endregion

            #region~/js/core
            bundles.Add(new ScriptBundle("~/js/core").Include(
                "~/Assets/Client/js/custom.js",
                "~/Assets/Client/js/dz.ajax.js",
                "~/Assets/Client/js/dz.carousel.min.js",
                "~/Assets/Client/js/html5shiv.min.js",
                "~/Assets/Client/js/jquery.min.js",
                "~/Assets/Client/js/respond.min.js",
                "~/Assets/Client/js/rev.slider.js",
                "~/Assets/Client/plugins/bootstrap/js/bootstrap-select.min.js",
                "~/Assets/Client/plugins/bootstrap/js/bootstrap.min.js",
                "~/Assets/Client/plugins/bootstrap/js/popper.min.js",
                "~/Assets/Client/plugins/bootstrap/js/bootstrap-select.min.js",
                "~/Assets/Client/plugins/bootstrap-select/bootstrap-select.min.js",
                "~/Assets/Client/plugins/bootstrap-touchspin/jquery.bootstrap-touchspin.js",
                "~/Assets/Client/plugins/countdown/jquery.countdown.js",
                "~/Assets/Client/plugins/counter/counterup.min.js",
                "~/Assets/Client/plugins/counter/waypoints-min.js",
                "~/Assets/Client/plugins/fontawesome/js/fontawesome-all.min.js",
                "~/Assets/Client/plugins/imagesloaded/imagesloaded.js",
                "~/Assets/Client/plugins/magnific-popup/magnific-popup.js",
                "~/Assets/Client/plugins/masonry/masonry-3.1.4.js",
                "~/Assets/Client/plugins/masonry/masonry.filter.js",
                "~/Assets/Client/plugins/owl-carousel/owl.carousel.js",
                "~/Assets/Client/plugins/scroll/scrollbar.min.js",
                "~/Assets/Client/plugins/star-rating/jquery.star-rating-svg.js"
                ));
            #endregion
            #region~/css/core
            bundles.Add(new StyleBundle("~/css/core")
                .Include("~/Assets/libs/bootstrap/dist/css/bootstrap.min.css", new CssRewriteUrlTransform())
                .Include("~/Assets/libs/jquery-ui/themes/smoothness/jquery-ui.min.css", new CssRewriteUrlTransform())
                .Include("~/Assets/libs/font-awesome/css/font-awesome.min.css", new CssRewriteUrlTransform())
                .Include("~/Assets/libs/toastr/toastr.min.css", new CssRewriteUrlTransform())
                .Include("~/Assets/Client/css/owl.carousel.css", new CssRewriteUrlTransform())
                .Include("~/Assets/libs/icheck-bootstrap/icheck-bootstrap.min.css", new CssRewriteUrlTransform())
                .Include("~/Assets/Client/css/style.css", new CssRewriteUrlTransform())
                .Include("~/Assets/Client/css/etalage.css", new CssRewriteUrlTransform())
                .Include("~/Assets/Client/css/search-box.css", new CssRewriteUrlTransform())
                .Include("~/Assets/Client/css/customize.css", new CssRewriteUrlTransform())
                .Include("~/Assets/Client/css/responsive.css", new CssRewriteUrlTransform()));

            #endregion
            BundleTable.EnableOptimizations = true;
        }
    }
}