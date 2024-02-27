using Day1.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Day1.Custom_Validation
{
    public class DepartmentAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var departmentService = (DepartmentRepo)validationContext.GetService(typeof(DepartmentRepo));

            var existingDepartment = departmentService.GetByName(value.ToString());

            if (existingDepartment != null)
            {
                return new ValidationResult("Department name must be unique.");
            }

            return ValidationResult.Success;
        }
    }
}
