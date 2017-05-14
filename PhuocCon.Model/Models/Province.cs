using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhuocCon.Model.Models
{
    [Table("Province")]
    public class Province
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [Required]
        [MaxLength(256)]
        public string Name { set; get; }
        public string TelePhoneCode{ set; get; }
        public int CountryID { set; get; }
        public string CountryCode { set; get; }
        public int? SortOrder { set; get; }
        public bool? Status { set; get; }
        public bool? IsDelete { set; get; }
        [ForeignKey("CountryID")]
        public virtual Country Country { set; get; }
        public virtual IEnumerable<District> District { set; get; }
    }
}
