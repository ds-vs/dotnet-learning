﻿using System.Text.Json;

namespace ConsoleApp
{
    public class Program
    {
        static string filesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        static void Main(string[] args)
        {
            var tanks = new List<Tank>();
            var units = new List<Unit>();
            var factories = new List<Factory>();

            try 
            {
                tanks = GetTanks();
                units = GetUnits();
                factories = GetFactories();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            foreach (var tank in tanks)
            {
                var foundUnit = FindUnit(units, tanks, tank.Name!);
                var factory = FindFactory(factories, foundUnit);

                Console.WriteLine($"{tank.Name} принадлежит установке {foundUnit.Name} и заводу {factory.Name}");
            }

            Console.WriteLine($"Общая сумма загрузки всех резервуаров: {GetTotalVolume(tanks)}");
        }

        public static List<Factory> GetFactories()
        {
            var filePath = Path.Combine(filesDirectory, "Factories.json");

            if(File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);

                return JsonSerializer.Deserialize<List<Factory>>(jsonString)!;
            }
            throw new Exception($"Файл {filePath} не найден.");
        }

        public static List<Tank> GetTanks()
        {
            var filePath = Path.Combine(filesDirectory, "Tanks.json");

            if (File.Exists(filePath))
            {    
                var jsonString = File.ReadAllText(filePath);

                return JsonSerializer.Deserialize<List<Tank>>(jsonString)!;
            } 
            throw new Exception($"Файл {filePath} не найден.");
        }

        public static List<Unit> GetUnits()
        {
            var filePath = Path.Combine(filesDirectory, "Units.json");

            if(File.Exists(filePath))
            {
                var jsonString = File.ReadAllText(filePath);

                return JsonSerializer.Deserialize<List<Unit>>(jsonString)!;
            } 
            throw new Exception($"Файл {filePath} не найден.");
        }

        public static Unit FindUnit(List<Unit> units, List<Tank> tanks, string unitName)
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

        public static Factory FindFactory(List<Factory> factories, Unit unit)
        {
            for (int i = 0; i < factories.Count; i++)
            {
                if (factories[i].Id == unit.FactoryId)
                {
                    return factories[i];
                }
            }
            return new Factory();
        }

        public static int GetTotalVolume(List<Tank> units)
        {
            int total = 0;

            for (int i = 0; i < units.Count; i++)
            {
                total += units[i].Volume;
            }
            return total;
        }
    }
}