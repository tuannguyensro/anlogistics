using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TNS.Model.Models
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Key]
        public int OrderID { get; set; }

        [MaxLength(256)]
        public string TrackingID { get; set; }

        [Required]
        [MaxLength(256)]
        public string ProductLink { get; set; }

        [MaxLength(256)]
        public string ProductImage { get; set; }

        [MaxLength(256)]
        public string ProductDetail { get; set; }

        [MaxLength(750)]
        public string Description { get; set; }


        public int? Quantity { get; set; }

        public decimal? CNPrice { get; set; }
        public decimal? VNPrice { get; set; }

        public decimal? ExchangeRate { get; set; }

        [Required]
        [ForeignKey("OrderID")]
        public virtual Order Order { get; set; }

    }
}