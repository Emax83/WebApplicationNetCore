using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationNetCore.Models
{
    [Table("tblOrderDetails")]
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int PieId { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public decimal Price { get; set; }

        public decimal SubTotal { get; set; }

        public Order Order { get; set; }

        [ForeignKey("PieId")]
        public Pie Pie { get; set; }

    }
}
