using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KMA.DTOS.OrderManagerDTO
{
    public class OrderDTO
    {
        public string OrderGuid { get; set; }
        public int OrderNumber { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ModificationTime { get; set; }
        public string Status { get; set; }
        public List<OrderPostion> OrderPostion { get; set; }
    
    }
}
