using System.ComponentModel.DataAnnotations;

namespace ModelBindingAndValidations.Models
{
    public class Product : IValidatableObject
    {
        [Required(ErrorMessage = "{0} can't be blank")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} should be between a valid number")]
        public int ProductCode { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        [Range(1, double.MaxValue, ErrorMessage = "{0} should be between a valid number")]
        public double? Price { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} should be between a valid number")]
        public int Quantity { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var properties = GetType().GetProperties();
            foreach (var property in properties)
            {
                var value = property.GetValue(this);
                if (value == null)
                {
                    yield return new ValidationResult($"{property.Name} is required.");
                    continue;
                }

                if (property.PropertyType == typeof(int) && (int)value == 0)
                {
                    yield return new ValidationResult($"{property.Name} is required.");
                }
            }
        }
    }
}
