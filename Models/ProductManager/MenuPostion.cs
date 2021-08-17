using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KMA.Models.ProductManager
{
    public class MenuPostion
    {
        [Key]
        public string MenuPostionCode { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public float UnitPrice { get; set; }
        [Required]
        public string PLU { get; set; }
    }
}
