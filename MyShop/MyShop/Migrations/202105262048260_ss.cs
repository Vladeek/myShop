namespace CourseProject_WPF_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ss : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Quntity", c => c.Int(nullable: false));
            AddColumn("dbo.Items", "Count", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "Count");
            DropColumn("dbo.Items", "Quntity");
        }
    }
}
