using FIT_Api_Example.Modul2.Models;
using FIT_Api_Example.Modul3.Models;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Example.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Drzava> Drzava { get; set; }
        public DbSet<Opstina> Opstina { get; set; }
        public DbSet<Student> Student { get; set; }

        //Dodamo nove DbSetove:

        public DbSet<Predmet> Predmeti { get;set;}
        public DbSet<Ispit> Ispiti { get;set;}
        public DbSet<PrijavaIspita> PrijaveIspita { get;set;}
        public DbSet<Ocjena> Ocjene { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
