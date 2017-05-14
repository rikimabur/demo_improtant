using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhuocCon.Model.Models
{
    [Table("Countrys")]
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [Required]
        [MaxLength(256)]
        public string Name { set; get; }
        public string Slug { set; get; }
        public string Capital { set; get;}
        public string Sovereignty { set; get; }
        public string CurrencyName { set; get; }
        public string FormalName { set; get; }
        public string CountryType { set; get; }
        public string CountrySubType { set; get; }
        public string CountryNumber { set; get; }
        public string TelephoneCode { set; get; }
        public string InternetCountryCode { set; get; }
        public int? SortOrder { set; get; }
        public bool? Status { set; get; }
        public bool? Flags { set; get; }
        public bool? IsDelete { set; get; }
        public virtual IEnumerable<Province> Province { set; get; }
    }
}
