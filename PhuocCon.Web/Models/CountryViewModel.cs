using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhuocCon.Web.Models
{
    public class CountryViewModel
    {
        public int ID { set; get; }
        [Required(ErrorMessage ="Xin vui lòng nhận tên quốc gia")]
        public string Name { set; get; }
        public string Slug { set; get; }
        public string Capital { set; get; }
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
        public virtual IEnumerable<ProvinceViewModel> ProvinceViewModel { set; get; }
    }
}