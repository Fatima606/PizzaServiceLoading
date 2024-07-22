using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PizzaServiceLoading.Models;
using PizzaServiceLoading.DbComtext;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace PizzaServiceLoading.Controllers
{
    public class HomeController : Controller
    {
        private readonly PizzaLoading _pizzaLoading;
        private static int _totalPizzasOrdered = 0;

        public HomeController(PizzaLoading pizzaLoading)
        {
            _pizzaLoading = pizzaLoading;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var bases = _pizzaLoading.Base.ToList();
            var toppings = _pizzaLoading.Toppings.ToList();
            var sizes = _pizzaLoading.Size.ToList();

            var viewModel = new PizzaView
            {
                Bases = bases.Select(b => new SelectListItem { Value = b.baseId.ToString(), Text = b.BaseName }).ToList(),
                Toppings = toppings.Select(t => new SelectListItem { Value = t.ToppingId.ToString(), Text = t.ToppingName }).ToList(),
                Sizes = sizes.Select(s => new SelectListItem { Value = s.SizeId.ToString(), Text = s.PizzaSize }).ToList()
            };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Index(PizzaView model)
        {

            var pizza = new Pizza
            {
                BaseId = model.BaseId,
                SizeId = model.SizeId
            };
            _pizzaLoading.Pizza.Add(pizza);
            _pizzaLoading.SaveChanges();
            foreach (var toppingId in model.ToppingIds)
            {
                var toppingsOrder = new ToppingOrder
                {
                    PizzaId = pizza.PizzaId,
                    ToppingId = toppingId
                };
                _pizzaLoading.ToppingOrder.Add(toppingsOrder);
                _pizzaLoading.SaveChanges();
            }
            var cust = new Customer
            {
                PizzaId = pizza.PizzaId
            };
            _pizzaLoading.Customer.Add(cust);
            _pizzaLoading.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult OrderSummary()
        {
            _totalPizzasOrdered = 0;
            var customers = _pizzaLoading.Customer
               .Include(c => c.Pizza)
               .ThenInclude(p => p.Size)
               .Include(c => c.Pizza)
               .ThenInclude(p => p._base)
               .ToList();
            var pizzaToppings = new Dictionary<int, List<Toppings>>();
            var pizzaDetails = new Dictionary<int, (string Size, string Base)>();

            foreach (var customer in customers)
            {
                var toppings = _pizzaLoading.ToppingOrder
                    .Where(to => to.PizzaId == customer.PizzaId)
                    .Select(to => to.Topping)
                    .ToList();

                pizzaToppings[customer.PizzaId] = toppings;

                var size = _pizzaLoading.Size
                    .FirstOrDefault(s => s.SizeId == customer.Pizza.SizeId).PizzaSize;


                var baseName = _pizzaLoading.Base
                    .FirstOrDefault(b => b.baseId == customer.Pizza.BaseId).BaseName;

                pizzaDetails[customer.PizzaId] = (Size: size, Base: baseName);
                
                _totalPizzasOrdered++;

            }

            ViewBag.TotalPizzasOrdered = _totalPizzasOrdered;
            ViewBag.Customers = customers;
            ViewBag.PizzaToppings = pizzaToppings;
            ViewBag.PizzaDetails = pizzaDetails;

            return View();
        }
        public IActionResult FamousToppings()
        {
            var pizzaToppings = new Dictionary<int, List<Toppings>>();
            var customers = _pizzaLoading.Customer
               .Include(c => c.Pizza)
               .ThenInclude(p => p.Size)
               .Include(c => c.Pizza)
               .ThenInclude(p => p._base)
               .ToList();
            foreach (var customer in customers)
            {
                var toppings = _pizzaLoading.ToppingOrder
                    .Where(to => to.PizzaId == customer.PizzaId)
                    .Select(to => to.Topping)
                    .ToList();

                pizzaToppings[customer.PizzaId] = toppings;


            }
            ViewBag.PizzaToppings = pizzaToppings;
            return View(customers);
        }
    }

}
