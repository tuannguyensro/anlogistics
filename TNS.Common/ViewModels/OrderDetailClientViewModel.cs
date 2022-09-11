using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNS.Common.ViewModels
{
    public class OrderDetailClientViewModel
    {

        public int ID { get; set; }
        public int OrderID { get; set; }
        public string TrackingID { get; set; }
        public string ProductLink { get; set; }
        public string ProductImage { get; set; }
        public string ProductDetail { get; set; }
        public string Description { get; set; }
        public int? Quantity { get; set; }
        public decimal? CNPrice { get; set; }
        public decimal? TotalCNPrice { get; set; }
    }
}
