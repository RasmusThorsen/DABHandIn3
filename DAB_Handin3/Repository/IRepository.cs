using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandIn2._2_Relation_Database.Application
{
    public interface IRepository<T> : IDisposable
    {
        IEnumerable<T> GetAll(); 
        T GetById(int id);
        void Insert(T entity);
        void Delete(int id);
        void Update(T entity);
        void Save();
    }

}
