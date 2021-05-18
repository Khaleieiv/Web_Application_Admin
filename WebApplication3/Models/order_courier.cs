using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    [Table("order_courier")]
    public class order_courier
    {
        [Key]
        public int order_id { get; set; }
        [DisplayName("Courier name")]
        public int courier_id { get; set; }
        [ForeignKey("courier_id")]
        public user user { get; set; }
    }
}