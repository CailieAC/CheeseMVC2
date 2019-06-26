using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Data;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CheeseMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CheeseDbContext context;

        public CategoryController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            context.Categories.ToList();
            return View(context);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddCategoryViewModel viewModel = new AddCategoryViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCategoryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Add the new cheese to my existing cheeses
                CheeseCategory newCategory = new CheeseCategory()
                {
                    Name = viewModel.Name,
                };

                context.Categories.Add(newCategory);
                context.SaveChanges();

                return Redirect("/Category");
            }

            return View(viewModel);
        }
    }
}