using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhuocCon.Model.Abstract
{
   public abstract class Auditable :IAuditable
    {
       public DateTime? CreatedDate { set; get; }
       [MaxLength(256)]
       public string CreatedBy { set; get; }
       public DateTime? UpdateDate { set; get; }
       [MaxLength(256)]
       public string UpdateBy { set; get; }

       [MaxLength(256)]
       public string Metakeyword { set; get; }
       [MaxLength(256)]
       public string MetaDescription { set; get; }

       public bool Status { set; get; }
    }
}
