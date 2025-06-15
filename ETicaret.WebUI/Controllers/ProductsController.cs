using Microsoft.AspNetCore.Mvc;
using Eticaret.Data;
using System.Linq;
using Eticaret.Core.Entities;

public class ProductsController : Controller
{
    private readonly DatabaseContext _context;

    public ProductsController(DatabaseContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Search(string q)
    {
        var products = string.IsNullOrWhiteSpace(q)
            ? new List<Product>()
            : _context.Products
                      .Where(p => p.Name.ToLower().Contains(q.ToLower()))
                      .ToList();

        ViewBag.Query = q;
        return View("Search", products); // <-- Search.cshtml kullanılıyor
    }
}
