using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNS.Common.ViewModels
{
    public class PackageDetailClientViewModel
    {
        public int ID { get; set; }

        public int PackageID { get; set; }

        public string TrackingID { get; set; }

        public string Description { get; set; }
    }
}
