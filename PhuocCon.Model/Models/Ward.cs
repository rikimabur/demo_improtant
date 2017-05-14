using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhuocCon.Model.Models
{
    [Table("Ward")]
    public class Ward
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [Required]
        [MaxLength(256)]
        public string Name { set; get; }
        public string Type { set; get; }
        public int DistrictID { set; get; }
        public int? SortOrder { set; get; }
        public bool? Status { set; get; }
        public bool? IsDelete { set; get; }
        [ForeignKey("DistrictID")]
        public virtual District District { set; get; }
    }
}
