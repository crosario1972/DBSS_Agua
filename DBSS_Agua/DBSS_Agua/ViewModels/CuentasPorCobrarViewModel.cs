
namespace DBSS_Agua.ViewModels
{
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

            this.LoadCuentasPorCobrar();
            //   this.Nombre = App.NombreActual;
        }


        #endregion

        #region Methods



        private async void LoadCuentasPorCobrar()
        {
            this.IsRefreshing = true;
            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                this.IsRefreshing = false;
                return;
            }

            var response = await this.apiService.GetList<CuentasPorCobrar>("CuentasPorCobrar", "Custom1", App.IdActual.ToString());
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                this.isRefreshing = false;
                return;
            }

            MainViewModel.GetInstance().CxCList = (List<CuentasPorCobrar>)response.Result;
            this.CuentaPorCobar = new ObservableCollection<CuentasPorCobrarItemViewModel>(this.ToCxCItemViewModel());

            this.DebitoSum = (decimal)CuentaPorCobar.Where(x => x.ClienteID == App.IdActual).Sum(p => p.Debito);
            this.CreditoSum = (decimal)CuentaPorCobar.Where(x => x.ClienteID == App.IdActual).Sum(p => p.Credito);

            CultureInfo cultureInfo = new CultureInfo("es-DO");

            this.Balance = string.Format(cultureInfo, "{0:C0}", this.DebitoSum - this.CreditoSum);

            this.IsRefreshing = false;
        }

        private IEnumerable<CuentasPorCobrarItemViewModel> ToCxCItemViewModel()
        {
            return MainViewModel.GetInstance().CxCList.OrderByDescending(c => c.TransaccionFecha).Select(x => new CuentasPorCobrarItemViewModel
            {
                Balance = x.Balance,
                BalanceCredito = x.BalanceCredito,
                BalanceDebito = x.BalanceDebito,
                ClienteID = x.ClienteID,
                Credito = x.Credito,
                CuentasPorCobrarID = x.CuentasPorCobrarID,
                Debito = x.Debito,
                Descripcion = x.Descripcion,
                TransaccionFecha = x.TransaccionFecha,
                TransaccionReferencia = x.TransaccionReferencia,
                UsuarioNombre = x.UsuarioNombre,

            });
        }

        #endregion
    }
}