using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TNS.Model.Models
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Key]
        [Column(Order = 1)]
        public int OrderID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProductID { get; set; }

        [MaxLength(256)]
        public string TrackingID { get; set; }

        [MaxLength(256)]
        public string ProductLink { get; set; }

        [MaxLength(256)]
        public string ProductImage { get; set; }

        [MaxLength(256)]
        public string ProductDetail { get; set; }

        public int Quantity { get; set; }

        public decimal CNPrice { get; set; }
        public decimal VNPrice { get; set; }

        public decimal ExchangeRate { get; set; }

        [MaxLength(750)]
        public string Description { get; set; }
        [Required]

        [ForeignKey("OrderID")]
        public virtual Order Order { get; set; }

    }
}