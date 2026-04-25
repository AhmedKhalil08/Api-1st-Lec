using API.Models;
using System.ComponentModel.DataAnnotations;

namespace API.Validators
{
    public class CompareAgeAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var date = value as DateTime?;
            var student = validationContext.ObjectInstance as Student;
            var calculated = DateTime.Today.Year - date.Value.Year;
            if (calculated != student.Age)
            {
                return new ValidationResult(ErrorMessage ?? "Age Not Compatable");
            }
            return ValidationResult.Success;
        }
    }
}
