using Microsoft.AspNetCore.Mvc;
using ModelBindingAndValidations.Models;

namespace ModelBindingAndValidations.Controllers
{
    [Route("order")]
    public class OrderController : Controller
    {
        public IActionResult Index(Order order)
        {
            if (!ModelState.IsValid)
            {
                string messageError = GetErrorsFromModelState();

                return BadRequest(messageError);
            }

            return Content($"New Order Number:{order.OrderNo}");
        }

        private string GetErrorsFromModelState()
        {
            var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage);

            var stringError = string.Join("\n", errors);

            return stringError;
        }
    }
}
