using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Orders
    {
        [Key]
        public int orderId { get; set; }

        public DateTime orderDate { get; set; }
        public string dateShipped { get; set; }
        public string customerName { get; set; }
        public int customerId { get; set; }
        public string status { get; set; }
        public int shippingId { get; set; }

        //Navigation Properties
        public List<OrderDetails> orderDetails { get; set; }
        public List<ShippingInfo> shippingInfos { get; set; }
    }
}
