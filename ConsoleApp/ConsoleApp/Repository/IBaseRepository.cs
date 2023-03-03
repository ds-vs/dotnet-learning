using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp.Repository
{
    public interface IBaseRepository<T>
    {
        void Create(T facility);
        T Get(int id);
        void Update(int id, T facility);
        void Delete(int id);
    }
}