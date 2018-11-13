using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiBase;

namespace WebApiBase.Controllers
{
    [Authorize]
    public class PerfilController : ApiController
    {
        private ModelDB db = new ModelDB();

        // GET: api/Perfil
        public IQueryable<perfil> GetPerfil()
        {
            return db.perfil;
        }

        // GET: api/Perfil/5
        [ResponseType(typeof(perfil))]
        public IHttpActionResult GetPerfil(int id)
        {
            perfil perfil = db.perfil.Find(id);
            if (perfil == null)
            {
                return NotFound();
            }

            return Ok(perfil);
        }

        // PUT: api/Perfil/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPerfil(int id, perfil perfil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != perfil.id_perfil)
            {
                return BadRequest();
            }

            db.Entry(perfil).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!perfilExists(id))
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

        // POST: api/Perfil
        [ResponseType(typeof(perfil))]
        public IHttpActionResult PostPerfil(perfil perfil)
        {
            /*if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }*/

            db.perfil.Add(perfil);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = perfil.id_perfil }, perfil);
        }

        // DELETE: api/Perfil/5
        [ResponseType(typeof(perfil))]
        public IHttpActionResult DeletePerfil(int id)
        {
            perfil perfil = db.perfil.Find(id);
            if (perfil == null)
            {
                return NotFound();
            }

            db.perfil.Remove(perfil);
            db.SaveChanges();

            return Ok(perfil);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool perfilExists(int id)
        {
            return db.perfil.Count(e => e.id_perfil == id) > 0;
        }
    }
}