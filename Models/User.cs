using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PruebaMvc.Models{
    public class User{
        [Key]
        public int Id { get; set; }
        public string Names { get; set; }
        public string LastNames { get; set; }
        public string Email { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
    }
}