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
    public class CuentasPorPagarController : ApiController
    {
        private DB_AGUA_DEMOEntities db = new DB_AGUA_DEMOEntities();

        // GET: api/CuentasPorPagar
        public IQueryable<CuentasPorPagar> GetCuentasPorPagars()
        {
            return db.CuentasPorPagars;
        }

        //// GET: api/CuentasPorPagar/5
        //[ResponseType(typeof(CuentasPorPagar))]
        //public async Task<IHttpActionResult> GetCuentasPorPagar(int id)
        //{
        //    CuentasPorPagar cuentasPorPagar = await db.CuentasPorPagars.FindAsync(id);
        //    if (cuentasPorPagar == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(cuentasPorPagar);
        //}

        public IQueryable<CuentasPorPagar> GetCuentasPorPagar(int id)
        {
            if (id > 0)
            {
                return db.CuentasPorPagars.Where(c => c.SuplidorID == id);
            }
            else
            {
                return null;
            }
        }

        // PUT: api/CuentasPorPagar/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCuentasPorPagar(int id, CuentasPorPagar cuentasPorPagar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cuentasPorPagar.CuentasPorPagarID)
            {
                return BadRequest();
            }

            db.Entry(cuentasPorPagar).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuentasPorPagarExists(id))
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

        // POST: api/CuentasPorPagar
        [ResponseType(typeof(CuentasPorPagar))]
        public async Task<IHttpActionResult> PostCuentasPorPagar(CuentasPorPagar cuentasPorPagar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CuentasPorPagars.Add(cuentasPorPagar);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cuentasPorPagar.CuentasPorPagarID }, cuentasPorPagar);
        }

        // DELETE: api/CuentasPorPagar/5
        [ResponseType(typeof(CuentasPorPagar))]
        public async Task<IHttpActionResult> DeleteCuentasPorPagar(int id)
        {
            CuentasPorPagar cuentasPorPagar = await db.CuentasPorPagars.FindAsync(id);
            if (cuentasPorPagar == null)
            {
                return NotFound();
            }

            db.CuentasPorPagars.Remove(cuentasPorPagar);
            await db.SaveChangesAsync();

            return Ok(cuentasPorPagar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CuentasPorPagarExists(int id)
        {
            return db.CuentasPorPagars.Count(e => e.CuentasPorPagarID == id) > 0;
        }
    }
}