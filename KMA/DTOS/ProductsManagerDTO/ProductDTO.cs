using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KMA.DTOS.ProductManager
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public string MeasureUnit { get; set; }
        public bool Countable { get; set; }
        public string Quantity { get; set; }
        public string SellUnit { get; set; }
    }
}
