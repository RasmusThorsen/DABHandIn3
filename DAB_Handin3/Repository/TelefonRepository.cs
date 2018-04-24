using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandIn2._2_Relation_Database.Application
{
    class TelefonRepository
    {
        private PersonKartotekContext context;

        public TelefonRepository(PersonKartotekContext context)
        {
            this.context = context;
        }

        public IEnumerable<Telefon> GetAll()
        {
            return context.Telefoner.ToList();
        }

        public Telefon GetById(int id)
        {
            return (context.Telefoner.Find(id) ?? throw new InvalidOperationException());
        }

        public void Insert(Telefon entity)
        {
            context.Telefoner.Add(entity);
        }

        public void Delete(int id)
        {
            context.Telefoner.Remove(context.Telefoner.Find(id) ?? throw new InvalidOperationException());
        }

        public void Update(Telefon entity)
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
