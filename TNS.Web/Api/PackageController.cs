using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;
using TNS.Model.Models;
using TNS.Service;
using TNS.Web.Infrastructure.Core;
using TNS.Web.Infrastructure.Extensions;
using TNS.Web.Models;

namespace TNS.Web.Api
{
    [Authorize]
    [RoutePrefix("api/package")]
    public class PackageController : ApiControllerBase
    {
        private IPackageService _packageService;
        private IPackageDetailService _packageDetailService;
        public PackageController(IPackageService packageService, IPackageDetailService packageDetailService, IErrorService errorService) : base(errorService)
        {
            _packageService = packageService;
            _packageDetailService = packageDetailService;
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        [Authorize(Roles = "UpdateUser")]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _packageService.FindById(id);

                //if (rm) model = _orderDetailService.FindWithRelationData(id, related: false);

                var responseData = Mapper.Map<Package, PackageViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("getall")]
        [HttpGet]
        //[Authorize(Roles = "ViewUser")]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _packageService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<Package>, IEnumerable<PackageViewModel>>(query.AsEnumerable());

                var paginationSet = new PaginationSet<PackageViewModel>()
                {
                    Items = responseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        [Authorize(Roles = "UpdateUser")]
        public HttpResponseMessage Update(HttpRequestMessage request, PackageViewModel PackageVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var dbPackage = _packageService.FindById(PackageVm.ID);

                    dbPackage.UpdatePackage(PackageVm);
                    _packageService.Update(dbPackage);
                    _packageService.SaveChanges();

                    var responseData = Mapper.Map<Package, PackageViewModel>(dbPackage);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("delete")]
        [HttpDelete]
        [AllowAnonymous]
        [Authorize(Roles = "DeleteUser")]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var oldPackage = _packageService.FindById(id);
                    _packageService.Delete(oldPackage.ID);
                    _packageService.SaveChanges();

                    var responseData = Mapper.Map<Package, PackageViewModel>(oldPackage);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("deletemulti")]
        [HttpDelete]
        [AllowAnonymous]
        [Authorize(Roles = "DeleteUser")]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string selectedPackages)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var listPackages = new JavaScriptSerializer().Deserialize<List<int>>(selectedPackages);
                    foreach (var item in listPackages)
                    {
                        _packageService.Delete(item);
                    }

                    _packageService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.OK, listPackages.Count);
                }

                return response;
            });
        }

        //PHẦN CHI TIẾT ĐƠN HÀNG
        //Lấy danh sách chi tiết đơn hàng.
        [Route("getlistdetailbyid/{id:int}")]
        [HttpGet]
        [Authorize(Roles = "UpdateUser")]
        public HttpResponseMessage GetListDetailById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var listDetail = _packageDetailService.ListPackageDetailByPackageID(id);

                //if (rm) model = _orderDetailService.FindWithRelationData(id, related: false);

                var responseData = Mapper.Map<IEnumerable<PackageDetail>, IEnumerable<PackageDetailViewModel>>(listDetail);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("updatepackagedetail")]
        [HttpGet]
        [AllowAnonymous]
        [Authorize(Roles = "UpdateUser")]
        public HttpResponseMessage UpdatePackageDetail(HttpRequestMessage request, string listpackagedetails)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var listPackageDetails = new JavaScriptSerializer().Deserialize<List<PackageDetailViewModel>>(listpackagedetails);
                    foreach (var item in listPackageDetails)
                    {
                        var listOD = _packageDetailService.FindById(item.ID);
                        listOD.UpdatePackageDetail(item);
                        _packageDetailService.Update(listOD);
                        _packageDetailService.SaveChanges();
                        var responseData = Mapper.Map<PackageDetail, PackageDetailViewModel>(listOD);
                        response = request.CreateResponse(HttpStatusCode.OK, responseData);
                    }
                }
                return response;
            });
        }

        [Route("deletedetail")]
        [HttpDelete]
        [AllowAnonymous]
        [Authorize(Roles = "DeleteUser")]
        public HttpResponseMessage DeleteOrderDetail(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var oldPackageDetail = _packageDetailService.FindById(id);
                    _packageDetailService.Delete(oldPackageDetail.ID);
                    _packageDetailService.SaveChanges();

                    var responseData = Mapper.Map<PackageDetail, PackageDetailViewModel>(oldPackageDetail);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

    }
}