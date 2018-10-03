using DBSS_Agua.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBSS_Agua.ViewModels
{
    public class ClienteDetallesViewModel:BaseViewModel
    {
        private Clientes cliente;

        public Clientes Clientes
        {
            get { return this.cliente; }
            set { this.SetValue(ref this.cliente, value); }
        }

        public ClienteDetallesViewModel(Clientes cliente)
        {
            this.cliente = cliente;
        }
    }
}
