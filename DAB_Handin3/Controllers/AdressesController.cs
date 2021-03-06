﻿using System;
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
    public class AdressesController : ApiController
    {
        private AdresseRepository repository = new AdresseRepository(new DAB_Handin3Context());
        // GET: api/Adresses
        public IEnumerable<AdresseDetailsDTO> GetAdresses()
        {
            //return repository.GetAll();
            List<AdresseDetailsDTO> list = new List<AdresseDetailsDTO>();
            foreach (var adresse in repository.GetAll())
            {
                list.Add(new AdresseDetailsDTO(adresse));
            }

            return list;
        }

        // GET: api/Adresses/5
        [ResponseType(typeof(Adresse))]
        public async Task<IHttpActionResult> GetAdresse(int id)
        {
            Adresse adresse = repository.GetById(id);
            var adresseDTO = new AdresseDetailsDTO(adresse);
            if (adresse == null)
            {
                return NotFound();
            }

            return Ok(adresseDTO);
        }

        // PUT: api/Adresses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAdresse(int id, Adresse adresse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adresse.AdresseID)
            {
                return BadRequest();
            }

            repository.Update(adresse);
            try
            {
                repository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdresseExists(id))
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

        // POST: api/Adresses
        [ResponseType(typeof(Adresse))]
        public async Task<IHttpActionResult> PostAdresse(Adresse adresse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.Insert(adresse);
            repository.Save();

            var dto = new AdresseDetailsDTO(adresse);

            return CreatedAtRoute("DefaultApi", new { id = adresse.AdresseID }, dto);
        }

        // DELETE: api/Adresses/5
        [ResponseType(typeof(Adresse))]
        public async Task<IHttpActionResult> DeleteAdresse(int id)
        {
            Adresse adresse = repository.GetById(id);
            if (adresse == null)
            {
                return NotFound();
            }

            repository.Delete(id);
            repository.Save();

            return Ok(adresse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdresseExists(int id)
        {
            return repository.GetAll().Count(e => e.AdresseID == id) > 0;
        }
    }
}