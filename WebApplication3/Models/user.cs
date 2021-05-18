using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    [Table("user")]
    public class user
    {
        public enum Role
        {
            customer,
            admin,
            manager,
            courier
        }

        [Key]
        public int user_id { get; set; }
        [DisplayName("Name")]
        public string username { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        [DisplayName("Email")]
        public string email { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]
        [DisplayName("Password")]
        public string password { get; set; }
        [DisplayName("Role")]
        public string role { get; set; }
        [DisplayName("Pnome number")]
        public string phone_number { get; set; }
       

    }
}