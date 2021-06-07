using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationNetCore.Models
{

    [Table("tblOrders")]
    public class Order
    {

        [Key]
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public List<OrderDetail> OrderDetails { get; set; }

        public DateTime OrderPlaced { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        public decimal? OrderTotal { get; set; }


    }
}
