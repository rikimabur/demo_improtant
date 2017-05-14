using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhuocCon.Model.Models
{
    [Table("WareHouseDetail")]
    public class WareHouseProduct
    {
        [Key]
        [Column(Order = 1)]
        public int WareHouseID { set; get; }
        [Key]
        [Column(Order = 2)]
        public int productID { set; get; }
        public decimal Quantity { set; get; }
        public decimal Inventory_Number { set; get; }
        public decimal Sell_Number { set; get; }
        public bool Status { set; get; }

        [ForeignKey("WareHouseID")]
        public virtual WareHouse WareHouse { set; get; }
        [ForeignKey("productId")]
        public virtual Product Product { set; get; }
    }
}
