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
    public class CuentasPorCobrarController : ApiController
    {
        private DB_AGUA_DEMOEntities db = new DB_AGUA_DEMOEntities();

        // GET: api/CuentasPorCobrar
        public IQueryable<CuentasPorCobrar> GetCuentasPorCobrars()
        {
            return db.CuentasPorCobrars;
        }

        public IQueryable<CuentasPorCobrar> GetCuentasPorCobrar(int id)
        {
            if (id > 0)
            {
                return db.CuentasPorCobrars.Where(c => c.ClienteID == id);
            }
            else
            {
                return null;
            }
        }

        // PUT: api/CuentasPorCobrar/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCuentasPorCobrar(int id, CuentasPorCobrar cuentasPorCobrar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cuentasPorCobrar.CuentasPorCobrarID)
            {
                return BadRequest();
            }

            db.Entry(cuentasPorCobrar).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuentasPorCobrarExists(id))
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

        // POST: api/CuentasPorCobrar
        [ResponseType(typeof(CuentasPorCobrar))]
        public async Task<IHttpActionResult> PostCuentasPorCobrar(CuentasPorCobrar cuentasPorCobrar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CuentasPorCobrars.Add(cuentasPorCobrar);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cuentasPorCobrar.CuentasPorCobrarID }, cuentasPorCobrar);
        }

        // DELETE: api/CuentasPorCobrar/5
        [ResponseType(typeof(CuentasPorCobrar))]
        public async Task<IHttpActionResult> DeleteCuentasPorCobrar(int id)
        {
            CuentasPorCobrar cuentasPorCobrar = await db.CuentasPorCobrars.FindAsync(id);
            if (cuentasPorCobrar == null)
            {
                return NotFound();
            }

            db.CuentasPorCobrars.Remove(cuentasPorCobrar);
            await db.SaveChangesAsync();

            return Ok(cuentasPorCobrar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CuentasPorCobrarExists(int id)
        {
            return db.CuentasPorCobrars.Count(e => e.CuentasPorCobrarID == id) > 0;
        }
    }
}