using System.Data.Entity;

namespace CourseProject.Model
{
    class MyShopContext : DbContext
    {
        public DbSet<Item> Announcements { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        public MyShopContext() : base("MyShop")
        {
        }

        public static MyShopContext Instance { get; } = new MyShopContext();
    }
}