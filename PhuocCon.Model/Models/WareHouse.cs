using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhuocCon.Model.Models
{
    [Table("WareHouse")]
    public class WareHouse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [Required]
        [MaxLength(250)]
        public string WareHouse_Name { set; get; }
        [Required]
        [MaxLength(250)]
        public string Adress { set; get; }
    }
}
