using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KMA.Models.ProductManager
{
    public class ItemsModyficationHistory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public string ItemCode { get; set; }
        [Required]
        public DateTime ModyficationDate { get; set; }
        public String OldItem { get; set; }
    }
}
