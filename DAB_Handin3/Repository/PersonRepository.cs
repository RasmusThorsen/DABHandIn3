using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAB_Handin3.Models;

namespace Repository
{
    class PersonRepository : IRepository<Person>
    {
        private DAB_Handin3Context context;

        public PersonRepository(DAB_Handin3Context context)
        {
            this.context = context;
        }

        public IEnumerable<Person> GetAll()
        {
            return context.People.ToList();
        }

        public Person GetById(int id)
        {
            var pers = context.People.Find(id);
            return pers;
        }

        public void Insert(Person entity)
        {
            context.People.Add(entity);
        }

        public void Delete(int id)
        {
            context.People.Remove(context.People.Find(id) ?? throw new InvalidOperationException());
        }

        public void Update(Person entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
