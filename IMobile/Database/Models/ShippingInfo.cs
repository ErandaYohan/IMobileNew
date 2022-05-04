using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Models
{
    public class ShippingInfo
    {
        [Key]
        public int shippingId { get; set; }
        public string shippingType { get; set; }
        public int shippingCost { get; set; }
    }
}
