namespace Kookis.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly KookisDbContext _kookisDbcontext;
        private readonly IShoppingCart _shoppingCart;

        public OrderRepository(KookisDbContext kookisDbContext, IShoppingCart shoppingCart)
        {
            _kookisDbcontext = kookisDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();

            //adding the order with its details

            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    PieId = shoppingCartItem.Pie.PieId,
                    Price = shoppingCartItem.Pie.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            _kookisDbcontext.Orders.Add(order);

            _kookisDbcontext.SaveChanges();
        }
    }

}

