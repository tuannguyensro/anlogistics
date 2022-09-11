using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TNS.Web.Models
{
    public class OrderDetailViewModel
    {
        public int ID { get; set; }

        public int OrderID { get; set; }

        public string TrackingID { get; set; }

        public string ProductLink { get; set; }

        public string ProductImage { get; set; }

        public string ProductDetail { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal CNPrice { get; set; }

    }
}