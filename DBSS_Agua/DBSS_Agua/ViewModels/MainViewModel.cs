using System;
using System.Collections.Generic;
using System.Text;

namespace DBSS_Agua.ViewModels
{
   public class MainViewModel
   {
        public ClientesViewModel Clientes { get; set; }


        public MainViewModel()
        {
            this.Clientes = new ClientesViewModel();
        }
    }
}
