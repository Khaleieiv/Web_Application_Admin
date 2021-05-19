using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Order Id")]
        public int order_id { get; set; }
        [DisplayName("User Id")]
        public int user_id { get; set; }
        [DisplayName("Data")]
        public DateTime? date { get; set; }
        [DisplayName("Street")]
        public string street { get; set; }
        [DisplayName("House ")]
        public string house { get; set; }
        [DisplayName("Flat")]
        public string apartment_number { get; set; }
        [DisplayName("Payment")]
        public bool need_payment { get; set; }
        [DisplayName("Compled")]
        public bool completed { get; set; }
        [DisplayName("Data complite")]
        public DateTime? completion_datetime { get; set; }
        [DisplayName("Stars")]
        public int? stars { get; set; }
        [DisplayName("Review")]
        public string review { get; set; }
       
        public int? promocode_id { get; set; }

        public user us { get; set; }
        [DisplayName("Promocode")]
        public promocode promo { get; set; }

    }
}