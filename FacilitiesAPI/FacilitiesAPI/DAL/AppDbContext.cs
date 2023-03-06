using System;
using FacilitiesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FacilitiesAPI.DAL
{
    public class AppDbContext: DbContext
    {
        public DbSet<TankEntity> Tanks { get; set; } = null!;
        public DbSet<UnitEntity> Units { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) 
        {  
            Database.EnsureCreated();
        }
    }
}