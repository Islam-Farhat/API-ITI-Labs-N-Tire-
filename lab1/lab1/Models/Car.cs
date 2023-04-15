using lab1.Validations;
using System.ComponentModel.DataAnnotations;
namespace lab1.Models
{
    public class Car
    {
        public int Id { get; set; }
        [StringLength(10,MinimumLength =1,ErrorMessage ="{0} bust be between {2} and {1}")]
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        [DateValidation]
        public DateTime ProductDate { get; set; }
        public Car()
        {
            
        }
        public Car(int id, string name, string type, DateTime date)
        {
            this.Id = id;
            this.Name = name;
            this.Type = type;
            this.ProductDate = date;
        }

    }
}
