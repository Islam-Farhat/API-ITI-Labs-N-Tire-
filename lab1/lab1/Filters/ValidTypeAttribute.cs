using lab1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.RegularExpressions;

namespace lab1.Filters
{
    public class ValidTypeAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var car = context.ActionArguments["car"] as Car;
            var regex = new Regex("(Gas|Electric|Hybrid|Diesel)$",RegexOptions.IgnoreCase,TimeSpan.FromSeconds(2));

            if (car is null || !regex.IsMatch(car.Type))
            {
                context.ModelState.AddModelError("Type", "The type isn't existed");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
