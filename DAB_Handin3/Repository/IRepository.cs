using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository<T> : IDisposable
    {
        IQueryable<T> GetAll(); 
        T GetById(int id);
        void Insert(T entity);
        void Delete(int id);
        void Update(T entity);
        void Save();
    }

}
