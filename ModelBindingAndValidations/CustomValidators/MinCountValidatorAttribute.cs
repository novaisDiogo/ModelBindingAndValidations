using ModelBindingAndValidations.Models;
using System.ComponentModel.DataAnnotations;

namespace ModelBindingAndValidations.CustomValidators
{
    public class MinCountValidatorAttribute : ValidationAttribute
    {
        private readonly int _minCount;
        public MinCountValidatorAttribute(int minCount) => _minCount = minCount;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) { return null; }

            if (value is List<Product> list)
            {
                if (list.Count >= _minCount)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult($"The {validationContext.MemberName} list must contain at least {_minCount} items.", [validationContext.DisplayName]);
                }
            }

            return new ValidationResult("Invalid data type.", [validationContext.DisplayName]);
        }
    }
}
