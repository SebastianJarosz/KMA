using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KMA.DTOS.OrderManagerDTO
{
    public class OrderPostion
    {
        public string MenuPostionName { get; set; }
        public string MenuPostionCode { get; set; }
        public string QuantityOfMenuPostion { get; set; }
        public bool IsReady { get; set; }
    }
}
