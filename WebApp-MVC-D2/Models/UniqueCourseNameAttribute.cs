using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using WebApp_MVC_D2.Models;

public class UniqueCourseNameAttribute : ValidationAttribute
{
    ITIDbContext context = new ITIDbContext();
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        

        var entity = context.Courses.SingleOrDefault(e => e.Name == value.ToString());

        if (entity != null)
        {
            return new ValidationResult("Course name must be unique.");
        }

        return ValidationResult.Success;
    }
}
