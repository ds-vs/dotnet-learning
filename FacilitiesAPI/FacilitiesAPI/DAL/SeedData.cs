using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FacilitiesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FacilitiesAPI.DAL
{
    public static class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder app)
        {
            AppDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();
            
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Factories.Any())
            {
                context.Factories.AddRange(
                    new Factory { Id = 1, Name = "НПЗ№1", Description = "Первый нефтеперерабатывающий завод" },
                    new Factory { Id = 2, Name = "НПЗ№2", Description = "Второй нефтеперерабатывающий завод" }
                );
                context.SaveChanges();
            }

            if (!context.Units.Any())
            {
                context.Units.AddRange(
                    new Unit { Id = 1, Name = "ГФУ-2", Description = "Газофракционирующая установка", FactoryId = 1 },
                    new Unit { Id = 2, Name = "АВТ-6", Description = "Атмосферно-вакуумная трубчатка", FactoryId = 1 },
                    new Unit { Id = 3, Name = "АВТ-10", Description = "Атмосферно-вакуумная трубчатка", FactoryId = 2 }
                );
                context.SaveChanges();
            }

            if (!context.Tanks.Any())
            {
                context.Tanks.AddRange(
                    new Tank { Id = 1, Name = "Резервуар 1", Description = "Надземный - вертикальный", Volume = 1500, MaxVolume = 2000, UnitId = 1 },
                    new Tank { Id = 2, Name = "Резервуар 2", Description = "Надземный - горизонтальный", Volume = 2500, MaxVolume = 3000, UnitId = 1 },
                    new Tank { Id = 3, Name = "Дополнительный резервуар 24", Description = "Надземный - горизонтальный", Volume = 3000, MaxVolume = 5000, UnitId = 2 },
                    new Tank { Id = 4, Name = "Резервуар 35", Description = "Надземный - вертикальный", Volume = 3000, MaxVolume = 3000, UnitId = 2 },
                    new Tank { Id = 5, Name = "Резервуар 47", Description = "Подземный - двустенный", Volume = 4000, MaxVolume = 5000, UnitId = 2 },
                    new Tank { Id = 6, Name = "Резервуар 256", Description = "Подводный", Volume = 500, MaxVolume = 500, UnitId = 3 }                   
                );
                context.SaveChanges();
            }
        }
    }
}