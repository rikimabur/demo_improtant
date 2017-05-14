using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhuocCon.Web.Models
{
    public class WardViewModel
    {
        public int ID { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập tên xã/phường.")]
        public string Name { set; get; }
        public string Type { set; get; }
        public int DistrictID { set; get; }
        public int? SortOrder { set; get; }
        public bool? Status { set; get; }
        public bool? IsDelete { set; get; }
        public virtual DistrictViewModel DistrictViewModel { set; get; }
    }
}