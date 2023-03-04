using System;
using FacilitiesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FacilitiesAPI.DAL
{
    public class AppDbContext: DbContext
    {
        public DbSet<Factory> Factories { get; set; } = null!;
        public DbSet<Tank> Tanks { get; set; } = null!;
        public DbSet<Unit> Units { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) 
        {  
            Database.EnsureCreated();
        }
    }
}