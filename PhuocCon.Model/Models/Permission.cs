using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhuocCon.Model.Models
{
    [Table("Permissions")]
    public class Permission
    {
        [Key]
        public int ID { get; set; }
        [StringLength(128)]
        public string RoleId { get; set; }
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        public string FunctionId { get; set; }
        public bool CanCreate { get; set; }
        public bool CanRead { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }
        [ForeignKey("RoleId")]
        public ApplicationRole ApplicationRole { get; set; }
        //[ForeignKey("FunctionId")]
        //public Function Function { get; set; }
    }
}
