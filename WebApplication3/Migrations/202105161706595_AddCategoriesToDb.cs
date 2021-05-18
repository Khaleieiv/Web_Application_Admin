namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoriesToDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.product_category",
                c => new
                    {
                        category_id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.category_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.product_category");
        }
    }
}
