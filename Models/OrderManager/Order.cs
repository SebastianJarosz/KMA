using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KMA.Models.OrderManager
{
    public class Order
    {
        [Key]
        public string OrderGuid { get; set; }
        [Required]
        [Range(1,99)]
        public int OrderNumber { get; set; }
        [Required]
        public DateTime CreationTime { get; set; }
        [Required]
        public DateTime ModificationTime { get; set; }
        [Required]
        public Status Status { get; set; }

    }
    public enum Status
    {
        InProgress,
        Ready,
        Closed,
        Aborted
    }
}
