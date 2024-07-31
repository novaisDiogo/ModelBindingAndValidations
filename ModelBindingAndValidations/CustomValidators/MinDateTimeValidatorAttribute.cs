using System.ComponentModel.DataAnnotations;

namespace ModelBindingAndValidations.CustomValidators
{
    public class MinDateTimeValidatorAttribute : ValidationAttribute
    {
        private readonly DateTime _minDate;
        public MinDateTimeValidatorAttribute(string minDate) => _minDate = DateTime.Parse(minDate);

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null && value is DateTime date)
            {
                if (date >= _minDate)
                    return ValidationResult.Success;
                else
                    return new ValidationResult($"{validationContext.DisplayName} must be on or after {_minDate.ToShortDateString()}.", [validationContext.DisplayName]);
            }

            return new ValidationResult($"{validationContext.DisplayName} can't be blank.", [validationContext.DisplayName]);
        }
    }
}
