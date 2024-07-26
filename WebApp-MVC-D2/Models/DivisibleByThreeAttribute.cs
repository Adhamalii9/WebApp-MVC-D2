using System.ComponentModel.DataAnnotations;

namespace WebApp_MVC_D2.Models
{
    public class DivisibleByThreeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var currentValue = (int)value;

            if (currentValue % 3 != 0)
                return new ValidationResult("Hours must be divisible by 3.");

            return ValidationResult.Success;
        }
    }
}
