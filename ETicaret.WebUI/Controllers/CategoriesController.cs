using Microsoft.AspNetCore.Mvc;
using Eticaret.Data;
using Eticaret.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly DatabaseContext _context;

        public CategoriesController(DatabaseContext context)
        {
            _context = context;
        }

        // URL: /Categories/Index/3
        public IActionResult Index(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null) return NotFound();

            var products = _context.Products
                                   .Include(p => p.Category)
                                   .Where(p => p.CategoryId == id && p.IsActive)
                                   .ToList();

            ViewBag.CategoryName = category.Name;

            // Açıkça "categories.cshtml" dosyasını çağırıyoruz:
            return View("categories", products);
        }
    }
}
