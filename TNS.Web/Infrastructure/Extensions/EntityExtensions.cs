using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TNS.Model.Models;
using TNS.Web.Models;

namespace TNS.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdateOrder(this Order order, OrderViewModel orderViewModel)
        {
            order.ID = orderViewModel.ID;
            order.OrderCode = "AL" + DateTime.Now.ToString("ddMMyyyyHHmmss");
            order.CustomerName = orderViewModel.CustomerName;
            order.CustomerEmail = orderViewModel.CustomerEmail;
            order.CustomerAddress = orderViewModel.CustomerAddress;
            order.CustomerMobile = orderViewModel.CustomerMobile;
            order.PaymentMethod = orderViewModel.PaymentMethod;
            order.PaymentStatus = orderViewModel.PaymentStatus;
            order.Status = true;
            order.CustomerMessage = orderViewModel.CustomerMessage;
            order.CustomerId = orderViewModel.CustomerId;
            order.CreatedBy = orderViewModel.CreatedBy;
            order.CreatedDate = DateTime.Now;
            order.TransportCNFree = orderViewModel.TransportCNFree;
            order.OrderFee = orderViewModel.OrderFee;
            order.ExchangeRate = orderViewModel.ExchangeRate;
            order.WeightOrder = orderViewModel.WeightOrder;
            order.WeightFee = orderViewModel.WeightFee;
        }

        public static void UpdateOrderDetail(this OrderDetail orderDetail, OrderDetailViewModel orderDetailViewModel)
        {
            orderDetail.TrackingID = orderDetailViewModel.TrackingID;
            orderDetail.Quantity = orderDetailViewModel.Quantity;
            orderDetail.CNPrice = orderDetailViewModel.CNPrice;
            orderDetail.Description = orderDetailViewModel.Description;
            orderDetail.ProductDetail = orderDetailViewModel.ProductDetail;
            orderDetail.ProductLink = orderDetailViewModel.ProductLink;
           
        }

        public static void UpdatePackage(this Package package, PackageViewModel packageViewModel)
        {
            package.ID = packageViewModel.ID;
            package.PackageCode = "KG" + DateTime.Now.ToString("ddMMyyyyHHmmss");
            package.CustomerName = packageViewModel.CustomerName;
            package.CustomerEmail = packageViewModel.CustomerEmail;
            package.CustomerAddress = packageViewModel.CustomerAddress;
            package.CustomerMobile = packageViewModel.CustomerMobile;
            package.PaymentMethod = packageViewModel.PaymentMethod;
            package.PaymentStatus = packageViewModel.PaymentStatus;
            package.CreatedBy = packageViewModel.CreatedBy;
            package.CreatedDate = DateTime.Now;
            package.CustomerId = packageViewModel.CustomerId;
        }

        public static void UpdatePackageDetail(this PackageDetail packageDetail, PackageDetailViewModel packageDetailViewModel)
        {
            packageDetail.TrackingID = packageDetailViewModel.TrackingID;
            packageDetail.Description = packageDetailViewModel.Description;

        }

        public static void UpdateApplicationGroup(this ApplicationGroup appGroup, ApplicationGroupViewModel appGroupViewModel)
        {
            appGroup.ID = appGroupViewModel.ID;
            appGroup.Name = appGroupViewModel.Name;
            appGroup.Description = appGroupViewModel.Description;
            appGroup.IsDeleted = appGroupViewModel.IsDeleted;
        }

        public static void UpdateApplicationRole(this ApplicationRole appRole, ApplicationRoleViewModel appRoleViewModel, string action = "add")
        {
            if (action == "update")
                appRole.Id = appRoleViewModel.Id;
            else
                appRole.Id = Guid.NewGuid().ToString();
            appRole.Name = appRoleViewModel.Name;
            appRole.Description = appRoleViewModel.Description;
            appRole.IsDeleted = appRoleViewModel.IsDeleted;
        }

        public static void UpdateUser(this ApplicationUser appUser, ApplicationUserViewModel appUserViewModel)
        {
            appUser.Id = appUserViewModel.Id;
            appUser.FullName = appUserViewModel.FullName;
            appUser.BirthDay = appUserViewModel.BirthDay;
            appUser.Email = appUserViewModel.Email;
            appUser.Image = appUserViewModel.Image;
            appUser.UserName = appUserViewModel.UserName;
            appUser.PhoneNumber = appUserViewModel.PhoneNumber;
            appUser.IsDeleted = appUserViewModel.IsDeleted;
            appUser.Gender = appUserViewModel.Gender;
            appUser.CreatedDate = appUserViewModel.CreatedDate;
            appUser.UpdatedDate = appUserViewModel.UpdatedDate;

        }


    }
}