using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace KMA.Models.ProductManager
{
    public class Product
    {
        [Key]
        public string ProductCode { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public MeasureUnit MeasureUnit { get; set; }
        [Required]
        public bool Countable { get; set; }
        [Required]
        public string Quantity { get; set; }
        [Required]
        public  MeasureUnit SellUnit { get; set; }

    }
    public enum MeasureUnit
    {
        szt,
        kg,
        l,
        opk
    }
}
