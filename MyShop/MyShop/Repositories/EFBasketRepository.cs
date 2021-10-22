using CourseProject.Model;
using System.Collections.Generic;
using System.Linq;

namespace CourseProject_WPF_.Repositories
{
    public class EFOrderRepository
    {
        private MyShopContext _MyShopContext = MyShopContext.Instance;

        public void Add(Order basket)
        {
            _MyShopContext.Orders.Add(basket);
            _MyShopContext.SaveChanges();
        }

        public IEnumerable<Order> GetAll()
        {
            return _MyShopContext.Orders;
        }

        public void Remove(Order basket)
        {
            var entity = _MyShopContext.Orders.FirstOrDefault(x => x.Id == basket.Id);
            if (entity == null)
            {
                return;
            }

            _MyShopContext.Orders.Remove(entity);
            _MyShopContext.SaveChanges();
        }
    }
}