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

namespace DBSS_Agua.API.Controllers
{
    public class DiarioGeneralController : ApiController
    {
        private DB_AGUA_DEMOEntities db = new DB_AGUA_DEMOEntities();

        // GET: api/DiarioGeneral
        public IQueryable<DiarioGeneral> GetDiarioGenerals()
        {
            return db.DiarioGenerals;
        }

        // GET: api/DiarioGeneral/5
        [ResponseType(typeof(DiarioGeneral))]
        public async Task<IHttpActionResult> GetDiarioGeneral(int id)
        {
            DiarioGeneral diarioGeneral = await db.DiarioGenerals.FindAsync(id);
            if (diarioGeneral == null)
            {
                return NotFound();
            }

            return Ok(diarioGeneral);
        }

        // PUT: api/DiarioGeneral/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDiarioGeneral(int id, DiarioGeneral diarioGeneral)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != diarioGeneral.DiarioGeneralID)
            {
                return BadRequest();
            }

            db.Entry(diarioGeneral).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiarioGeneralExists(id))
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

        // POST: api/DiarioGeneral
        [ResponseType(typeof(DiarioGeneral))]
        public async Task<IHttpActionResult> PostDiarioGeneral(DiarioGeneral diarioGeneral)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DiarioGenerals.Add(diarioGeneral);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = diarioGeneral.DiarioGeneralID }, diarioGeneral);
        }

        // DELETE: api/DiarioGeneral/5
        [ResponseType(typeof(DiarioGeneral))]
        public async Task<IHttpActionResult> DeleteDiarioGeneral(int id)
        {
            DiarioGeneral diarioGeneral = await db.DiarioGenerals.FindAsync(id);
            if (diarioGeneral == null)
            {
                return NotFound();
            }

            db.DiarioGenerals.Remove(diarioGeneral);
            await db.SaveChangesAsync();

            return Ok(diarioGeneral);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DiarioGeneralExists(int id)
        {
            return db.DiarioGenerals.Count(e => e.DiarioGeneralID == id) > 0;
        }
    }
}