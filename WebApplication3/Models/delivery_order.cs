using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    [Table("delivery_order")]
    public class delivery_order
    {
        [Key]
        public int order_id { get; set; }
        public int user_id { get; set; }
        public DateTime? date { get; set; }
        public string street { get; set; }
        public string house { get; set; }
        public string apartment_number { get; set; }
        public bool need_payment { get; set; }
        public bool completed { get; set; }
        public DateTime? completion_datetime { get; set; }
        public int? stars { get; set; }
        public string review { get; set; }
        public int? promocode_id { get; set; }

        public user us { get; set; }
        public promocode promo { get; set; }

    }
}