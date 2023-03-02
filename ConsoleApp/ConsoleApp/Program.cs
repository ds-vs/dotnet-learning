namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var tanks = Facility.GetTanks();
            var units = Facility.GetUnits();
            var factories = Facility.GetFactories();

            Facility.Find(tanks, units, factories);

            Facility.ShowTotalVolume(tanks);
            Facility.ShowMaxVolume(tanks);
        }
    }
}