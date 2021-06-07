using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationNetCore.Models;

namespace WebApplicationNetCore.ViewModels
{
    public class PieViewModel
    {

        public Category CurrentCategory { get; set; }
        public List<Pie> Pies { get; set; }
        public List<Category> Categories { get; set; }
        

    }
}
