using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace Kookis.Models
{
    
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public List<Pie>? Pies { get; set; }
    }
}
