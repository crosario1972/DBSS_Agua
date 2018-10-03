using System;
using System.Collections.Generic;
using System.Text;

namespace DBSS_Agua.ViewModels
{
   public class MainViewModel
   {
        public ClientesViewModel Clientes { get; set; }
        public ClienteDetallesViewModel ClienteDetalles { get; set; }


        public MainViewModel()
        {
            instance = this;
            this.Clientes = new ClientesViewModel();
        }


        #region Singleton

        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }

        #endregion
    }
}
