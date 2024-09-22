using PusulaApp.Models;

public class CombinedViewModel
{
    public IEnumerable<Product> Products { get; set; } = null!;
    public IEnumerable<Sale> Sales { get; set; } = null!;

}
