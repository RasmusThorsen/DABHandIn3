using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DAB_Handin3.Models;
using Repository;

namespace DAB_Handin3.Controllers
{
    public class BiesController : ApiController
    {
        private ByRepository repository = new ByRepository(new DAB_Handin3Context());

        // GET: api/Bies
        public IQueryable<By> GetBies()
        {
            return repository.GetAll().AsQueryable();
        }

        // GET: api/Bies/5
        [ResponseType(typeof(By))]
        public async Task<IHttpActionResult> GetBy(string id)
        {
            By by = repository.GetById(int.Parse(id));
            if (by == null)
            {
                return NotFound();
            }

            return Ok(by);
        }

        // PUT: api/Bies/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBy(string id, By by)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != by.Postnummer)
            {
                return BadRequest();
            }

            repository.Update(by);

            try
            {
                repository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ByExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Bies
        [ResponseType(typeof(By))]
        public async Task<IHttpActionResult> PostBy(By by)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.Insert(by);

            try
            {
                repository.Save();
            }
            catch (DbUpdateException)
            {
                if (ByExists(by.Postnummer))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            
            return CreatedAtRoute("DefaultApi", new { id = by.Postnummer }, by);
        }

        // DELETE: api/Bies/5
        [ResponseType(typeof(By))]
        public async Task<IHttpActionResult> DeleteBy(string id)
        {
            By by = repository.GetById(int.Parse(id));
            if (by == null)
            {
                return NotFound();
            }

            repository.Delete(int.Parse(id));
            repository.Save();

            return Ok(by);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ByExists(string id)
        {
            return repository.GetAll().Count(e => e.Postnummer == id) > 0;
        }
    }
}