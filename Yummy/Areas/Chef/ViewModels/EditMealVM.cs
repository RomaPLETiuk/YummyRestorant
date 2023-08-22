
//using System.Web.Mvc;
using Yummy.Models;
//using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Yummy.Areas.Chef.ViewModels
{
    public class EditMealVM //: MealVM
    {
        public EditMealVM()
        {
            _categories = new List<SelectListItem>();
        }

        public string? Name { get; set; } = "";
        public double Price { get; set; }
        public IFormFile? Image { get; set; }
        public string? ImageName { get; set; } = "";
        public string? Ingredients { get; set; } = "";
        [ForeignKey("ApplicationUser")]
        public int CategoryId { get; set; }

        public List<SelectListItem> _categories { get; set; }
        public void AddMealWithCategories(List<MenuCategory> categories)
        {
            List<SelectListItem> ListOfCategories = new List<SelectListItem>();
            foreach (var category in categories)
            {
                ListOfCategories.Add(
                new SelectListItem { Text = category.Name, Value = category.Id.ToString() }
                );
            }
            _categories = ListOfCategories;
        }

        //public List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> _categories { get; set; }
        //public void AddMealWithCategories(List<MenuCategory> categories)
        //{
        //    List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> ListOfCategories = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
        //    foreach (var category in categories)
        //    {
        //        ListOfCategories.Add(
        //        new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = category.Name, Value = category.Id.ToString() }
        //        );
        //    }
        //    _categories = ListOfCategories;
        //}

    }
    public class EditMealWithVM : MealVM
    {
        //public List<SelectListItem> _categories { get; set; }
        //public void AddMealWithCategories(List<MenuCategory> categories)
        //{
        //    List<SelectListItem> ListOfCategories = new List<SelectListItem>();
        //    foreach (var category in categories)
        //    {
        //        ListOfCategories.Add(
        //        new SelectListItem { Text = category.Name, Value = category.Id.ToString() }
        //        );
        //    }
        //    _categories = ListOfCategories;
        //}




        //public IEnumerable<SelectListItem> _categories { get; set; }

        //public void AddMealWithCategories(List<MenuCategory> categories)
        //{
        //    List<SelectListItem> ListOfCategories = new List<SelectListItem>();
        //    foreach (var category in categories)
        //    {
        //        ListOfCategories.Add(
        //            new SelectListItem { Text = category.Name, Value = category.Id.ToString() }
        //        );
        //    }
        //    _categories = ListOfCategories;
        //}
        //Microsoft.AspNetCore.Mvc.Rendering.SelectListItem item = new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem();
        public List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> _categories { get; set; }
        public void AddMealWithCategories(List<MenuCategory> categories)
        {
            List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> ListOfCategories = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
            foreach (var category in categories)
            {
                ListOfCategories.Add(
                new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = category.Name, Value = category.Id.ToString() }
                );
            }
            _categories = ListOfCategories;
        }



    }
}

