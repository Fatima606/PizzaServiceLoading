using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace PizzaServiceLoading.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [ForeignKey("Pizza")]
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }

    }
}
