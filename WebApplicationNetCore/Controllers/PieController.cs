using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationNetCore.Interfaces;
using WebApplicationNetCore.Models;
using WebApplicationNetCore.Repositories;
using WebApplicationNetCore.ViewModels;
    

namespace WebApplicationNetCore.Controllers
{
    public class PieController : BaseController
    {

        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        //automatically injected by startup.cs  --> ConfigureServices
        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
            ViewData["DomainName"] = "Pie Shop";
        }


        public IActionResult Index()
        {
            ViewBag.Message = "Welcome to Bethany's Pie Shop";
            var pies = _pieRepository.GetPiesOfTheWeek();
            return View(pies);
        }

        public ViewResult List(int? id)
        {

            PieViewModel viewModel = new PieViewModel();
            viewModel.Categories = _categoryRepository.GetAllCategories().ToList();
            if (id.HasValue)
            {
                viewModel.CurrentCategory = _categoryRepository.GetCategoryById(id.Value);
                viewModel.Pies = _pieRepository.GetAllPies().Where(p => p.CategoryId == id.Value).ToList();
            }
            else
            {
                viewModel.Pies = _pieRepository.GetAllPies().ToList();
            }

            return View(viewModel);
        }


        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            Pie model = _pieRepository.GetPieById(id.Value);
            if(model==null)
                return NotFound();

            return View(model);
        }
    }
}
