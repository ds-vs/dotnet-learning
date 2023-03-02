using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Facilities;

namespace ConsoleApp
{
    /// <summary>
    /// Резервуар
    /// </summary>
    public class Tank: IFacility
    {
        public int Id { get; set; }
        public string? Name { get; set; }   
        public string? Description { get; set; }
        public int Volume { get; set; }
        public int MaxVolume { get; set; }
        public int UnitId { get; set; }

        public void Print()
        {
            Console.WriteLine($"Номер: {Id} \nРезервуар: {Name} \nОписание: {Description}");
            Console.WriteLine($"\nЗагруженность резервуара: {Volume} \nМаксимальный объем: {MaxVolume}");
        }
    }
}
