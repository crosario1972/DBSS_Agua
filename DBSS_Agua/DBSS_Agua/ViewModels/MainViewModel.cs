using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }
        public string Nombre { get; internal set; }

        public MainViewModel()
        {
            instance = this;
            this.Clientes = new ClientesViewModel();
            this.Menu = new ObservableCollection<MenuItemViewModel>();
            //Load data
            LoadMenu();
        }

        #region Menu
        private void LoadMenu()
        {
            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_About.png",
                Title = "Acerca",
                PageName = "AcercaPage",
            });

            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_CxP.png",
                Title = "Cuentas x Pagar",
                PageName = "CuentasPorPagarPage",
            });

            //Menu.Add(new MenuItemViewModel()
            //{
            //    Icon = "ic_logoutColor.png",
            //    Title = "Cerrar sesión",
            //    PageName = "LogoutPage",
            //});

            //Menu.Add(new MenuItemViewModel()
            //{
            //    Icon = "ic_Suplidores.png",
            //    Title = "Suplidores",
            //    PageName = "SuplidoresPage",
            //});

            //Menu.Add(new MenuItemViewModel()
            //{
            //    Icon = "ic_EmployeeColor.png",
            //    Title = "Empleados",
            //    PageName = "EmpleadosPage",
            //});

            //Menu.Add(new MenuItemViewModel()
            //{
            //    Icon = "ic_Usuarios.png",
            //    Title = "Usuarios",
            //    PageName = "UsuariosPage",
            //});

            //Menu.Add(new MenuItemViewModel()
            //{
            //    Icon = "ic_Empresa.png",
            //    Title = "Empresa",
            //    PageName = "EmpresaPage",
            //});

            //Menu.Add(new MenuItemViewModel()
            //{
            //    Icon = "ic_logoutColor.png",
            //    Title = "Cerrar sesión",
            //    PageName = "LogoutPage",
            //});
        }
        #endregion


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
