using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KMA.Models.ProductManager
{
    public class MenuPostionToProduct
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string MenuPostionCode { get; set; }
        [Required]
        public string ProductCode { get; set; }
        [Required]
        public string QuantityOfProduct { get; set; }

    }
}
