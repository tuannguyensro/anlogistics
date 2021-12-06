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
            order.CustomerName = orderViewModel.CustomerName;
            order.CustomerEmail = orderViewModel.CustomerEmail;
            order.CustomerAddress = orderViewModel.CustomerAddress;
            order.CustomerMobile = orderViewModel.CustomerMobile;
            order.PaymentMethod = orderViewModel.PaymentMethod;
            order.PaymentStatus = orderViewModel.PaymentStatus;
            order.CustomerMessage = orderViewModel.CustomerMessage;
            order.CustomerId = orderViewModel.CustomerId;
            order.CreatedDate = DateTime.Now;
            order.CreatedBy = orderViewModel.CreatedBy;
            order.WeightOrder = orderViewModel.WeightOrder;
            order.TransportPrice = orderViewModel.TransportPrice;
            order.TotalTransportPrice = orderViewModel.TotalTransportPrice;
            order.TotalOriginalPrice = orderViewModel.TotalOriginalPrice;
            order.ToTalPrice = orderViewModel.ToTalPrice;

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