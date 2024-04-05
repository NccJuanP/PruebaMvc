using PruebaMvc.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PruebaMvc.Controllers{
    public class ProductsController : Controller{
        private readonly PruebaMvcDbContext _context;
        public ProductsController(PruebaMvcDbContext context){
            _context = context;
        }
        public async Task<IActionResult> Index(){
            return View(await _context.Products.ToListAsync());
        }

            public IActionResult Detaills(int? id){
        if(id == null){
            return NotFound();
        }
        var product = _context.Products.Find(id);

        if(product == null){
            return NotFound();
        }

        return View(product);
    }
    }
}