using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TNS.Web.Models
{
    public class DashBoardViewModel
    {
        public int TotalOrders { get; set; }
        public int TotalProducts { get; set; }
        public int TotalUsers { get; set; }
        public int TotalFeedbacks { get; set; }
    }
}