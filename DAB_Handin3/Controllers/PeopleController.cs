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
    public class PeopleController : ApiController
    {
        private PersonRepository repository = new PersonRepository(new DAB_Handin3Context());
        // GET: api/People
        public IEnumerable<PersonDetailsDTO> GetPeople()
        {
            //return repository.GetAll().AsQueryable();
            List<PersonDetailsDTO> list = new List<PersonDetailsDTO>();
            foreach (var person in repository.GetAll())
            {
                list.Add(new PersonDetailsDTO(person));
            }

            return list;
        }

        // GET: api/People/5
        [ResponseType(typeof(Person))]
        public async Task<IHttpActionResult> GetPerson(int id)
        {
            Person person = repository.GetById(id);
            var personDTO = new PersonDetailsDTO(person);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(personDTO);
        }

        // PUT: api/People/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPerson(int id, Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != person.PersonID)
            {
                return BadRequest();
            }

            repository.Update(person);

            try
            {
                repository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
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

        // POST: api/People
        [ResponseType(typeof(Person))]
        public async Task<IHttpActionResult> PostPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.Insert(person);
            repository.Save();
               
            var dto = new PersonDetailsDTO(person);

            return CreatedAtRoute("DefaultApi", new { id = person.PersonID }, dto);
        }

        // DELETE: api/People/5
        [ResponseType(typeof(Person))]
        public async Task<IHttpActionResult> DeletePerson(int id)
        {
            Person person = repository.GetById(id);
            if (person == null)
            {
                return NotFound();
            }

            repository.Delete(id);
            repository.Save();

            return Ok(person);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonExists(int id)
        {
            return repository.GetAll().Count(e => e.PersonID == id) > 0;
        }
    }
}