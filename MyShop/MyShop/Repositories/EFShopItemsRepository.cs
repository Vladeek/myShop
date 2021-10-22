using CourseProject.Model;
using System.Collections.Generic;
using System.Linq;

namespace CourseProject.Repositories
{
    class EFItemsRepository : IAnnouncementRepository
    {
        private MyShopContext context = MyShopContext.Instance;

        public IEnumerable<Item> getAll()
        {
            return context.Announcements;
        }

        public void delete(Item shopItem)
        {
            context.Announcements.Remove(context.Announcements.FirstOrDefault(x => x.Id == shopItem.Id));
            context.SaveChanges();
        }

        public void update(Item oldshopItem, Item newshopItem)
        {
            var tmp = context.Announcements.FirstOrDefault(x => x.Id == oldshopItem.Id);

                if (tmp != null)
                {
                    tmp.Name = newshopItem.Name;
                    tmp.Category = newshopItem.Category;
                    tmp.Cost = newshopItem.Cost;
                    tmp.About = newshopItem.About;
                    tmp.BitmapImage = newshopItem.BitmapImage;
                }

            context.SaveChanges();
        }

        public void update(string name, int count)
        {
            var q = context.Announcements.FirstOrDefault(x => x.Name == name);
            q.Quntity = count;
            context.SaveChanges();
        }

        public void add(Item shopItem)
        {
            context.Announcements.Add(shopItem);
            context.SaveChanges();
        }

        public void AddOrder(int id, Order newValue)
        {
            var old = context.Announcements.FirstOrDefault(x => x.Id == id);
            if (old == null)
            {
                return;
            }

            old.Orders.Add(newValue);
            context.SaveChanges();
        }

        public Item getByName(string name)
        {
            return context.Announcements.FirstOrDefault(x => x.Name == name);
        }


        public IEnumerable<Item> getByCategory(string category)
        {
            return context.Announcements.Where(x => x.Category == category);
        }

        public List<string> getCategories()
        {
            List<string> tmp = new List<string>();

            foreach (Item announcement in context.Announcements)
                tmp.Add(announcement.Category);

            return tmp;
        }

        public decimal MaxCost()
        {
            return context.Announcements.Count() > 0 ? context.Announcements.Max(x => x.Cost).Value : 0;
        }
    }
}