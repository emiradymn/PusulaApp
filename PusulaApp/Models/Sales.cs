using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PusulaApp.Models

{
    public class Sale
    {
        [Key]
        [DisplayName("Satış ID")]
        public int SaleID { get; set; }

        [DisplayName("Ürün ID")]
        public int ProductID { get; set; }

        [DisplayName("Miktar")]
        public int Quantity { get; set; }

        [DisplayName("Satış Tarihi")]
        public DateTime SaleDate { get; set; }

        public Product Product { get; set; } = null!;  // Navigation property ile ilişkilendirme
    }
}