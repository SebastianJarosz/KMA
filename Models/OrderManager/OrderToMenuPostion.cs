using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KMA.Models.OrderManager
{
    public class OrderToMenuPostion
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string OrderGuid  { get; set; }
        [Required]
        public string MenuPostionCode { get; set; }
        [Required]
        public string QuantityOfMenuPostion { get; set; }
        [Required]
        public bool IsReady { get; set; }

    }
}
