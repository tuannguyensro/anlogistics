using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TNS.Web.Models
{
    public class PackageDetailViewModel
    {
        public int ID { get; set; }

        public int PackageID { get; set; }

        public string TrackingID { get; set; }

        public string Description { get; set; }

    }
}