using DBSS_Agua.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBSS_Agua.Backend.Models
{
    public class ClientesView : Clientes
    {
        public HttpPostedFileBase ImageFile { get; set; }

    }
}