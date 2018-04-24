using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandIn2._2_Relation_Database.Application
{
    class ByRepository : IRepository<By>
    {
        private PersonKartotekContext context;

        public ByRepository(PersonKartotekContext context)
        {
            this.context = context;
        }

        public IEnumerable<By> GetAll()
        {
            return context.Byer.ToList();
        }

        public By GetById(int id)
        {
            return context.Byer.Find(id.ToString());
        }

        public void Insert(By entity)
        {
            context.Byer.Add(entity);
        }

        public void Delete(int id)
        {
            context.Byer.Remove(context.Byer.Find(id) ?? throw new InvalidOperationException());
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
