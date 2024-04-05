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

        public async Task<IActionResult> Index(string search){
            var users = from user in _context.Users select user;
            users = users.OrderBy(u =>u.Names);
            if(!string.IsNullOrEmpty(search)){
                users = users.Where(u => u.Names.Contains(search));
            }
            return View(await users.ToArrayAsync());
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

        [HttpGet]
        public IActionResult Edit(int id){
            var user = _context.Users.Find(id);
            return View(user);
        }

        [HttpPost]
    public async Task <IActionResult> Editar(User user){
        if(ModelState.IsValid){
            _context.Update(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View();
    }

    }

}