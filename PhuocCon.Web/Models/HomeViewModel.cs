using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhuocCon.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<SlideViewModel> Slides { get; set; }
        public IEnumerable<ProductViewModel> LastestProduct { get; set; }
        public IEnumerable<ProductViewModel> TopSaleProduct { get; set; }
        public string Title { set; get; }
        public string Metakeyword { set; get; }
        public string MetaDescription { set; get; }
    }
}