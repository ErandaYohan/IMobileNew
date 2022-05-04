using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Items
    {
        [Key]
        public int PId { get; set; }
        public string ProductName { get; set; }
        public string PDes { get; set; }
        public string PPrice { get; set; }
        public string img { get; set; }

        public string Category { get; set; }

        //Navigation Properties
        public List<OrderDetails> orderDetails { get; set; }
    }
}
