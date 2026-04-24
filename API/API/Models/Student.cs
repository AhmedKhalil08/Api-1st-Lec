using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Student
    {
        [Key]
        public int SSN { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string image { get; set; }

    }
}
