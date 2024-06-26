using Kookis.Models;

namespace Kookis.ViewModels
{
    public class ShoppingCardViewModel
    {
        public ShoppingCardViewModel(IShoppingCart shoppingCart, decimal shoppingCartTotal) 
        {
            ShoppingCart = shoppingCart;
            ShoppingCartTotal = shoppingCartTotal;
        }
        public IShoppingCart ShoppingCart { get; }
        public decimal ShoppingCartTotal { get; }
    }
}
