using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TNS.Web.Models
{
    public class ShoppingCartViewModel
    {
        public long ProductID { get; set; }

        public string ProductLink { get; set; }

        public string ProductImage { get; set; }

        public string ProductDetail { get; set; }

        public int? Quantity { get; set; }

        public string Description { get; set; }

        /*public IPagedList<OrderDetailViewModel> ListProducts { get; set; }*/
    }
}