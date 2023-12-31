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
using DBSS_Agua.API.Models;

namespace DBSS_Agua.API2.Controllers
{
    public class SuplidoresController : ApiController
    {
        private DB_AGUA_DEMOEntities db = new DB_AGUA_DEMOEntities();

        // GET: api/Suplidores
        public IQueryable<Suplidore> GetSuplidores()
        {
            return db.Suplidores;
        }

        // GET: api/Suplidores/5
        [ResponseType(typeof(Suplidore))]
        public async Task<IHttpActionResult> GetSuplidore(int id)
        {
            Suplidore suplidore = await db.Suplidores.FindAsync(id);
            if (suplidore == null)
            {
                return NotFound();
            }

            return Ok(suplidore);
        }

        // PUT: api/Suplidores/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSuplidore(int id, Suplidore suplidore)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != suplidore.SuplidorID)
            {
                return BadRequest();
            }

            db.Entry(suplidore).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuplidoreExists(id))
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

        // POST: api/Suplidores
        [ResponseType(typeof(Suplidore))]
        public async Task<IHttpActionResult> PostSuplidore(Suplidore suplidore)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Suplidores.Add(suplidore);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = suplidore.SuplidorID }, suplidore);
        }

        // DELETE: api/Suplidores/5
        [ResponseType(typeof(Suplidore))]
        public async Task<IHttpActionResult> DeleteSuplidore(int id)
        {
            Suplidore suplidore = await db.Suplidores.FindAsync(id);
            if (suplidore == null)
            {
                return NotFound();
            }

            db.Suplidores.Remove(suplidore);
            await db.SaveChangesAsync();

            return Ok(suplidore);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SuplidoreExists(int id)
        {
            return db.Suplidores.Count(e => e.SuplidorID == id) > 0;
        }
    }
}