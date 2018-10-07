

namespace DBSS_Agua.ViewModels
{
    using DBSS_Agua.Common.Models;
    using DBSS_Agua.Helpers;
    using DBSS_Agua.Servives;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Input;
    using Xamarin.Forms;
    public class CuentasPorCobrarViewModel : BaseViewModel
    {

        #region Attributes
        private ObservableCollection<CuentasPorCobrarItemViewModel> cuentaPorCobar;
        private bool isRefreshing;
        public string nombre;
        public decimal debitoSum;
        public decimal creditoSum;
        public string balance;
        private ApiService apiService;
        private int ClienteID;

        #endregion

        #region Properties
        public ObservableCollection<CuentasPorCobrarItemViewModel> CuentaPorCobar
        {
            get { return this.cuentaPorCobar; }
            set { this.SetValue(ref this.cuentaPorCobar, value); }

        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }
        }

        public decimal DebitoSum
        {
            get { return this.debitoSum; }
            set { this.SetValue(ref this.debitoSum, value); }
        }

        public decimal CreditoSum
        {
            get { return this.creditoSum; }
            set { this.SetValue(ref this.creditoSum, value); }
        }

        public string Balance
        {
            get { return this.balance; }
            set { this.SetValue(ref this.balance, value); }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.SetValue(ref this.nombre, value); }
        }

        #endregion

        #region Commands

        public ICommand RefreshCommand { get { return new RelayCommand(LoadCuentasPorCobrar); } }




        #endregion

        #region Constructor

        public CuentasPorCobrarViewModel()
        {
            this.apiService = new ApiService();
            this.LoadCuentasPorCobrar();

            this.Nombre = App.NombreActual;
        }


        #endregion

        #region Methods



        private async void LoadCuentasPorCobrar()
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


            //var response = await this.apiService.GetList<CuentasPorCobrar>("CuentasPorCobrar", "Custom1", App.IdActual.ToString());
            //if (!response.IsSuccess)
            //{
            //    await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
            //    this.isRefreshing = false;
            //    return;
            //}

            //MainViewModel.GetInstance().CxCList = (List<CuentasPorCobrar>)response.Result;
            //this.CuentaPorCobar = new ObservableCollection<CuentasPorCobrarItemViewModel>(this.ToCxCItemViewModel());

            //this.DebitoSum = (decimal)CuentaPorCobar.Where(x => x.ClienteID == App.IdActual).Sum(p => p.Debito);
            //this.CreditoSum = (decimal)CuentaPorCobar.Where(x => x.ClienteID == App.IdActual).Sum(p => p.Credito);

            //CultureInfo cultureInfo = new CultureInfo("es-DO");

            //this.Balance = string.Format(cultureInfo, "{0:C0}", this.DebitoSum - this.CreditoSum);

            var url = Application.Current.Resources["UrlAPI"].ToString();
            var prefix = Application.Current.Resources["UrlPrefix"].ToString();
            var controller = Application.Current.Resources["UrlCxcController"].ToString();
            string id = $"{"/"}{App.IdActual}";

            var response = await this.apiService.GetList<CuentasPorCobrar>(url, prefix, controller, id);
            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(Languages.Error, Languages.NoServer, Languages.Accept);
                return;
            }

            //this.MyClientes = (List<Clientes>)response.Result;

            //this.IsRefreshing = false;

            MainViewModel.GetInstance().CxCList = (List<CuentasPorCobrar>)response.Result;
            this.CuentaPorCobar = new ObservableCollection<CuentasPorCobrarItemViewModel>(this.ToCxCItemViewModel());

            this.DebitoSum = (decimal)CuentaPorCobar.Where(x => x.ClienteID == App.IdActual).Sum(p => p.Debito);
            this.CreditoSum = (decimal)CuentaPorCobar.Where(x => x.ClienteID == App.IdActual).Sum(p => p.Credito);

            CultureInfo cultureInfo = new CultureInfo("es-DO");

            this.Balance = string.Format(cultureInfo, "{0:C0}", this.DebitoSum - this.CreditoSum);

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

        private IEnumerable<CuentasPorCobrarItemViewModel> ToCxCItemViewModel()
        {
            return MainViewModel.GetInstance().CxCList.OrderByDescending(c => c.FechaCreacion).Select(x => new CuentasPorCobrarItemViewModel
            {
                Balance = x.Balance,
                BalanceCredito = x.BalanceCredito,
                BalanceDebito = x.BalanceDebito,
                FechaCreacion = x.FechaCreacion,
                FechaDePago = x.FechaDePago,
                ClienteID = x.ClienteID,
                Credito = x.Credito,
                CuentasPorCobrarID = x.CuentasPorCobrarID,
                Debito = x.Debito,
                Descripcion = x.Descripcion,
                TransaccionReferencia = x.TransaccionReferencia,
                UsuarioNombre = x.UsuarioNombre,

            });
        }

        #endregion
    }
}