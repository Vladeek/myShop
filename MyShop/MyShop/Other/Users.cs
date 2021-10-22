using CourseProject.Model;

namespace CourseProject.Other
{
    public static class UsersHelper
    {
        public static bool IsAdmin(this User user)
        {
            return user.Privilege == "admin";
        }
    }
}