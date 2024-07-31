using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelBindingAndValidations.CustomValidators;

namespace ModelBindingAndValidations.Models
{
    public class Order : IValidatableObject
    {
        [BindNever]
        public int? OrderNo
        {
            get
            {
                Random random = new Random();
                return random.Next();
            }
        }
        [MinDateTimeValidator("2000-01-01")]
        public DateTime OrderDate { get; set; }
        [Required(ErrorMessage = "{0} can't be blank")]
        public double InvoicePrice { get; set; }
        [MinCountValidator(1)]
        public List<Product> Products { get; set; } = [];

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var totalValueProducts = Products.Sum(p => p.Quantity * p.Price);

            if (totalValueProducts != InvoicePrice)
            {
                yield return new ValidationResult("Invoice Price should be equal to the total cost of all products.");
            }
        }
    }
}
