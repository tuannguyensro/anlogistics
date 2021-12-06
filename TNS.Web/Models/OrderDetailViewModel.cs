using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TNS.Web.Models
{
    public class OrderDetailViewModel
    {
        [Required]
        public int OrderID { get; set; }

        [Required]
        public long ProductID { get; set; }

        [Required]
        public int Quantity { get; set; }

        public virtual OrderViewModel Order { get; set; }

    }
}