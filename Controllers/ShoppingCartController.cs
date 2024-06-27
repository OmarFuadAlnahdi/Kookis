using Kookis.Models;
using Kookis.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Kookis.Controllers
{
    public class ShoppingCartController : Controller
    {
        private IPieRepository _PieRepository;
        private IShoppingCart _shoppingCart;

        public ShoppingCartController (IPieRepository pieRepository, IShoppingCart shoppingCart)
        {
            _PieRepository = pieRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shopingCartViewModel = new ShoppingCartViewModel(_shoppingCart,
                _shoppingCart.GetShoppingCartTotal());

            return View(shopingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int pieId) 
        {
            var selectedPie = _PieRepository.AllPies.FirstOrDefault(p =>  p.PieId == pieId);
            if (selectedPie != null) 
                _shoppingCart.AddToCart(selectedPie);

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int pieId)
        {
            var selectedPie = _PieRepository.AllPies.FirstOrDefault(p => p.PieId == pieId);
            if (selectedPie != null)
                _shoppingCart.RemoveFromCart(selectedPie);

            return RedirectToAction("Index");
        }
    }
}
