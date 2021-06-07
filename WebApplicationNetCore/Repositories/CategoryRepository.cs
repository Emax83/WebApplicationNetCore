using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationNetCore.Interfaces;
using WebApplicationNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationNetCore.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private List<Category> Categories;

        private AppDbContext _dbContext;
        public CategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;

            Categories = new List<Category>();
            Categories.Add(new Category() { CategoryId = 1, CategoryName = "Fruit Pies", Description = "All Fruit Pies" });
            Categories.Add(new Category() { CategoryId = 2, CategoryName = "Cheese Cakes", Description = "Cheesy all the way" });
            Categories.Add(new Category() { CategoryId = 3, CategoryName = "Seasonal pies", Description = "Get in mood for the season" });
        }

        public IEnumerable<Category> GetAllCategories()
        {
            //return Categories.ToList();
            return _dbContext.Categories
                .Include(p => p.Pies)
                .ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            //return Categories.FirstOrDefault(x => x.CategoryId == categoryId);
            return _dbContext.Categories
                 .Include(p => p.Pies)
                .FirstOrDefault(x => x.CategoryId == categoryId);
        }
    }
}
