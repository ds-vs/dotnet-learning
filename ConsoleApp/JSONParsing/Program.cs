using System;
using System.Collections.Generic;
using System.Text.Json;

namespace JSONParsing
{
    public class Program
    {
        static void Main(string[] args)
        {
            var deals = new List<Deal>();

            string filePath = "../../../JSON_sample_1.json";

            using (var fileReader = new StreamReader(filePath))
            {
                var jsonStrings = fileReader.ReadToEnd();

                deals = JsonSerializer.Deserialize<List<Deal>>(jsonStrings);
            }

            var numberStrings = GetNumbersOfDeals(deals!);

            Console.WriteLine($"Найдено значений: {numberStrings.Count}");

            Console.Write("Идентификаторы: ");

            Console.Write(string.Join(", ", numberStrings.Select(n => n)) + "\n\n");

            var sumByMonth = GetSumByMonths(deals!);

            foreach(var item in sumByMonth)
            {
                Console.WriteLine($"За {item.Month.ToString("Y")} сумма: {item.Sum}");
            }
        }

        static IList<string> GetNumbersOfDeals(IEnumerable<Deal> deals)
        {
            var filteredIDs = deals
                .Where(deal => deal.Sum >= 100)
                .OrderBy(deal => deal.Date)
                .Take(5)
                .OrderBy(deal => deal.Sum)
                .Select(deal => deal.Id)
                .ToList();

            return filteredIDs;
        }

        static IList<SumByMonth> GetSumByMonths(IEnumerable<Deal> deals)
        {
            var filteredSumByMonth = deals
                .GroupBy(deal => deal.Date.ToString("Y"))
                .Select(deal => new SumByMonth (Convert.ToDateTime(deal.Key), deal.Sum( s => s.Sum )))
                .ToList();

            return filteredSumByMonth;
        }
    }
}