using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace PizzaServiceLoading.Models
{

    public class Pizza
    {
        [Key]
        public int PizzaId { get; set; }

        [ForeignKey("Size")]
        public int SizeId { get; set; }
        public Size Size { get; set; }

        //public ICollection<Customer> Customer { get; set; }


        //[ForeignKey("ToppingOrder")]
        //public int ToppingOrderId { get; set; }
        //public ToppingOrder ToppingOrder { get; set; }

        [ForeignKey("Base")]
        public int BaseId { get; set; }
        public Base _base { get; set; }

    }
}
