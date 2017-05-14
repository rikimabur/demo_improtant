using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhuocCon.Web.Models
{
    public class PageViewModel
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string Alias { set; get; }
        public string Content { set; get; }
        public DateTime? CreatedDate { set; get; }
        public string CreatedBy { set; get; }
        public DateTime? UpdateDate { set; get; }
        public string UpdateBy { set; get; }
        public string Metakeyword { set; get; }
        public string MetaDescription { set; get; }
        public bool Status { set; get; }
    }
}