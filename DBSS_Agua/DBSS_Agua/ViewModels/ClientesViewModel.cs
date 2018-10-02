

namespace DBSS_Agua.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using DBSS_Agua.Common.Models;
    using DBSS_Agua.Helpers;
    using DBSS_Agua.Servives;
    using GalaSoft.MvvmLight.Command;
    using Xamarin.Forms;

    public class ClientesViewModel: BaseViewModel
    {
        private ObservableCollection<Clientes> clientesList;
        private ApiService apiService;
        private bool isRefreshing;

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }
        }

        public ObservableCollection<Clientes> ClientesList
        {
            get { return this.clientesList; }
            set { this.SetValue(ref this.clientesList, value); }
        }

        public ClientesViewModel()
        {
            this.apiService = new ApiService();
            this.LoadClientes();
        }

        private async void LoadClientes()
        {
            this.IsRefreshing = true;
            //========================Validacion de la conexion al internet y el servidor===============================================================
            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;

                // "No se pudo conectar el servidor")
                if (connection.Result.ToString() == "No se pudo conectar el servidor")
                {
                    await Application.Current.MainPage.DisplayAlert(Languages.Error, Languages.NoServer, Languages.Accept);
                    System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
                }
                else
                {
                    Device.BeginInvokeOnMainThread(async () => 
                    { await Application.Current.MainPage.DisplayAlert(Languages.Error, Languages.TurnOnInternet, Languages.Accept); });
                    CerrarPrograma();
                    return;
                }
            }
            //========================fin de la conexion al internet y el servidor======================================================================

            var url = Application.Current.Resources["UrlAPI"].ToString();
            var prefix = Application.Current.Resources["UrlPrefix"].ToString();
            var controller = Application.Current.Resources["UrlClientesController"].ToString();


            var response = await this.apiService.GetList<Clientes>(url,prefix,controller);
            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                //await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                await Application.Current.MainPage.DisplayAlert(Languages.Error, Languages.NoServer, Languages.Accept);
                return;
            }

            var list = (List<Clientes>)response.Result;
            this.ClientesList = new ObservableCollection<Clientes>(list);
            this.IsRefreshing = false;
        }

        private void CerrarPrograma()
        {
            Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            {
                System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
                return true; 
            });
        }

        public ICommand RefreshCommand { get { return new RelayCommand(LoadClientes); } }
    }
}
