using API.Context;
using API.Models;
using System.ComponentModel.DataAnnotations;

namespace API.Validators
{
    public class UniqueDepartmentNameAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var db = validationContext.GetService<APIContext>();
            var dept = validationContext.ObjectInstance as Department;
            var name = dept.Name;
            if (name != null)
            {
                var exists = db.Department.Any(x => x.Name == name);
                if(exists)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;

        }
    }
}
