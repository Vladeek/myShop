using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseProject.Model
{
    public class Order
    {
       
        [Key] public int Id { get; set; }
        public string UserName { get; set; }
        public string UserSecondName { get; set; }
        public string TelNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Sum { get; set; }
        public virtual ICollection<Item> Items { get; set; }

        public Order()
        {
            Items = new List<Item>();
        }
    }
}