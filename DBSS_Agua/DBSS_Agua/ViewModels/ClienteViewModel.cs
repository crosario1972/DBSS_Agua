﻿

namespace DBSS_Agua.ViewModels
{
    using DBSS_Agua.Models;
    using DBSS_Agua.Servives;
    using DBSS_Agua.Views;
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;

    public class ClienteViewModel : BaseViewModel
    {
        #region Attribute
        private ApiService apiService;
        private bool isRunning;
        private bool isEnabled;
        private bool isVisible;
        public string nombre;
        int clienteID;
        string clienteNombre;
        string nombreClienteActual;

        #endregion

        #region Properties
        public Clientes Cliente { get; set; }


        public bool IsRunning
        {
            get { return this.isRunning; }
            set { this.SetValue(ref this.isRunning, value); }
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { this.SetValue(ref this.isEnabled, value); }
        }

        public bool IsVisible
        {
            get { return this.isVisible; }
            set { this.SetValue(ref this.isVisible, value); }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.SetValue(ref this.nombre, value); }
        }


        #endregion

        #region Commands

        public ICommand ClienteCxC_Command { get { return new RelayCommand(ClienteCxC_Cmd); } }


        public ICommand IsEnabledCommand { get { return new RelayCommand(IsEnabledCmd); } }


        #endregion

        #region Constructor
        public ClienteViewModel(Clientes Cliente)
        {
            App.NombreActual = Cliente.NombreInquilino;
            App.IdActual = Cliente.ClientesID;
            this.Nombre = Cliente.NombreInquilino;
            this.Cliente = Cliente;
        }

        #endregion

        #region Methods



        private  void IsEnabledCmd()
        {
            //var respuesta = await dialogService.ShowMessageAlert("Alerta", "Decea editar el registro?");
            //if (respuesta != false)
            //{
            //    if (IsEnabled == true)
            //    {
            //        IsEnabled = false;
            //        IsVisible = true;
            //    }
            //    else
            //    {
            //        IsEnabled = true;
            //        IsVisible = false;
            //    }

            //}
        }

        private async  void ClienteCxC_Cmd()

        {

            MainViewModel.GetInstance().CuentaPorCobar = new CuentasPorCobrarViewModel();
            await App.Navigator.PushAsync(new ClienteCxC_DetailsPage());
        }


        #endregion
    }
}
