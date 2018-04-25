using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAB_Handin3.Models;

namespace Repository
{
    class AdresseRepository
    {
        private DAB_Handin3Context context;

        public AdresseRepository(DAB_Handin3Context context)
        {
            this.context = context;
        }

        public IEnumerable<Adresse> GetAll()
        {
            //return context.Adresses.Include(x => x.Persons).ToList();
            return context.Adresses;
        }

        public Adresse GetById(int id)
        {
            return context.Adresses.Find(id);
        }

        public void Insert(Adresse entity)
        {
            context.Adresses.Add(entity);
        }

        public void Delete(int id)
        {
            context.Adresses.Remove(context.Adresses.Find(id) ?? throw new InvalidOperationException());
        }

        public void Update(Adresse entity)
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
