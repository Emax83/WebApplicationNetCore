using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationNetCore.Models
{
 
    [Table("tblPies")] //using System.ComponentModel.DataAnnotations.Schema;
    public class Pie
    {
        [Key] //using System.ComponentModel.DataAnnotations;
        public int PieId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }

        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        
        public bool IsPieOfTheWeek { get; set; }

        public bool InStock { get; set; }

        [Required]
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

    }
}
