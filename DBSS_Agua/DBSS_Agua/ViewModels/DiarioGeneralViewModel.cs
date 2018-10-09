using DBSS_Agua.Helpers;
using DBSS_Agua.Models;
using DBSS_Agua.Servives;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DBSS_Agua.ViewModels
{
    public class DiarioGeneralViewModel: BaseViewModel
    {


        #region Attributes
        private ObservableCollection<DiarioGeneralItemViewModel> diarioGeneral;
        private bool isRefreshing;
        //public string nombre;
        public decimal debitoSum;
        public decimal creditoSum;
        public string balance;
        private ApiService apiService;
        // private int ClienteID;

        #endregion

        #region Properties
        public ObservableCollection<DiarioGeneralItemViewModel> DiarioGeneral
        {
            get { return this.diarioGeneral; }
            set { this.SetValue(ref this.diarioGeneral, value); }

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

        #endregion

        #region Commands

        public ICommand RefreshCommand { get { return new RelayCommand(LoadDiarioGeneral); } }

        #endregion

        #region Constructor

        public DiarioGeneralViewModel()
        {
            this.apiService = new ApiService();
            this.LoadDiarioGeneral();

        }


        #endregion


        #region Methods

        private async void LoadDiarioGeneral()
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
            var controller = Application.Current.Resources["UrlDiarioController"].ToString();
            //string id = $"{"/"}{App.IdActual}";

            var response = await this.apiService.GetList<DiarioGeneral>(url, prefix, controller);
            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(Languages.Error, Languages.NoServer, Languages.Accept);
                return;
            }

            //this.MyClientes = (List<Clientes>)response.Result;

            //this.IsRefreshing = false;

            MainViewModel.GetInstance().DiarioGeneralList = (List<DiarioGeneral>)response.Result;
            this.DiarioGeneral = new ObservableCollection<DiarioGeneralItemViewModel>(this.ToDiarioItemViewModel());

            this.DebitoSum = (decimal)DiarioGeneral.Sum(p => p.Debito);
            this.CreditoSum = (decimal)DiarioGeneral.Sum(p => p.Credito);

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

        private IEnumerable<DiarioGeneralItemViewModel> ToDiarioItemViewModel()
        {
            return MainViewModel.GetInstance().DiarioGeneralList.OrderByDescending(c => c.Fecha).Select(x => new DiarioGeneralItemViewModel
            {
                Fecha = x.Fecha,
                CuentaNombre = x.CuentaNombre,
                Credito = x.Credito,
                Debito = x.Debito,
                BalanceCredito = x.BalanceCredito,
                BalanceDebito = x.BalanceDebito,
                Balance = x.Balance,

            });
        }

        #endregion
    }
}
