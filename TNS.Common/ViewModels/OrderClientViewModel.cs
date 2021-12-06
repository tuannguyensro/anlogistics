using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNS.Common.ViewModels
{
   public class OrderClientViewModel
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int PaymentStatus { get; set; }
        public string Alias { get; set; }
        public long ProductId { get; set; }
    }
}
