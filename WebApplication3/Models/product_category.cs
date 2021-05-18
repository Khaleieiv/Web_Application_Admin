using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class product_category
    {
        [Key]
        public int category_id { get; set; }
        public string name { set; get; }

    }
}