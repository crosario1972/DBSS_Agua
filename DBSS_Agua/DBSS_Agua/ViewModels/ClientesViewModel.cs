

namespace DBSS_Agua.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using DBSS_Agua.Common.Models;
    using DBSS_Agua.Servives;
    using Xamarin.Forms;

    public class ClientesViewModel: BaseViewModel
    {
        private ApiService apiService;


        private ObservableCollection<Clientes> clientesList;
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
            var response = await this.apiService.GetList<Clientes>("http://crosario.ddns.net:8006", "/api", "/Clientes");
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }

            var list = (List<Clientes>)response.Result;
            this.ClientesList = new ObservableCollection<Clientes>(list);

        }
    }
}
