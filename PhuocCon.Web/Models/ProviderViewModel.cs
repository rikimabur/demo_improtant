using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhuocCon.Web.Models
{
    public class ProviderViewModel
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string Image { set; get; }
        public bool Status { set; get; }
        public virtual IEnumerable<ProductViewModel> Product { set; get; }
    }
}