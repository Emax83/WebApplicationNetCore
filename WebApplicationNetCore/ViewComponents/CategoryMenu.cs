using Microsoft.AspNetCore.Mvc;
using WebApplicationNetCore.Models;
using WebApplicationNetCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationNetCore.Interfaces;

namespace WebApplicationNetCore.ViewComponents
{
    public class CategoryMenu : ViewComponent
    {

        private readonly ICategoryRepository _categoryRepository;

        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepository.GetAllCategories().OrderBy(c => c.CategoryName);
            return View(categories);
        }

    }
}
