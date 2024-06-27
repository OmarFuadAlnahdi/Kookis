﻿using Kookis.Models;
using Kookis.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Kookis.Compponents
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartSummary(IShoppingCart shoppingCart) 
        { 
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke() 
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            
            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart,
                _shoppingCart.GetShoppingCartTotal());

            return View(shoppingCartViewModel);
        
        }
    }
}
