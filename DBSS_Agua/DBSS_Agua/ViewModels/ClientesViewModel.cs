

namespace DBSS_Agua.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using DBSS_Agua.Common.Models;
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

            // var connection = await this.apiService.CheckConnection();
            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Accept");
                return;
            }



            //  var url = Application.Current.Resources["UrlAPI"].ToString();
            var response = await this.apiService.GetList<Clientes>("http://crosario.ddns.net:8006", "/api", "/Clientes");
            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }

            var list = (List<Clientes>)response.Result;
            this.ClientesList = new ObservableCollection<Clientes>(list);
            this.IsRefreshing = false;
        }

        public ICommand RefreshCommand { get { return new RelayCommand(LoadClientes); } }
    }
}
