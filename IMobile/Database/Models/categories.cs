using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Models
{
    public class categories
    {
        [Key]
        public int CatId { get; set; }
        public string CategoryName { get; set; }

        //Navigation Properties
        public List<Items> Items { get; set; }
    }
}
