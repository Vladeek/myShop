namespace CourseProject_WPF_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qq : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Sum", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Sum");
        }
    }
}
