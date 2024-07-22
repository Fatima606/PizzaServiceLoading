using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaServiceLoading.Models
{
    public class ToppingOrder
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Pizza")]
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
        [ForeignKey("Toppings")]
        public int ToppingId { get; set; }
        public Toppings Topping { get; set; }
        //public ICollection<Pizza> pizza { get; set; }

    }
}
