
namespace DBSS_Agua.ViewModels
{
    using DBSS_Agua.Helpers;
    using DBSS_Agua.Models;
    using DBSS_Agua.Servives;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class CuentasPorPagarViewModel : BaseViewModel
    {
        #region Services

        private ApiService apiService;
        public Suplidore Suplidor { get; set; }

        #endregion

        #region Attributes
        private ObservableCollection<CuentasPorPagarItemViewModel> cuentaPorPagar;
        private bool isRefreshing;
        public string nombre;
        public decimal debitoSum;
        public decimal creditoSum;
        public string balance;

        #endregion

        #region Properties
        public ObservableCollection<CuentasPorPagarItemViewModel> CuentaPorPagar
        {
            get { return this.cuentaPorPagar; }
            set { this.SetValue(ref this.cuentaPorPagar, value); }

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

        public ICommand RefreshCommand { get { return new RelayCommand(LoadCuentasPorPagar); } }


        #endregion

        #region Constructor

        public CuentasPorPagarViewModel(Suplidore Suplidor)
        {
            App.NombreActual = Suplidor.Nombre;
            App.IdActual = Suplidor.SuplidorID;

            this.apiService = new ApiService();
            this.LoadCuentasPorPagar();
        }


        #endregion

        #region Methods

        private async void LoadCuentasPorPagar()
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
            var controller = Application.Current.Resources["UrlCxpController"].ToString();
            string id = $"{"/"}{App.IdActual}";

            var response = await this.apiService.GetList<CuentasPorPagar>(url, prefix, controller, id);
            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(Languages.Error, Languages.NoServer, Languages.Accept);
                return;
            }

            MainViewModel.GetInstance().CxPList = (List<CuentasPorPagar>)response.Result;
            this.CuentaPorPagar = new ObservableCollection<CuentasPorPagarItemViewModel>(this.ToCxPItemViewModel());

            this.DebitoSum = (decimal)CuentaPorPagar.Where(x => x.SuplidorID == App.IdActual).Sum(p => p.Debito);
            this.CreditoSum = (decimal)CuentaPorPagar.Where(x => x.SuplidorID == App.IdActual).Sum(p => p.Credito);

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

        private IEnumerable<CuentasPorPagarItemViewModel> ToCxPItemViewModel()
        {
            return MainViewModel.GetInstance().CxPList.OrderByDescending(c => c.FechaCreacion).Select(x => new CuentasPorPagarItemViewModel
            {
                CuentasPorPagarID = x.CuentasPorPagarID,
                Balance = x.Balance,
                BalanceCredito = x.BalanceCredito,
                BalanceDebito = x.BalanceDebito,
                FechaCreacion = x.FechaCreacion,
                FechaDePago = x.FechaDePago,
                SuplidorID = x.SuplidorID,
                Credito = x.Credito,
                Debito = x.Debito,
                Descripcion = x.Descripcion,
                TransaccionReferencia = x.TransaccionReferencia,
                UsuarioNombre = x.UsuarioNombre,

            });
        }

        #endregion
    }
}
