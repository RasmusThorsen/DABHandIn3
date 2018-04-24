using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAB_Handin3.Models;

namespace Repository
{
    class ByRepository : IRepository<By>
    {
        private DAB_Handin3Context context;

        public ByRepository(DAB_Handin3Context context)
        {
            this.context = context;
        }

        public IEnumerable<By> GetAll()
        {
            return context.Bies.ToList();
        }

        public By GetById(int id)
        {
            return context.Bies.Find(id.ToString());
        }

        public void Insert(By entity)
        {
            context.Bies.Add(entity);
        }

        public void Delete(int id)
        {
            context.Bies.Remove(context.Bies.Find(id) ?? throw new InvalidOperationException());
        }

        public void Update(By entity)
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
