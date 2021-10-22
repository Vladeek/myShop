using CourseProject.Model;
using System.Collections.Generic;

namespace CourseProject.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        void Add(User user);
        User GetByMail(string name);
        User GetById(int? id);
        void Update(User oldUser, User newUser);
        List<string> GetAllNames();
        void ChangePrivilege(User user, string privilege);
    }
}
