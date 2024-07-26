using System.ComponentModel.DataAnnotations;

namespace WebApp_MVC_D2.Models
{
    public class LessThanAttribute :  ValidationAttribute

    {
        
        private readonly string _comparisonProperty;

        public LessThanAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var currentValue = (int)value;

            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (property == null)
                throw new ArgumentException("Property with this name not found");

            var comparisonValue = (int)property.GetValue(validationContext.ObjectInstance);

            if (currentValue >= comparisonValue)
                return new ValidationResult($"MinDegree must be less than Degree.");

            return ValidationResult.Success;
        }
    
}
}
