using PruebaMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace PruebaMvc.Data{
    public class PruebaMvcDbContext : DbContext{
        public PruebaMvcDbContext(DbContextOptions<PruebaMvcDbContext> options) : base(options){

        }

        public DbSet<User> Users {get; set; }
        public DbSet<Product> Products {get; set; }
    }
}