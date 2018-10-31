using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using DBSS_Agua.Common.Models;
using DBSS_Agua.Models;

namespace DBSS_Agua.ViewModels
{
   public class MainViewModel : BaseViewModel
   {
        private string revision;

        public string Revision
        {
            get { return this.revision; }
            set { SetValue(ref this.revision, value); }

        }

        public ClientesViewModel Clientes { get; set; }
        public ClienteViewModel Cliente { get; set; }
        public CuentasPorCobrarViewModel CuentaPorCobar { get; internal set; }
        public DiarioGeneralViewModel DiarioGeneral { get; internal set; }
        public List<CuentasPorCobrar> CxCList { get; internal set; }
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }
        public string Nombre { get; internal set; }
        public List<DiarioGeneral> DiarioGeneralList { get; internal set; }
        public List<Suplidore> SuplidorList { get; internal set; }

        public SuplidoresViewModel Suplidores { get; internal set; }
        public List<CuentasPorPagar> CxPList { get; internal set; }
        public CuentasPorPagarViewModel CuentaPorPagar { get; internal set; }
        public ClientesEnSuspensionViewModel ClientesSuspension { get; set; }

        public MainViewModel()
        {
            instance = this;
            this.Clientes = new ClientesViewModel();
            this.Menu = new ObservableCollection<MenuItemViewModel>();
            //Load data
            LoadMenu();
            LoadRevision();
        }

        private void LoadRevision()
        {
            //'1.1.5.1
            //'| | | |--- Cantidad de arreglos o midificaciones significativas al Software maxima 10 cambios de numero.
            //'| | |
            //'| | |----- Contador de revisiones. Si es letra significa que no ha sido implementado el software.
            //'| |
            //'| |------- Version de visual studio (1 = 2008, 2 = 2010, 3 = 2012, 4 = 2015, 5 = 2017)
            //'|
            //'|--------- Lenguaje de programacion 1= Visual Basic, 2= WPF C#, 3= Xamarin Forms C#.

            //-------------------------------------------------------------------------------------------------------------------------------------------------
            // "Rev.3.5.1.0 - 12-MAR-2018" - Production release.
            // Formularios afectados: 
            //-------------------------------------------------------------------------------------------------------------------------------------------------
            // "Rev.3.5.1.1 - 10-OCT-2018" - Correccion de falta ortografica.
            // Formularios afectados: ClientesEnSuspensionPage
            //-------------------------------------------------------------------------------------------------------------------------------------------------
            // "Rev.3.5.1.2 - 17-OCT-2018" - Reduccion del tamaño del ListView.
            // Formularios afectados: ClientesPage
            //-------------------------------------------------------------------------------------------------------------------------------------------------
            // "Rev.3.5.1.3 - 22-OCT-2018" - Reduccion del tamaño del ListView de clientes en suspension.
            // Formularios afectados: ClientesEnSuspensionPage
            //-------------------------------------------------------------------------------------------------------------------------------------------------


            this.Revision = "Rev.3.5.1.3 - 22-OCT-2018";

        }

        #region Menu
        private void LoadMenu()
        {
            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_IngresosEgresos.png",
                Title = "Ingresos - Egresos",
                PageName = "DiarioGeneralPage",
            });

            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_CxP.png",
                Title = "Cuentas por Pagar",
                PageName = "SuplidoresPage",
            });

            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_Corte.png",
                Title = "Usuarios en Suspensión",
                PageName = "ClientesEnSuspensionPage",
            });

            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_About.png",
                Title = "Acerca",
                PageName = "AcercaPage",
            });

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
