using System;
using System.Collections.Generic;
using System.Text;
using DBSS_Agua.Common.Models;

namespace DBSS_Agua.ViewModels
{
   public class MainViewModel
   {
        public ClientesViewModel Clientes { get; set; }
        public ClienteViewModel Cliente { get; set; }
        public CuentasPorCobrarViewModel CuentaPorCobar { get; internal set; }
        public List<CuentasPorCobrar> CxCList { get; internal set; }

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
