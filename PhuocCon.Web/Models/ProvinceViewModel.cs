using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhuocCon.Web.Models
{
    public class ProvinceViewModel
    {
        public int ID { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập tên tỉnh.")]
        public string Name { set; get; }
        public string TelePhoneCode { set; get; }
        public int CountryID { set; get; }
        public string CountryCode { set; get; }
        public int? SortOrder { set; get; }
        public bool?Status { set; get; }
        public bool? IsDelete { set; get; }
        public virtual CountryViewModel Country { set; get; }
        public virtual IEnumerable<DistrictViewModel> DistrictViewModel { set; get; }
    }
}