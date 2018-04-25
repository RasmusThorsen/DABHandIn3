using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAB_Handin3.Models;

namespace Repository
{
    class TelefonRepository
    {
        private DAB_Handin3Context context;

        public TelefonRepository(DAB_Handin3Context context)
        {
            this.context = context;
        }

        public IEnumerable<Telefon> GetAll()
        {
            return context.Telefons;
        }

        public Telefon GetById(int id)
        {
            return (context.Telefons.Find(id) ?? throw new InvalidOperationException());
        }

        public void Insert(Telefon entity)
        {
            context.Telefons.Add(entity);
        }

        public void Delete(int id)
        {
            context.Telefons.Remove(context.Telefons.Find(id) ?? throw new InvalidOperationException());
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
