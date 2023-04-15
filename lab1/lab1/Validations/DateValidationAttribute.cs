using System.ComponentModel.DataAnnotations;
namespace lab1.Validations
{
    public class DateValidationAttribute:ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return value is DateTime date && date <= DateTime.Now;
        }
    }
}
