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

    }
}
