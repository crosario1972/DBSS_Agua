using DBSS_Agua.Helpers;
using DBSS_Agua.Models;
using DBSS_Agua.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DBSS_Agua.ViewModels
{
    public class SuplidoresItemViewModel : Suplidore
    {



        public ICommand SuplidorDetailCommand { get { return new RelayCommand(SuplidorDetailCmd); } }

        private async void SuplidorDetailCmd()
        {
            MainViewModel.GetInstance().CuentaPorPagar = new CuentasPorPagarViewModel(this);
            await App.Navigator.PushAsync(new CuentasPorPagarPage());


        }
    }

}
