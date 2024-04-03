using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaMvc.Data;
using PruebaMvc.Models;

namespace PruebaMvc.Controllers{
    public class UsersController : Controller{
        private readonly PruebaMvcDbContext _context;

        public UsersController(PruebaMvcDbContext context){
            _context = context;
        }

        public async Task<IActionResult> Index(){
            return View(await _context.Users.ToListAsync());
        }

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
    }
}