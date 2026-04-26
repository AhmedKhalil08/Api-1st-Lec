using API.Models;
using System.ComponentModel.DataAnnotations;

namespace API.Validators
{
    public class CompareAgeAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not DateTime date)
                return ValidationResult.Success;

            if (validationContext.ObjectInstance is not Student student)
                return ValidationResult.Success;

            var calculated = DateTime.Today.Year - date.Year;
            if (date.Date > DateTime.Today.AddYears(-calculated))
                calculated--;

            if (calculated != student.Age)
                return new ValidationResult(ErrorMessage ?? "Age Not Compatible");

            return ValidationResult.Success;
        }
    }
}
