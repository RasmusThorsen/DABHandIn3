using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandIn2._2_Relation_Database.Application
{
    class PersonRepository : IRepository<Person>
    {
        private PersonKartotekContext context;

        public PersonRepository(PersonKartotekContext context)
        {
            this.context = context;
        }

        public IEnumerable<Person> GetAll()
        {
            return context.Persons.ToList();
        }

        public Person GetById(int id)
        {
            var pers = context.Persons.Find(id);
            return pers;
        }

        public void Insert(Person entity)
        {
            context.Persons.Add(entity);
        }

        public void Delete(int id)
        {
            context.Persons.Remove(context.Persons.Find(id) ?? throw new InvalidOperationException());
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
