using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public class ApplicationDbContext : DbContext
    {
       
        public ApplicationDbContext() : base("name=DefaultConnection") {

        }
        public DbSet<product_category> category { get; set;}
        public DbSet<product> product { get; set; }
        public DbSet<user> user { get; set; }

        public System.Data.Entity.DbSet<WebApplication3.Models.promocode> promocodes { get; set; }

        public System.Data.Entity.DbSet<WebApplication3.Models.order_products> order_products { get; set; }

        public System.Data.Entity.DbSet<WebApplication3.Models.delivery_order> delivery_order { get; set; }

        public System.Data.Entity.DbSet<WebApplication3.Models.order_courier> order_courier { get; set; }
    }
}