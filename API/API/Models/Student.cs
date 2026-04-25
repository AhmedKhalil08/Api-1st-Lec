using API.Validators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Student
    {
        [Key]
        public int SSN { get; set; }
        [MaxLength(15,ErrorMessage ="Max Length Allowed 15")]
        [MinLength(3,ErrorMessage ="Min Length Allowed 3")]
        public string Name { get; set; }
        [Range(18,22,ErrorMessage ="Age Between 18 -22")]
        public int Age { get; set; }

        public string Address { get; set; }
        [RegularExpression(@".*\.(jpg|png)$", ErrorMessage = " Only .jpg / .png Are Allowed ")]

        public string image { get; set; }
        [CompareAge]
        [DateOfBirth]
        public DateTime? DateOfBirth { get; set; }

        /*   Relation With Department     */
        [ForeignKey(nameof(Department))]
        public int? DeptId { get; set; }
        public Department? Department { get; set; }

    }
}
