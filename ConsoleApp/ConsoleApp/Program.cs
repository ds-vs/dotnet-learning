using ConsoleApp.Repository;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var factory = new FactoryRepository();

            var factories = factory.GetAll();
            var tanks = Facility.GetTanks();
            var units = Facility.GetUnits();

            Facility.Find(tanks, units, factories);
            Facility.GetTotalVolume(tanks);
            Facility.GetMaxVolume(tanks);

            factory.Create(new Factory 
            { 
                Id = 3, 
                Name = "НПЗ№3", 
                Description = "Третий нефтеперерабатывающий завод"
            });
            factory.Get(3).Print();
            factory.Delete(3);
        }
    }
}