using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationNetCore.Interfaces;
using WebApplicationNetCore.Models;

namespace WebApplicationNetCore.Repositories
{
    public class PieRepository : IPieRepository
    {
        private AppDbContext _dbContext;

        //private List<Pie> Pies;
        public PieRepository(AppDbContext dbContext)
        {

            _dbContext = dbContext;

            /*
            Pies = new List<Pie>();
            Pies.Add(new Pie() { PieId = 1, Name = "Pie 1", ShortDescription = "", LongDescription = "", Price = 5.99M, IsPieOfTheWeek = false, ImageUrl = "~/images/pies/pie1.png", ImageThumbnailUrl = "~/images/pies/pie1Thumb.png" });
            Pies.Add(new Pie() { PieId = 2, Name = "Pie 2", ShortDescription = "", LongDescription = "", Price = 11.50M, IsPieOfTheWeek = false, ImageUrl = "~/images/pies/pie2.png", ImageThumbnailUrl = "~/images/pies/pie2Thumb.png" });
            Pies.Add(new Pie() { PieId = 3, Name = "Pie 3", ShortDescription = "", LongDescription = "", Price = 6.99M, IsPieOfTheWeek = true, ImageUrl = "~/images/pies/pie3.png", ImageThumbnailUrl = "~/images/pies/pie3Thumb.png" });
            Pies.Add(new Pie() { PieId = 4, Name = "Pie 4", ShortDescription = "", LongDescription = "", Price = 15M, IsPieOfTheWeek = false , ImageUrl = "~/images/pies/pie4.png", ImageThumbnailUrl = "~/images/pies/pie4Thumb.png" });
            Pies.Add(new Pie() { PieId = 5, Name = "Pie 5", ShortDescription = "", LongDescription = "", Price = 20M, IsPieOfTheWeek = false, ImageUrl = "~/images/pies/pie5.png", ImageThumbnailUrl = "~/images/pies/pie5Thumb.png" });
            Pies.Add(new Pie() { PieId = 5, Name = "Pie 6", ShortDescription = "", LongDescription = "", Price = 55M, IsPieOfTheWeek = true, ImageUrl = "~/images/pies/pie6.png", ImageThumbnailUrl = "~/images/pies/pie6Thumb.png" });
            */
        }

        public IEnumerable<Pie> GetAllPies()
        {
            //return Pies.ToList();
            return _dbContext.Pies
                .Include(c => c.Category) //using Microsoft.EntityFrameworkCore;
                .ToList();
        }



        public IEnumerable<Pie> GetPiesOfTheWeek()
        {
            //return Pies.Where(x => x.IsPieOfTheWeek == true);
            return _dbContext.Pies
               .Include(c => c.Category)
               .Where(p => p.IsPieOfTheWeek == true)
               .ToList();
        }

        public Pie GetPieById(int pieId)
        {
            //return Pies.FirstOrDefault(x => x.PieId == pieId);
            return _dbContext.Pies
               .Include(c => c.Category)
               .FirstOrDefault(x => x.PieId == pieId);
        }

    }
}
      