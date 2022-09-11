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
            .Include("~/Assets/libs/jquery/jquery.js",
                    "~/Assets/libs/jquery-migrate/jquery-migrate.js"
            ));

            bundles.Add(new ScriptBundle("~/js/bootstrap")
            .Include("~/Assets/Client/plugins/bootstrap/js/popper.min.js",
                    "~/Assets/Client/plugins/bootstrap/js/bootstrap.min.js",
                    "~/Assets/Client/plugins/bootstrap-select/bootstrap-select.min.js",
                    "~/Assets/Client/plugins/bootstrap-touchspin/jquery.bootstrap-touchspin.js"
            ));

            #region~/bundles/mustache
            bundles.Add(new ScriptBundle("~/bundles/mustache")
                .Include("~/Assets/libs/mustache.js/mustache.js"));
            #endregion

            #region~/js/core
            bundles.Add(new ScriptBundle("~/js/core").Include(
                "~/Assets/Client/plugins/magnific-popup/magnific-popup.js",
                "~/Assets/Client/plugins/counter/waypoints-min.js",
                "~/Assets/Client/plugins/counter/counterup.min.js",
                "~/Assets/Client/plugins/imagesloaded/imagesloaded.js",
                "~/Assets/Client/plugins/masonry/masonry-3.1.4.js",
                "~/Assets/Client/plugins/masonry/masonry.filter.js",
                "~/Assets/Client/plugins/owl-carousel/owl.carousel.js",
                "~/Assets/Client/js/dz.carousel.js",
                "~/Assets/Client/js/dz.ajax.js",
                "~/Assets/Client/plugins/revolution/revolution/js/jquery.themepunch.tools.min.js",
                "~/Assets/Client/plugins/revolution/revolution/js/jquery.themepunch.revolution.min.js",
                "~/Assets/Client/plugins/revolution/revolution/js/extensions/revolution.extension.actions.min.js",
                "~/Assets/Client/plugins/revolution/revolution/js/extensions/revolution.extension.carousel.min.js",
                "~/Assets/Client/plugins/revolution/revolution/js/extensions/revolution.extension.kenburn.min.js",
                "~/Assets/Client/plugins/revolution/revolution/js/extensions/revolution.extension.layeranimation.min.js",
                "~/Assets/Client/plugins/revolution/revolution/js/extensions/revolution.extension.migration.min.js",
                "~/Assets/Client/plugins/revolution/revolution/js/extensions/revolution.extension.navigation.min.js",
                "~/Assets/Client/plugins/revolution/revolution/js/extensions/revolution.extension.parallax.min.js",
                "~/Assets/Client/plugins/revolution/revolution/js/extensions/revolution.extension.slideanims.min.js",
                "~/Assets/Client/plugins/revolution/revolution/js/extensions/revolution.extension.video.min.js",
                "~/Assets/Client/js/rev.slider.js",
                "~/Assets/Client/js/controller/common.js"
                ));
            #endregion
            #region~/css/core
            bundles.Add(new StyleBundle("~/css/coreclientadmin")
                .Include("~/Assets/Admin/plugins/fontawesome-free/css/all.min.cs", new CssRewriteUrlTransform())
                .Include("~/Assets/libs/loading-bar.css", new CssRewriteUrlTransform())
                .Include("~/Assets/libs/toastr.js/toastr.css", new CssRewriteUrlTransform())
                .Include("~/Assets/Admin/plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css", new CssRewriteUrlTransform())
                .Include("~/Assets/Admin/plugins/icheck-bootstrap/icheck-bootstrap.min.css", new CssRewriteUrlTransform())
                .Include("~/Assets/Admin/dist/css/adminlte.min.css", new CssRewriteUrlTransform())
                .Include("~/Assets/Admin/plugins/overlayScrollbars/css/OverlayScrollbars.min.css", new CssRewriteUrlTransform())
                .Include("~/Assets/Admin/plugins/daterangepicker/daterangepicker.css", new CssRewriteUrlTransform())
                .Include("~/Assets/Admin/plugins/summernote/summernote-bs4.min.css", new CssRewriteUrlTransform())
                .Include("~/Assets/Admin/plugins/datatables-bs4/css/dataTables.bootstrap4.min.css", new CssRewriteUrlTransform())
                .Include("~/Assets/Admin/plugins/datatables-responsive/css/responsive.bootstrap4.min.css", new CssRewriteUrlTransform())
                .Include("~/Assets/Admin/plugins/datatables-buttons/css/buttons.bootstrap4.min.css", new CssRewriteUrlTransform()));
            #endregion
            BundleTable.EnableOptimizations = true;
        }
    }
}