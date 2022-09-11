using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNS.Common.ViewModels
{
   public class OrderClientViewModel
    {
        public int ID { get; set; }
        public string OrderCode { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerMobile { get; set; }
        public string CustomerMessage { get; set; }
        public decimal? TransportCNFree { get; set; }
        public int? OrderFee { get; set; }
        public decimal? TotalOriginalPrice { get; set; }

        public decimal? ToTalCNPrice { get; set; }
        public decimal? ExchangeRate { get; set; }
        public decimal? ToTalVNPrice { get; set; }

        public int? WeightOrder { get; set; }
        public decimal? WeightFee { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string PaymentMethod { get; set; }
        public int PaymentStatus { get; set; }

        public virtual IEnumerable<OrderDetailClientViewModel> OrderDetailsClient { get; set; }
    }
}
