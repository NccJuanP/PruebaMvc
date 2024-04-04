using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PruebaMvc.Data;
using PruebaMvc.Models;

namespace PruebaMvc.Controllers{
    public class UsersController : Controller{
        private readonly PruebaMvcDbContext _context;

        public UsersController(PruebaMvcDbContext context){
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(){
            return View(await _context.Users.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string buscar){
            Console.WriteLine(buscar);
                var users = await _context.Users.FirstOrDefaultAsync(m => m.Names == buscar);
                return View(users);
        }

    [HttpGet]
        public IActionResult Detaills(int? id){
            if(id == null){
                return NotFound();
            }
            var user = _context.Users.Find(id);

            if(user == null){
                return NotFound();
            }

            return View(user);
        }

        [HttpGet]
        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user){
            Console.WriteLine(ModelState.IsValid);
            
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            
        }

    }

}