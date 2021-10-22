using System.ComponentModel.DataAnnotations;

namespace CourseProject.Model
{
    public class User
    {
        [Key] public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string TelNumber { get; set; }
        public string About { get; set; }
        public byte[] Image { get; set; }
        public string Privilege { get; set; }
    }
}