using CourseProject.Model;
using System.Collections.Generic;

namespace CourseProject.Repositories
{
    public interface IAnnouncementRepository
    {
        IEnumerable<Item> getAll();
        void delete(Item shopItem);
        void add(Item shopItem);
        Item getByName(string name);
        IEnumerable<Item> getByCategory(string category);
        List<string> getCategories();
    }
}
