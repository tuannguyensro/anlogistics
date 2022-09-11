using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNS.Model.Models
{
    [Table("PackageDetails")]
    public class PackageDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int ID { get; set; }

        [Column(Order = 1)]
        public int PackageID { get; set; }

        [MaxLength(256)]
        public string TrackingID { get; set; }

        [MaxLength(750)]
        public string Description { get; set; }

        [ForeignKey("PackageID")]
        public virtual Package Package { get; set; }
    }
}
