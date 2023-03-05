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

            if (!context.Units.Any())
            {
                context.Units.AddRange(
                    new Unit { Name = "ГФУ-2", Description = "Газофракционирующая установка" },
                    new Unit { Name = "АВТ-6", Description = "Атмосферно-вакуумная трубчатка" },
                    new Unit { Name = "АВТ-10", Description = "Атмосферно-вакуумная трубчатка" }
                );
                context.SaveChanges();
            }

            if (!context.Tanks.Any())
            {
                context.Tanks.AddRange(
                    new Tank { Name = "Резервуар 1", Description = "Надземный - вертикальный", Volume = 1500, MaxVolume = 2000, UnitId = 1 },
                    new Tank { Name = "Резервуар 2", Description = "Надземный - горизонтальный", Volume = 2500, MaxVolume = 3000, UnitId = 1 },
                    new Tank { Name = "Дополнительный резервуар 24", Description = "Надземный - горизонтальный", Volume = 3000, MaxVolume = 5000, UnitId = 2 },
                    new Tank { Name = "Резервуар 35", Description = "Надземный - вертикальный", Volume = 3000, MaxVolume = 3000, UnitId = 2 },
                    new Tank { Name = "Резервуар 47", Description = "Подземный - двустенный", Volume = 4000, MaxVolume = 5000, UnitId = 2 },
                    new Tank { Name = "Резервуар 256", Description = "Подводный", Volume = 500, MaxVolume = 500, UnitId = 3 }                   
                );
                context.SaveChanges();
            }
        }
    }
}