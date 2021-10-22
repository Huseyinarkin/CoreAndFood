using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAndFood.Repositories;

namespace CoreAndFood.Controllers
{
    public class FoodController : Controller
    {
        public IActionResult Index()
        {
            FoodRepository foodRepository = new FoodRepository();
            return View(foodRepository.TList("Category"));
        }
    }
}
