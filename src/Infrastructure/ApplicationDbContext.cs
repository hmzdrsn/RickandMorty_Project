using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql("User ID=postgres;Password=test;Host=localhost;Port=5432;Database=TK_DB;");
            optionsBuilder.UseSqlServer("Server=localhost;Database=RickandMorty_DB;TrustServerCertificate=true;integrated security=true");
            //optionsBuilder.UseSqlServer();
        }
        public DbSet<Character> Character { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Location>Locations { get; set; }
        public DbSet<Origin>Origins{ get; set; }
    }
}
