using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp.Facilities
{
    public interface IFacility
    {
        int Id { get; set; }
        string? Name { get; set; }
        string? Description { get; set; }
        void Print();
    }
}