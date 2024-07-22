using Microsoft.AspNetCore.Mvc.Rendering;

namespace PizzaServiceLoading.Models
{
    public class PizzaView
    {
        public int BaseId { get; set; }
        public List<int> ToppingIds { get; set; } = new List<int>();
        public int SizeId { get; set; }
        public List<SelectListItem> Bases { get; set; }
        public List<SelectListItem> Toppings { get; set; }
        public List<SelectListItem> Sizes { get; set; }
      
    }
}
