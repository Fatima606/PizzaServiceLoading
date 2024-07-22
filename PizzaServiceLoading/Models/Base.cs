using System.ComponentModel.DataAnnotations;

namespace PizzaServiceLoading.Models
{
    public class Base
    {
        [Key]
        public int baseId { get; set; }
        public string BaseName { get; set; }
        //public ICollection<Pizza> Pizza { get; set; }
    }
}
