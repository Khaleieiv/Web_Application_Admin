using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    [Table("promocode")]
    public class promocode
    {
        [Key]
        public int promocode_id { get; set; }
        public string value { get; set; }
        public bool active { get; set; }
        public int discount_percent { get; set; }
    }
}