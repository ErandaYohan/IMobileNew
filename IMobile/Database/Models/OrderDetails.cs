using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderId { get; set; }

        public int PId { get; set; }

        public string ProductName { get; set; }

        public int quantity { get; set; }

        public int unitCost { get; set; }

        public int subTotal { get; set; }
    }
}
