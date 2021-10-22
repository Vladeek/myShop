using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseProject.Model
{
    public class Item
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string About { get; set; }

        public byte[] BitmapImage { get; set; }
        public decimal? Cost { get; set; }
        public int Quntity { get; set; }
        public int Count { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public Item()
        {
            Orders = new List<Order>();
        }
    }
}