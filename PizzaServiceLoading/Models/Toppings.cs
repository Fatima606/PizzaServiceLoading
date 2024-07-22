using System.ComponentModel.DataAnnotations;

namespace PizzaServiceLoading.Models
{
    public class Toppings
    {
        [Key]
        public int ToppingId { get; set; }
        public string ToppingName { get; set; }

    }
}
