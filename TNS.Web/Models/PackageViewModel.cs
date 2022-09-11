using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TNS.Model.Models;

namespace TNS.Web.Models
{
    [Serializable]
    public class PackageViewModel
    {

        public int ID { get; set; }

        public string PackageCode { get; set; }

        public string CustomerName { get; set; }

        public string CustomerAddress { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerMobile { get; set; }

        public string CustomerMessage { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public string PaymentMethod { get; set; }

        public int PaymentStatus { get; set; }

        public string CustomerId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<PackageDetailViewModel> PackageDetails { get; set; }
    }
}