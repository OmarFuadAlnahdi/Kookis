using Kookis.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kookis.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository, IShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Checkout() //GET
        { 
            return View();
        
        }
        [HttpPost]
        public IActionResult Checkout(Order order) 
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            if(_shoppingCart.ShoppingCartItems.Count == 0) 
            {
                ModelState.AddModelError("", "Your Cart Is Empty please Add Some Fruit First!");
            
            }

            if (ModelState.IsValid) 
            { 
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }

            return View(order);
        
        }

        public IActionResult CheckoutComplete() 
        {
            ViewBag.CheckoutCompleteMessage = "thank you soo much i hope u enjoy with it see again soon! ";
            return View();
        }
    }
}
