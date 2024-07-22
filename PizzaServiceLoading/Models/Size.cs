using System.ComponentModel.DataAnnotations;

namespace PizzaServiceLoading.Models
{
    public class Size
    {
        [Key]
        public int SizeId { get; set; }
        public string PizzaSize { get; set; }
        //public ICollection<Pizza> pizza { get; set; }
    }
}
