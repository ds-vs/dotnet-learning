using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONParsing
{
    public record SumByMonth
    {
        public DateTime Month { get; init; }
        public int Sum { get; init; }   

        public SumByMonth(DateTime Month, int Sum) 
        { 
            this.Month = Month;
            this.Sum = Sum;
        }
    }
}
