using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAndFood.Repositories;
using CoreAndFood.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreAndFood.Controllers
{
    public class FoodController : Controller
    {
        Context c = new Context();
        FoodRepository foodRepository = new FoodRepository();
        public IActionResult Index()
        {
            return View(foodRepository.TList("Category"));
        }
        [HttpGet]
        public IActionResult FoodAdd()
        {
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v1 = values;
            return View();
        }
        [HttpPost]
        public IActionResult FoodAdd(Food p)
        {
            foodRepository.TAdd(p);
            return RedirectToAction("Index");
        }
        public IActionResult FoodDelete(int id)
        {
            foodRepository.TDelete(new Food { FoodID = id });
            return RedirectToAction("Index");
        }
        public IActionResult FoodGet(int id)
        {
            var x = foodRepository.TGet(id);
            Food f = new Food()
            {
                CategoryID = x.CategoryID,
                Name = x.Name,
                Price = x.Price,
                Stock=x.Stock,                
                Description = x.Description,
                ImageURL=x.ImageURL,
                FoodID = x.FoodID
            };
            return View(f);
        }
        [HttpPost]
        public IActionResult FoodUpdate(Food p)
        {
            var x = foodRepository.TGet(p.FoodID);
            x.CategoryID = p.CategoryID;
            x.Name = p.Name;
            x.Price = p.Price;
            x.Stock = p.Stock;
            x.Description = p.Description;
            x.ImageURL = p.ImageURL;
            x.FoodID = p.FoodID;
            foodRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}
