using CourseProject.Model;
using CourseProject.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace CourseProject_WPF_.Repositories
{
    internal class EfUserRepository : IUserRepository
    {
        private readonly MyShopContext _context = MyShopContext.Instance;

        public List<string> GetAllNames()
        {
            return _context.Users.Select(s => s.FirstName).ToList();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Delete(User user)
        {
            try
            {
                _context.Users.Remove(_context.Users.FirstOrDefault(x => x.Id == user.Id));
                _context.SaveChanges();
            }
            catch { }
        }

        public User GetByMail(string mail)
        {
            return _context.Users.FirstOrDefault(x => x.Mail == mail);
        }

        public User GetByName(string name)
        {
            return _context.Users.FirstOrDefault(x => (x.FirstName + " " + x.SecondName) == name);
        }

        public User GetById(int? id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public void Update(User oldUser, User newUser)
        {
            var tmp = _context.Users.FirstOrDefault(x => x.Id == oldUser.Id);

            if (tmp != null)
            {
                tmp.FirstName = newUser.FirstName;
                tmp.SecondName = newUser.SecondName;
                tmp.Mail = newUser.Mail;
                tmp.About = newUser.About;
                tmp.Image = newUser.Image;
                tmp.TelNumber = newUser.TelNumber;
            }

            _context.SaveChanges();
        }

        public void ChangePrivilege(User user, string privilege)
        {
            var userTarget = _context.Users.FirstOrDefault(x => x.Id == user.Id);
            if (userTarget != null)
            {
                userTarget.Privilege = privilege;
            }

            _context.SaveChanges();
        }
    }
}