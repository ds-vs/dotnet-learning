using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Facility
    {
        public static string filesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Data");

        /// <summary>
        /// Осуществляет вывод в консоль всех резервуаров, 
        /// включая имена цеха и фабрики, в которых они числятся.
        /// </summary>
        /// <param name="tanks"></param>
        /// <param name="units"></param>
        /// <param name="factories"></param>
        public static void Find(List<Tank> tanks, List<Unit> units, List<Factory> factories)
        {
            foreach (var tank in tanks)
            {
                try
                {
                    Unit foundUnit = FindUnit(units, tanks, tank.Name!);
                    Factory foundFactory = FindFactory(factories, foundUnit);

                    ShowFoundFacilities(tank, foundUnit, foundFactory);
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine($"Ошибка: {e.Message}");
                    break;
                }
            }
        }

        public static Unit FindUnit(IList<Unit> units, IList<Tank> tanks, string unitName)
        {
            for (int i = 0; i < units.Count; i++)
            {
                for (int j = 0; j < tanks.Count; j++)
                {
                    if (tanks[j].Name == unitName && tanks[j].UnitId == units[i].Id)
                        return units[i];
                }
            }
            return new Unit();
        }

        public static Factory FindFactory(IList<Factory> factories, Unit unit)
        {
            return factories.SingleOrDefault(f => f.Id == unit.FactoryId)!;
        }

        /// <summary>
        /// Получить значение загруженности резервуаров.
        /// </summary>
        /// <param name="units"></param>
        public static int GetTotalVolume(IEnumerable<Tank> units)
        {
            return units.Sum(u => u.Volume);
        }

        /// <summary>
        /// Получить максимальное возможное значение загрузки резервуаров.
        /// </summary>
        /// <param name="units"></param>
        public static int GetMaxVolume(IEnumerable<Tank> units)
        {
            return units.Sum(u => u.MaxVolume);
        }

        /// <summary>
        /// Осуществляет вывод в консоль общую сумму загрузки
        /// всех резервуаров.
        /// </summary>
        /// <param name="units"></param>
        public static void ShowTotalVolume(IEnumerable<Tank> units)
        {
            Console.WriteLine($"Общая сумма загрузки всех резервуаров: {GetTotalVolume(units)}");
        }

        /// <summary>
        /// Осуществляет вывод в консоль максимальную сумму загрузки
        /// всех резервуаров.
        /// </summary>
        /// <param name="units"></param>
        public static void ShowMaxVolume(IEnumerable<Tank> units)
        {
            Console.WriteLine($"Максимальная сумма загрузки всех резервуаров: {GetMaxVolume(units)}");
        }

        public static void ShowFoundFacilities(Tank tank, Unit foundUnit, Factory factory)
        {
            Console.WriteLine($"{tank.Name} принадлежит установке {foundUnit.Name} и заводу {factory.Name}");
        }

        /// <summary>
        /// Получить список заводов из файла Factories.json.
        /// </summary>
        public static List<Factory> GetFactories()
        {
            var filePath = Path.Combine(filesDirectory, "Factories.json");

            try
            {
                if(File.Exists(filePath))
                {
                    string jsonString = File.ReadAllText(filePath);

                    return JsonSerializer.Deserialize<List<Factory>>(jsonString)!;
                } 
                throw new Exception($"Файл {filePath} не найден.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Factory>();
            }
        }

        /// <summary>
        /// Получить список резервуаров из файла Tanks.json.
        /// </summary>
        public static List<Tank> GetTanks()
        {
            var filePath = Path.Combine(filesDirectory, "Tanks.json");

            try 
            {
                if (File.Exists(filePath))
                {    
                    var jsonString = File.ReadAllText(filePath);

                    return JsonSerializer.Deserialize<List<Tank>>(jsonString)!;
                } 
                throw new Exception($"Файл {filePath} не найден.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Tank>();
            }
        }

        /// <summary>
        /// Получить список установок из файла Unit.json.
        /// </summary>
        public static List<Unit> GetUnits()
        {
            var filePath = Path.Combine(filesDirectory, "Units.json");

            try 
            {
                if(File.Exists(filePath))
                {
                    var jsonString = File.ReadAllText(filePath);

                    return JsonSerializer.Deserialize<List<Unit>>(jsonString)!;
                } 
                throw new Exception($"Файл {filePath} не найден.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Unit>();
            }
        }
    }
}