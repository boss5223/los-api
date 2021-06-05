using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace los_api.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string imageUrl { get; set; }
        public int price { get; set; }
        public virtual Stock Stocks { get; set; }
    }
}
