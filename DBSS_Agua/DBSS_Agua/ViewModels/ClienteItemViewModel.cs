using DBSS_Agua.Common.Models;
using DBSS_Agua.Helpers;
using DBSS_Agua.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DBSS_Agua.ViewModels
{
    public class ClienteItemViewModel : Clientes
    {
        public ICommand ClienteDetallesCommand { get { return new RelayCommand(ClienteDetallesCmd); } }

        private async void ClienteDetallesCmd()
        {
            MainViewModel.GetInstance().ClienteDetalles = new ClienteDetallesViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new ClienteDetallesPage());
        }
    }
}
