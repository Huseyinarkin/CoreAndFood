using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndFood.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required(ErrorMessage ="Category Name Not Empty")]
        [StringLength(20,ErrorMessage ="Plaese only enter 4-20 length characters",MinimumLength =4)]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public List<Food> Foods { get; set; }
    }
}
