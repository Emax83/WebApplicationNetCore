using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationNetCore.Models
{
    [Table("tblShoppingCart")]
    public class ShoppingCartItem
    {
        [Key]
        public int ShoppingCartItemId { get; set; }

        [Required]
        public int PieId { get; set; }

        [ForeignKey("PieId")]
        public Pie Pie { get; set; }

        public int Amount { get; set; }

        public string ShoppingcartId { get; set; }
    }
}
