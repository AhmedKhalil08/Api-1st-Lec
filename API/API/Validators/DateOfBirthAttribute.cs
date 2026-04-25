using System.ComponentModel.DataAnnotations;

namespace API.Validators
{
    public class DateOfBirthAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var date = value as DateTime?;
            if(date.HasValue && date.Value >= DateTime.Now)
            {
                return new ValidationResult(ErrorMessage ?? "Date Must Be In Past");
            }
            return ValidationResult.Success;
            
        }
    }
}
