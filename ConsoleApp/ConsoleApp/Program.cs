using System.Text.Json;

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
            string fileName = "../../../Data/Factories.json";
            string jsonString = File.ReadAllText(fileName);

            var factories = JsonSerializer.Deserialize<Factory[]>(jsonString)!;

            return factories;
        }

        public static Tank[] GetTanks()
        {
            string fileName = "../../../Data/Tanks.json";
            string jsonString = File.ReadAllText(fileName);

            var tanks = JsonSerializer.Deserialize<Tank[]>(jsonString)!;

            return tanks;
        }

        public static Unit[] GetUnits()
        {
            string fileName = "../../../Data/Units.json";
            string jsonString = File.ReadAllText(fileName);

            var units = JsonSerializer.Deserialize<Unit[]>(jsonString)!;

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