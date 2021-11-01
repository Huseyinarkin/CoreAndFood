using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndFood.Models
{
    public class Admin
    {
        [Key]
        public int ID { get; set; }
        [StringLength(20)]
        public string UserName { get; set; }
        [StringLength(20)]
        public string PAssword { get; set; }
        [StringLength(1)]
        public string Role { get; set; }
    }
}
