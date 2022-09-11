using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TNS.Model.Models
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int ID { get; set; }

        [Column(Order = 1)]
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


        public int Quantity { get; set; }

        public decimal CNPrice { get; set; }

        [ForeignKey("OrderID")]
        public virtual Order Order { get; set; }

    }
}