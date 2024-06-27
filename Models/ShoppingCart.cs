using Microsoft.EntityFrameworkCore;

namespace Kookis.Models
{
        public class ShoppingCart : IShoppingCart
        {
            private readonly KookisDbContext _KookisPieShopDbContext;

            public string? ShoppingCartId { get; set; }

            public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;

            private ShoppingCart(KookisDbContext kookisPieShopDbContext)
            {
                _KookisPieShopDbContext = kookisPieShopDbContext;
            }

            public static ShoppingCart GetCart(IServiceProvider services)
            {
                ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

                KookisDbContext context = services.GetService<KookisDbContext>() ?? throw new Exception("Error initializing");

                string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

                session?.SetString("CartId", cartId);

                return new ShoppingCart(context) { ShoppingCartId = cartId };
            }

            public void AddToCart(Pie pie)
            {
            var shoppingCartItem =
                    _KookisPieShopDbContext.ShoppingCartItems.SingleOrDefault
                    (s => s.Pie.PieId == pie.PieId && s.ShoppingCartId ==
                    ShoppingCartId);

                if (shoppingCartItem == null)
                {
                    shoppingCartItem = new ShoppingCartItem
                    {
                        ShoppingCartId = ShoppingCartId,
                        Pie = pie,
                        Amount = 1
                    };

                _KookisPieShopDbContext.ShoppingCartItems.Add(shoppingCartItem);
                }
                else
                {
                    shoppingCartItem.Amount++;
                }
            _KookisPieShopDbContext.SaveChanges();
            }

            public int RemoveFromCart(Pie pie)
            {
                var shoppingCartItem =
                        _KookisPieShopDbContext.ShoppingCartItems.SingleOrDefault(
                            s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId);

                var localAmount = 0;

                if (shoppingCartItem != null)
                {
                    if (shoppingCartItem.Amount > 1)
                    {
                        shoppingCartItem.Amount--;
                        localAmount = shoppingCartItem.Amount;
                    }
                    else
                    {
                        _KookisPieShopDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                    }
                }

                    _KookisPieShopDbContext.SaveChanges();

                return localAmount;
            }

            public List<ShoppingCartItem> GetShoppingCartItems()
            {
                return ShoppingCartItems ??=
                           _KookisPieShopDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                               .Include(s => s.Pie)
                               .ToList();
            }

            public void ClearCart()
            {
                var cartItems = _KookisPieShopDbContext
                    .ShoppingCartItems
                    .Where(cart => cart.ShoppingCartId == ShoppingCartId);

                _KookisPieShopDbContext.ShoppingCartItems.RemoveRange(cartItems);

                _KookisPieShopDbContext.SaveChanges();
            }

            public decimal GetShoppingCartTotal()
            {
                var total = _KookisPieShopDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                    .Select(c => c.Pie.Price * c.Amount).Sum();
                return total;
            }

       
    }


    }

