using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Facilities;

namespace ConsoleApp
{
    /// <summary>
    /// Установка
    /// </summary>
    public class Unit: IFacility
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int FactoryId { get; set; }

        public void Print()
        {
            Console.WriteLine($"Номер: {Id} \nУстановка: {Name} \nОписание: {Description}");
        }
    }
}
