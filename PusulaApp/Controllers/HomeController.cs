using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PusulaApp.Data;


namespace PusulaApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            var sales = await _context.Sales.ToListAsync();
            var salesData = await _context.Products
                                          .Include(p => p.Sales)
                                          .Select(p => new
                                          {
                                              ProductName = p.ProductName,
                                              TotalSalesAmount = Math.Round(p.Sales.Sum(s => (decimal)s.Quantity * p.Price), 2),
                                              TotalSalesCount = p.Sales.Sum(s => s.Quantity)
                                          })
            .ToListAsync();

            ViewBag.SalesData = salesData;

            var highSalesProduct = salesData
                                        .OrderByDescending(sd => sd.TotalSalesAmount)
                                        .FirstOrDefault();

            ViewBag.HighSalesProduct = highSalesProduct;

            var model = new CombinedViewModel
            {
                Products = products,
                Sales = sales
            };

            return View(model);
        }
    }
}
