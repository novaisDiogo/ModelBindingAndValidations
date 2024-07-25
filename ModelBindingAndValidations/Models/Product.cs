using System.ComponentModel.DataAnnotations;

namespace ModelBindingAndValidations.Models
{
    public class Product : IValidatableObject
    {
        public int ProductCode { get; set; }
        
        public double? Price { get; set; }
        
        public int Quantity { get; set; }

        //Custom required value
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
