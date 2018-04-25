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
        public IEnumerable<ByDTO> GetBies()
        {
            //return repository.GetAll();
            var list = new List<ByDTO>();
            foreach (var by in repository.GetAll())
            {
                list.Add(new ByDTO(by));
            }

            return list;
        }

        // GET: api/Bies/5
        [ResponseType(typeof(By))]
        public async Task<IHttpActionResult> GetBy(int id)
        {
            By by = repository.GetById(id);
            if (by == null)
            {
                return NotFound();
            }

            return Ok(by);
        }

        // PUT: api/Bies/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBy(int id, By by)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != by.ById)
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
                if (ByExists(by.ById))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            var dto = new ByDTO(by);
            return CreatedAtRoute("DefaultApi", new { id = by.ById }, dto);
        }

        // DELETE: api/Bies/5
        [ResponseType(typeof(By))]
        public async Task<IHttpActionResult> DeleteBy(int id)
        {
            By by = repository.GetById(id);
            if (by == null)
            {
                return NotFound();
            }

            repository.Delete(id);
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

        private bool ByExists(int id)
        {
            return repository.GetAll().Count(e => e.ById == id) > 0;
        }
    }
}