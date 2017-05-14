using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhuocCon.Web.Models
{
    public class DistrictViewModel
    {
        public int ID { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập tên huyện/quận.")]
        public string Name { set; get; }
        public string Type { set; get; }
        public int ProvinceID { set; get; }
        public int? SortOrder { set; get; }
        public bool? Status { set; get; }
        public bool? IsDelete { set; get; }
        public virtual ProvinceViewModel ProvinceViewModel { set; get; }
        public virtual IEnumerable<WardViewModel> WardViewModel { set; get; }
    }
}