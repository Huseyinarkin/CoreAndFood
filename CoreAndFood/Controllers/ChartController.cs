using CoreAndFood.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndFood.Controllers
{
    public class ChartController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VisualizeProductResult()
        {
            return Json(FoodList());
        }
        public List<foodChart> FoodList()
        {
            List<foodChart> fc = new List<foodChart>();
            using (var c = new Context())
            {
                fc = c.Foods.Select(x => new foodChart
                {
                    foodName = x.Name,
                    stock = x.Stock
                }).ToList();
            }
            return fc;
        }

        public IActionResult Statistics()
        {
            ViewBag.d1 = c.Foods.Count();
            ViewBag.d2 = c.Categories.Count();
            ViewBag.d3 = c.Foods.Where(x => x.CategoryID == 1).Count();
            ViewBag.d4 = c.Foods.Where(x => x.CategoryID == 2).Count();

            ViewBag.d5 = c.Foods.Sum(x => x.Stock);
            ViewBag.d6 = c.Foods.Where(x => x.CategoryID == c.Categories.Where(y => y.CategoryName == "Fruit").Select(z => z.CategoryID).FirstOrDefault()).Count();
            ViewBag.d7 = c.Foods.OrderByDescending(x => x.Stock).Select(y => y.Name).FirstOrDefault();
            ViewBag.d8 = c.Foods.OrderBy(x => x.Stock).Select(y => y.Name).FirstOrDefault();

            ViewBag.d9 = c.Foods.Average(x => x.Price).ToString("0.00");

            var dgr10 = c.Categories.Where(x => x.CategoryName == "Fruit").Select(y => y.CategoryID).FirstOrDefault();
            ViewBag.d10 = c.Foods.Where(y => y.CategoryID == dgr10).Sum(x => x.Stock);

            var dgr11= c.Categories.Where(x => x.CategoryName == "Vegetables").Select(y => y.CategoryID).FirstOrDefault();
            ViewBag.d11 = c.Foods.Where(y => y.CategoryID == dgr11).Sum(x => x.Stock);

            ViewBag.d12 = c.Foods.OrderByDescending(x => x.Price).Select(y => y.Name).FirstOrDefault();
            return View();
        }
    }
}
