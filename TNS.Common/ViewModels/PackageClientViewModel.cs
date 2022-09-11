using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNS.Common.ViewModels
{
    public class PackageClientViewModel
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


        public virtual ICollection<PackageDetailClientViewModel> PackageDetails { get; set; }
    }
}
