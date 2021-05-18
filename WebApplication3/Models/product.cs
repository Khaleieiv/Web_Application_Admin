using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    [Table("product")]
    public class product
    {
        [Key]
        public int product_id { get; set; }
        public string name { get; set; }
        public int category_id { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public string weight { get; set; }
        public byte[] image { get; set; }
        public int calories { get; set; }
        public int proteins { get; set; }
        public int fats { get; set; }
        public int carbohydrates { get; set; }

        public virtual product_category Category { get; set; }

    }
}