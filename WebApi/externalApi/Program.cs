using Dadata;
using Dadata.Model;

namespace externalApi
{
    public class Program
    {
        static readonly string token = String.Empty;

        static async Task Main(string[] args)
        {
            Console.WriteLine("Введите ИНН организации");
            Console.Write(": ");
            var inn = Console.ReadLine();

            try
            {
                var api = new SuggestClientAsync(token);
                var result = await api.FindParty(inn);

                Console.WriteLine(result.suggestions[0].data.name.full);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}