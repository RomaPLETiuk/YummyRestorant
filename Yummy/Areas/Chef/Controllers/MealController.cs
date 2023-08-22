﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yummy.Areas.Chef.Controllers;
using Yummy.Areas.Chef.ViewModels;
using Yummy.Data;
using Yummy.Models;

namespace Yummy.Areas.Admin.Controllers
{
    public class MealController : ChefBaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;

        public MealController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment , UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _hostingEnvironment = hostEnvironment;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var meals = _context.meals.ToList();
            return View(meals);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var categories = _context.menuCategories.ToList();
            AddMealWithVM Meal = new AddMealWithVM();
            Meal.AddMealWithCategories(categories);
            return View(Meal);
        }
        [HttpPost]
        public async Task<IActionResult> Add(MealVM meal)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);  
                Meal m = new Meal();
                m.Name = meal.Name;
                m.Price = meal.Price;
                m.Ingredients = meal.Ingredients;
                var uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
                var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(meal.Image.FileName);
                var filePath = Path.Combine(uploadFolder, uniqueName);
                meal.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                m.ImageName = uniqueName;
                m.CategoryId = meal.CategoryId;
                m.ChefId = user.Id;
                _context.meals.Add(m);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meal);
        }
        public IActionResult Details(int id)
        {
            var _meal = _context.meals.Include(x => x.ApplicationUser).Include(x => x.Category).Where(x => x.Id == id).FirstOrDefault();
            if (_meal == null)
                return NotFound();
            return View(_meal);
        }
       
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var _meal = _context.meals.Find(id);
            if (_meal == null)
                return NotFound();
            _context.meals.Remove(_meal);
            _context.SaveChanges();
            return Json(new { id = id, message = "Deleted Successfully" });
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var meal = _context.meals.Find(id);
            if (meal == null)
                return NotFound();

            var categories = _context.menuCategories.ToList();
            EditMealVM editMeal = new EditMealVM();
            editMeal.Name = meal.Name;
            editMeal.Price = meal.Price;
            editMeal.Ingredients = meal.Ingredients;
            editMeal.CategoryId = meal.CategoryId;
            editMeal.ImageName = meal.ImageName;
            editMeal.AddMealWithCategories(categories);

            return View(editMeal);
        }

        [HttpPost]
        public IActionResult Edit(int id, EditMealVM editMeal)
        {
            var meal = _context.meals.Find(id);
            if (meal == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                meal.Name = editMeal.Name;
                meal.Price = editMeal.Price;
                meal.Ingredients = editMeal.Ingredients;
                meal.CategoryId = editMeal.CategoryId;

                if (editMeal.Image != null)
                {
                    var uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
                    var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(editMeal.Image.FileName);
                    var filePath = Path.Combine(uploadFolder, uniqueName);
                    editMeal.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                    meal.ImageName = uniqueName;
                }

                // _context.meals.Update(meal);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();

            //var categories = _context.menuCategories.ToList();
            //editMeal.AddMealWithCategories(categories);

            //return View(editMeal);
        }


    }
}
