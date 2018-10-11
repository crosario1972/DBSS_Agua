using DBSS_Agua.API.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web.Http;

namespace DBSS_Phone.Api.Controllers
{
    [RoutePrefix("api/Clientes")]
    public class ClientesCustomController : ApiController
    {
        private DB_AGUA_DEMOEntities db = new DB_AGUA_DEMOEntities();

        public ObservableCollection<Cliente> ClientesCollection { get; set; }
        int contador;

        public ClientesCustomController()
        {
            ClientesCollection = new ObservableCollection<Cliente>();
        }

        [HttpGet]
        [Route("custom")]

        public IHttpActionResult Custom()
        {

            var queryList = (from clientes in db.Clientes
                             join cuentasPorCobrar in db.CuentasPorCobrars
                             on clientes.ClientesID equals cuentasPorCobrar.ClienteID
                             where cuentasPorCobrar.FechaDePago == null
                             select clientes);


            var clientesList = queryList.OrderBy(r => r.NombreInquilino);

            ReloadClientes(clientesList);


            var queryFinal = (from cuentasPorCobrar in ClientesCollection
                              join clientes in db.Clientes
                              on cuentasPorCobrar.ClientesID equals clientes.ClientesID
                              where clientes.ClientesID == cuentasPorCobrar.ClientesID
                              select clientes).Distinct();


            if (queryFinal == null)
            {
                return NotFound();

            }

            return Ok(queryFinal);

        }

        private void ReloadClientes(IOrderedQueryable<Cliente> clientesList)
        {
            ClientesCollection.Clear();
            try
            {
                int idTemp;
                int idNuevo;

                foreach (var clienteInicial in clientesList)
                {
                    idTemp = clienteInicial.ClientesID;
                    contador = 0;

                    foreach (var clienteFinal in clientesList)
                    {
                        idNuevo = clienteFinal.ClientesID;

                        if(idTemp == idNuevo)
                        {
                            contador += 1;
                        }


                        if(contador == 2)
                        {
                            ClientesCollection.Add(new Cliente
                            {
                                ClientesID = clienteFinal.ClientesID,
                                NombreInquilino = clienteFinal.NombreInquilino,
                            });

                            break;
                        }

                    }

                }
            }
            catch (Exception)
            {

                //throw;

            }
        }


    }
}