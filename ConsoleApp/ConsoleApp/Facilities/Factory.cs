﻿using ConsoleApp.Facilities;

namespace ConsoleApp
{
    /// <summary>
    /// Завод
    /// </summary>
    public class Factory: IFacility
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
