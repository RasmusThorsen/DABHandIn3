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
    public class TelefonsController : ApiController
    {
        private TelefonRepository repository = new TelefonRepository(new DAB_Handin3Context());

        // GET: api/Telefons
        public IEnumerable<Telefon> GetTelefons()
        {
            return repository.GetAll();
        }

        // GET: api/Telefons/5
        [ResponseType(typeof(Telefon))]
        public async Task<IHttpActionResult> GetTelefon(int id)
        {
            Telefon telefon = repository.GetById(id);
            if (telefon == null)
            {
                return NotFound();
            }

            return Ok(telefon);
        }

        // PUT: api/Telefons/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTelefon(int id, Telefon telefon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != telefon.TelefonId)
            {
                return BadRequest();
            }

            repository.Update(telefon);
            try
            {
                repository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelefonExists(id))
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

        // POST: api/Telefons
        [ResponseType(typeof(Telefon))]
        public async Task<IHttpActionResult> PostTelefon(Telefon telefon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.Insert(telefon);

            try
            {
                repository.Save();
            }
            catch (DbUpdateException)
            {
                if (TelefonExists(telefon.TelefonId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            
            return CreatedAtRoute("DefaultApi", new { id = telefon.Nummer }, telefon);
        }

        // DELETE: api/Telefons/5
        [ResponseType(typeof(Telefon))]
        public async Task<IHttpActionResult> DeleteTelefon(int id)
        {
            Telefon telefon = repository.GetById(id);
            if (telefon == null)
            {
                return NotFound();
            }

            repository.Delete(id);
            repository.Save();

            return Ok(telefon);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TelefonExists(int id)
        {
            return repository.GetAll().Count(e => e.TelefonId == id) > 0;
        }
    }
}