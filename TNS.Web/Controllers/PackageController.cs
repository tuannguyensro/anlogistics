using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TNS.Model.Models;
using TNS.Service;
using TNS.Web.App_Start;
using TNS.Web.Infrastructure.Extensions;
using TNS.Web.Models;

namespace TNS.Web.Controllers
{
    public class PackageController : Controller
    {
        private IPackageService _packageService;
        private ApplicationUserManager _userManager;

        public PackageController(ApplicationUserManager userManager, IPackageService packageService)
        {
            _userManager = userManager;
            _packageService = packageService;
        }
        // GET: Package
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePackage(string packageViewModel)
        {
            if (!Request.IsAuthenticated)
            {
                return Json(new { status = false });
            }
            var package = new JavaScriptSerializer().Deserialize<PackageViewModel>(packageViewModel);
            var packageNew = new Package();
            packageNew.UpdatePackage(package);
            if (Request.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                packageNew.CustomerId = userId;
                packageNew.CreatedBy = User.Identity.GetUserName();
            }
            List<PackageDetail> packageDetails = new List<PackageDetail>();
            foreach (var item in package.PackageDetails)
            {
                var detail = new PackageDetail();
                detail.ID = item.ID;
                detail.TrackingID = item.TrackingID;
                detail.Description = item.Description;
                packageDetails.Add(detail);
            }
            _packageService.Add(ref packageNew, packageDetails);
            _packageService.SaveChanges();
            return Json(new
            {
                status = true,
            });
        }

        [Authorize]
        public JsonResult GetUserInfo()
        {
            if (Request.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                var user = _userManager.FindById(userId);
                return Json(new
                {
                    data = user,
                    status = true
                });
            }
            return Json(new
            {
                status = false,
                message = "Bạn cần đăng nhập để sử dụng tính năng này!!!"
            });
        }

        [Authorize]
        public ActionResult ListPackage()
        {
            var userId = User.Identity.GetUserId();
            var packages = _packageService.GetListPackages(User.Identity.GetUserId());
            return View(packages);
        }

        [Authorize]
        public JsonResult GetListPackage()
        {
            var userId = User.Identity.GetUserId();
            var packages = _packageService.GetListPackages(User.Identity.GetUserId());

            return Json(new
            {
                data = packages,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }


        [Authorize]
        public ActionResult ListPackageDetailByID(int id)
        {
            var packagedetail = _packageService.ListDetailByPackageID(id);
            var packagedetailVm = Mapper.Map<IEnumerable<PackageDetail>, IEnumerable<PackageDetailViewModel>>(packagedetail);
            var package = _packageService.FindById(id);
            var packageVm = Mapper.Map<Package, PackageViewModel>(package);
            ViewBag.Package = packageVm;
            return View(packagedetailVm);
        }
    }
}