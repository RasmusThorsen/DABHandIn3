using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DAB_HandIn_3._3.Models;

namespace DAB_HandIn_3._3.Controllers
{
    public class PersonController : ApiController
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        // GET: api/Person
        public IEnumerable<Person> Get()
        {
            return _unitOfWork.PersonRepository.GetAll();
        }

        // GET: api/Person/5
        [ResponseType(typeof(Person))]
        public IHttpActionResult Get(string id)
        {
            Person p = _unitOfWork.PersonRepository.Get(id);

            if (p == null) return NotFound();

            return Ok(p);
        }

        // POST: api/Person
        [ResponseType(typeof(Person))]
        public async Task<IHttpActionResult> Post(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.PersonRepository.Insert(person);
            _unitOfWork.Save();

            return CreatedAtRoute("DefaultApi", new { id = int.Parse(person.Id) }, person);
        }

        // PUT: api/Person/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(string id, Person newPerson)
        {
            _unitOfWork.PersonRepository.Put(id, newPerson);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Person/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(string id)
        {
            Person p = _unitOfWork.PersonRepository.Get(id);

            if (p == null) return NotFound();

            _unitOfWork.PersonRepository.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);

        }
    }
}
