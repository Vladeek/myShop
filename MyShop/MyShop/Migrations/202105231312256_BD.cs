namespace CourseProject_WPF_.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class BD : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Category = c.String(),
                    About = c.String(),
                    BitmapImage = c.Binary(),
                    Cost = c.Decimal(precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Orders",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserName = c.String(),
                    UserSecondName = c.String(),
                    TelNumber = c.String(),
                    Address = c.String(),
                    Email = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Users",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    FirstName = c.String(),
                    SecondName = c.String(),
                    Mail = c.String(),
                    Password = c.String(),
                    TelNumber = c.String(),
                    About = c.String(),
                    Image = c.Binary(),
                    Privilege = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.OrderItems",
                c => new
                {
                    Order_Id = c.Int(nullable: false),
                    Item_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Order_Id, t.Item_Id })
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.Item_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.Item_Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.OrderItems", "Order_Id", "dbo.Orders");
            DropIndex("dbo.OrderItems", new[] { "Item_Id" });
            DropIndex("dbo.OrderItems", new[] { "Order_Id" });
            DropTable("dbo.OrderItems");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.Items");
        }
    }
}
