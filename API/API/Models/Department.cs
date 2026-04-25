using API.Validators;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Department
    {
        [Key]
        public int DeptNumber { get; set; }

        [UniqueDepartmentName]
        public string Name { get; set; }

        public string Location { get; set; }
        // Relation With Students
        public List<Student>? Students { get; set; }
    }
}
