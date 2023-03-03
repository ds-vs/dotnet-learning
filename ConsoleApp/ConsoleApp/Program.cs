using ConsoleApp.Repository;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var factory = new Factory();
            factory.Id = 7;
            factory.Name = "test";
            factory.Description = "desc";

            var factoryRepository = new FactoryRepository();
       
            Console.WriteLine("1. Добавить / 2. Получить / 3. Удалить");

            while(true)
            {
                int key = int.Parse(Console.ReadLine()!);

                switch(key)
                {
                    case 1:
                        factoryRepository.Create(factory);
                        break;
                    case 2:
                        factoryRepository.Get(7).Print();
                        break;
                    case 3:
                        factoryRepository.Delete(7);
                        break;
                    default:
                        return; 
                }
            }
        }
    }
}