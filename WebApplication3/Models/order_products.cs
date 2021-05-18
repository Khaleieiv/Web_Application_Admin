using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    [Table("order_products")]
    public class order_products
    {
        [Key]
        public int order_id { get; set; }
        public int product_id { get; set; }
        public int amount { get; set; }
        public decimal price { get; set; }

        public product product { get; set; }

    }
}