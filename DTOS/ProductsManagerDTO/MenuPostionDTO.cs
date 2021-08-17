using System.Collections.Generic;

namespace KMA.DTOS.ProductManager
{
    public class MenuPostionDTO
    {
        public string Name { get; set; }
        public string MenuPostionCode { get; set; }
        public float UnitPrice { get; set; }
        public string PLU { get; set; }
        public List<ProductsList> Products { get; set; }

        public class ProductsList
        {
            public string ProductName { get; set; }
            public string ProductCode { get; set; }
            public string QuantityOfProduct { get; set; }
        }
    }
}
