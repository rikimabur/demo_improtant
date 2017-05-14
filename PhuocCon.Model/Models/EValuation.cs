using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhuocCon.Model.Models
{
    [Table("Evaluations")]
    public class Evaluation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [Required]
        public int productID { set; get; }
        [Required]
        public string CustomerID { set; get; }
        public string Content { set; get; }
        [Required]
        public int NumberStars { set; get; }
        [ForeignKey("productID")]
        public virtual Product Product { set; get; }
        [ForeignKey("CustomerID")]
        public virtual ApplicationUser ApplicationUser { set; get; }
    }
}
