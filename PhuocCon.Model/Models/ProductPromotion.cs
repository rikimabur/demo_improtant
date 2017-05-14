using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhuocCon.Model.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PhuocCon.Model
{
    [Table("ProductPromotion")]
    public class ProductPromotion
    {
        [Key]
        [Column(Order=1)]
        public int promotionID { set; get; }
        [Key]
        [Column(Order =2)]
        public int productID { set; get; }
        [Required]
        public DateTime StartDay { set; get; }
        [Required]
        public DateTime EndDay { set; get; }
        public decimal PercentPromotion { set; get; }
        [ForeignKey("promotionID")]
        public virtual Promotion Promotion { set; get; }
        [ForeignKey("productID")]
        public virtual Product Product { set; get; }
    }
}
