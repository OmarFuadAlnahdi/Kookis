using System.ComponentModel.DataAnnotations;

namespace Kookis.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int ShoppingCardItemId { get; set; }
        public Pie Pie { get; set; } = default;
        public int Amount { get; set; }
        public string? ShoppingCartId { get; set; }


    }
}
