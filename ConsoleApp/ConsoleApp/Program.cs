namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var tanks = GetTanks();
            var units = GetUnits();
            var factories = GetFactories();

            Console.WriteLine($"Количество резервуаров: {tanks.Length}, установок: {units.Length}");

            var foundUnit = FindUnit(units, tanks, "Резервуар 2");
            var factory = FindFactory(factories, foundUnit);

            Console.WriteLine($"Резервуар 2 принадлежит установке {foundUnit.Name} и заводу {factory.Name}");

            Console.WriteLine($"Общая сумма загрузки всех резервуаров: {GetTotalVolume(tanks)}");
        }

        public static Factory[] GetFactories()
        {
            Factory[] factories = 
            {
                new Factory { 
                    Id = 1, 
                    Name = "НПЗ№1", 
                    Description = "Первый нефтеперерабатывающий завод" 
                },
                new Factory { 
                    Id = 2, 
                    Name = "НПЗ№2", 
                    Description = "Второй нефтеперерабатывающий завод" 
                }
            };

            return factories;
        }

        public static Tank[] GetTanks()
        {
            Tank[] tanks =
            {
                new Tank 
                { 
                    Id = 1, 
                    Name = "Резервуар 1", 
                    Description = "Надземный - вертикальный", 
                    Volume = 1500, 
                    MaxVolume = 2000, 
                    UnitId = 1
                },
                new Tank
                {
                    Id = 2,
                    Name = "Резервуар 2",
                    Description = "Надземный - горизонтальный",
                    Volume = 2500,
                    MaxVolume = 3000, 
                    UnitId = 1
                },
                new Tank
                {
                    Id = 3,
                    Name = "Дополнительный резервуар 24",
                    Description = "Надземный - горизонтальный",
                    Volume = 3000,
                    MaxVolume = 3000,
                    UnitId = 2
                },
                new Tank
                {
                    Id = 4,
                    Name = "Резервуар 35",
                    Description = "Надземный - вертикальный",
                    Volume = 3000,
                    MaxVolume = 3000,
                    UnitId = 2
                },
                new Tank
                {
                    Id = 5,
                    Name = "Резервуар 47",
                    Description = "Подземный - двустенный",
                    Volume = 4000,
                    MaxVolume = 5000,
                    UnitId = 2
                },
                new Tank
                {
                    Id = 6,
                    Name = "Резервуар 256",
                    Description = "Подводный",
                    Volume = 500,
                    MaxVolume = 500,
                    UnitId = 3
                }
            };

            return tanks;
        }

        public static Unit[] GetUnits()
        {
            Unit[] units = 
            { 
                new Unit 
                { 
                    Id = 1, 
                    Name = "ГФУ-2", 
                    Description = "Газофракционирующая установка",
                    FactoryId = 1
                },
                new Unit
                {
                    Id = 2,
                    Name = "АВТ-6",
                    Description = "Атмосферно-вакуумная трубчатка",
                    FactoryId = 1
                },
                new Unit
                {
                    Id = 3,
                    Name = "АВТ-10",
                    Description = "Атмосферно-вакуумная трубчатка",
                    FactoryId = 2
                }
            };

            return units;
        }

        public static Unit FindUnit(Unit[] units, Tank[] tanks, string unitName)
        {
            for (int i = 0; i < units.Length; i++)
            {
                for (int j = 0; j < tanks.Length; j++)
                {
                    if (tanks[j].Name == unitName && tanks[j].UnitId == units[i].Id)
                        return units[i];
                }
            }
            return new Unit();
        }

        public static Factory FindFactory(Factory[] factories, Unit unit)
        {
            for (int i = 0; i < factories.Length; i++)
            {
                if (factories[i].Id == unit.FactoryId)
                {
                    return factories[i];
                }
            }
            return new Factory();
        }

        public static int GetTotalVolume(Tank[] units)
        {
            int total = 0;

            for (int i = 0; i < units.Length; i++)
            {
                total += units[i].Volume;
            }
            return total;
        }
    }
}