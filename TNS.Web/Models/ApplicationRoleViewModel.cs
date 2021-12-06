using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TNS.Web.Models
{
    public class ApplicationRoleViewModel
    {
        public string Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public bool? IsDeleted { get; set; }
    }
}