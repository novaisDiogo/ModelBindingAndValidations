using System.ComponentModel.DataAnnotations;

namespace ModelBindingAndValidations.Models
{
    public class Order
    {
        public int? OrderNo
        {
            get
            {
                Random random = new Random();
                return random.Next();
            }
        }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public double InvoicePrice { get; set; }
        
        public List<Product>? Products { get; set; }
    }
}
