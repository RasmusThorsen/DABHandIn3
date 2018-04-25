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
        public IQueryable<Telefon> GetTelefons()
        {
            return repository.GetAll().AsQueryable();
            //return db.Telefons;
        }

        // GET: api/Telefons/5
        [ResponseType(typeof(Telefon))]
        public async Task<IHttpActionResult> GetTelefon(string id)
        {
            Telefon telefon = repository.GetById(int.Parse(id));
            //Telefon telefon = await db.Telefons.FindAsync(id);
            if (telefon == null)
            {
                return NotFound();
            }

            return Ok(telefon);
        }

        // PUT: api/Telefons/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTelefon(string id, Telefon telefon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != telefon.Nummer)
            {
                return BadRequest();
            }

            //db.Entry(telefon).State = EntityState.Modified;
            repository.Update(telefon);
            try
            {
                //await db.SaveChangesAsync();
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

            //db.Telefons.Add(telefon);
            repository.Insert(telefon);

            try
            {
                //await db.SaveChangesAsync();
                repository.Save();
            }
            catch (DbUpdateException)
            {
                if (TelefonExists(telefon.Nummer))
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
        public async Task<IHttpActionResult> DeleteTelefon(string id)
        {
            //Telefon telefon = await db.Telefons.FindAsync(id);
            Telefon telefon = repository.GetById(int.Parse(id));
            if (telefon == null)
            {
                return NotFound();
            }

            //db.Telefons.Remove(telefon);
            //await db.SaveChangesAsync();
            repository.Delete(int.Parse(id));
            repository.Save();

            return Ok(telefon);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                repository.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TelefonExists(string id)
        {
            //return db.Telefons.Count(e => e.Nummer == id) > 0;
            return repository.GetAll().Count(e => e.Nummer == id) > 0;
        }
    }
}