using KMA.Models.ProductManager;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KMA.Models.StockManager
{
    public class ProductStock
    {
        [Key]
        public string StockGuid { get; set; }
        public string ProductCode { get; set; }
        [ForeignKey("ProductCode")]
        public Product Product { get; set; }
        [Required]
        public float Quantity { get; set; }
        [Required]
        public Status SotckStaus { get; set; }
        [Required]
        public bool IsBasic { get; set; }
    }
    public enum Status
    {
        onStock,
        inPrepare,
        readyToUse,
        obsolete
    }
}
