using DBSS_Agua.Backend.Helpers;
using DBSS_Agua.Backend.Models;
using DBSS_Agua.Common.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DBSS_Agua.Backend.Controllers
{
    public class ClientesController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Clientes
        public async Task<ActionResult> Index()
        {
            return View(await db.Clientes.OrderBy(c => c.NombreInquilino).Where(x => x.RegistroActivo==true).ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = await db.Clientes.FindAsync(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ClientesView view)
        {
            if (ModelState.IsValid)
            {
                var pic = string.Empty;
                var folder = "~/Content/Clientes";

                if (view.ImageFile != null)
                {
                    pic = FilesHelper.UploadPhoto(view.ImageFile, folder);
                    pic = $"{folder}/{pic}";
                }

                var cliente = this.ToCliente(view , pic);

                db.Clientes.Add(cliente);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(view);
        }

        private Clientes ToCliente(ClientesView view, string pic)
        {
            return new Clientes
            {
                MontoMensual = view.MontoMensual,
                ImagePath = pic,
                FechaCreación = view.FechaCreación,
                CasaPropia = view.CasaPropia,
                Cedula = view.Cedula,
                ClientesID = view.ClientesID,
                Comentario = view.Comentario,
                Direccion = view.Direccion,
                NombreInquilino = view.NombreInquilino,
                NombrePropietario = view.NombrePropietario,
                RegistroActivo = view.RegistroActivo,
                ServicioSuspendido = view.ServicioSuspendido,
                ServicioSuspendidoFecha = view.ServicioSuspendidoFecha,
                ServicioTipo = view.ServicioTipo,
                TelefonoCelular = view.TelefonoCelular,
                TelefonoRecidencial = view.TelefonoRecidencial,
                UsuarioNombre = view.UsuarioNombre
            };
        }

        // GET: Clientes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = await db.Clientes.FindAsync(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            var view = this.ToView(clientes);
            return View(view);
        }

        private ClientesView ToView(Clientes clientes)
        {
            return new ClientesView
            {
                MontoMensual = clientes.MontoMensual,
                ImagePath = clientes.ImagePath,
                FechaCreación = clientes.FechaCreación,
                CasaPropia = clientes.CasaPropia,
                Cedula = clientes.Cedula,
                ClientesID = clientes.ClientesID,
                Comentario = clientes.Comentario,
                Direccion = clientes.Direccion,
                NombreInquilino = clientes.NombreInquilino,
                NombrePropietario = clientes.NombrePropietario,
                RegistroActivo = clientes.RegistroActivo,
                ServicioSuspendido = clientes.ServicioSuspendido,
                ServicioSuspendidoFecha = clientes.ServicioSuspendidoFecha,
                ServicioTipo = clientes.ServicioTipo,
                TelefonoCelular = clientes.TelefonoCelular,
                TelefonoRecidencial = clientes.TelefonoRecidencial,
                UsuarioNombre = clientes.UsuarioNombre
            };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ClientesView view)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    var pic = view.ImagePath;
                    var folder = "~/Content/Clientes";

                    if (view.ImageFile != null)
                    {
                        pic = FilesHelper.UploadPhoto(view.ImageFile, folder);
                        pic = $"{folder}/{pic}";
                    }

                    var cliente = this.ToCliente(view, pic);

                    this.db.Entry(cliente).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return View(view);
        }

        // GET: Clientes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clientes = await db.Clientes.FindAsync(id);

            if (clientes == null)
            {
                return HttpNotFound();
            }

            return View(clientes);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var clientes = await db.Clientes.FindAsync(id);
            db.Clientes.Remove(clientes);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
