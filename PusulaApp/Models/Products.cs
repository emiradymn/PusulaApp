using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PusulaApp.Models
{
    public class Product
    {
        [Key]
        [DisplayName("ProductID")]
        public int ProductID { get; set; }

        [DisplayName("ProductName")]
        public string? ProductName { get; set; }

        [DisplayName("Price")]
        public decimal Price { get; set; }

        public ICollection<Sale> Sales { get; set; } = new List<Sale>(); // Navigation property ile ilişkilendirme
    }
}


