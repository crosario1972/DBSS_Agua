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
using DBSS_Agua.Common.Models;
using DBSS_Agua.Domain.Models;

namespace DBSS_Agua.API.Controllers
{
    public class ClientesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Clientes
        public IQueryable<Clientes> GetClientes()
        {
            return db.Clientes;
        }

        // GET: api/Clientes/5
        [ResponseType(typeof(Clientes))]
        public async Task<IHttpActionResult> GetClientes(int id)
        {
            Clientes clientes = await db.Clientes.FindAsync(id);
            if (clientes == null)
            {
                return NotFound();
            }

            return Ok(clientes);
        }

        // PUT: api/Clientes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutClientes(int id, Clientes clientes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clientes.ClientesID)
            {
                return BadRequest();
            }

            db.Entry(clientes).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientesExists(id))
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

        // POST: api/Clientes
        [ResponseType(typeof(Clientes))]
        public async Task<IHttpActionResult> PostClientes(Clientes clientes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clientes.Add(clientes);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = clientes.ClientesID }, clientes);
        }

        // DELETE: api/Clientes/5
        [ResponseType(typeof(Clientes))]
        public async Task<IHttpActionResult> DeleteClientes(int id)
        {
            Clientes clientes = await db.Clientes.FindAsync(id);
            if (clientes == null)
            {
                return NotFound();
            }

            db.Clientes.Remove(clientes);
            await db.SaveChangesAsync();

            return Ok(clientes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientesExists(int id)
        {
            return db.Clientes.Count(e => e.ClientesID == id) > 0;
        }
    }
}