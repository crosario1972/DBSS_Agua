
namespace DBSS_Agua.ViewModels
{
    using DBSS_Agua.Helpers;
    using DBSS_Agua.Models;
    using DBSS_Agua.Servives;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class SuplidoresViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;

        #endregion

        #region Attributes
        public List<Suplidore> MySuplidores { get; set; }
        private ObservableCollection<SuplidoresItemViewModel> suplidores;
        private bool isRefreshing;
        private string filter;
        #endregion

        #region Properties
        public ObservableCollection<SuplidoresItemViewModel> Suplidores
        {
            get { return this.suplidores; }
            set { this.SetValue(ref this.suplidores, value); }

        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }
        }

        public string Filter
        {
            get { return this.filter; }
            set { this.SetValue(ref this.filter, value); this.SearchCmd(); }
        }


        #endregion

        #region Commands

        public ICommand RefreshCommand { get { return new RelayCommand(LoadSuplidores); } }

        public ICommand SearchCommand { get { return new RelayCommand(SearchCmd); } }




        #endregion

        #region Constructor

        public SuplidoresViewModel()
        {
            this.apiService = new ApiService();
            this.LoadSuplidores();
        }

        private async void LoadSuplidores()
        {
            //this.IsRefreshing = true;
            //var connection = await this.apiService.CheckConnection();

            //if (!connection.IsSuccess)
            //{
            //    await Application.Current.MainPage.DisplayAlert(
            //        "Error",
            //        connection.Message,
            //        "Accept");
            //    await Application.Current.MainPage.Navigation.PopAsync();
            //    this.IsRefreshing = false;
            //    return;
            //}

            //var response = await this.apiService.GetList<Suplidor>("Suplidores");
            //if (!response.IsSuccess)
            //{
            //    await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
            //    this.isRefreshing = false;
            //    return;
            //}

            //MainViewModel.GetInstance().SuplidorList = (List<Suplidor>)response.Result;
            //this.Suplidores = new ObservableCollection<SuplidoresItemViewModel>(this.ToSuplidoresItemViewModel());
            //this.IsRefreshing = false;

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
            var controller = Application.Current.Resources["UrlSuplidoresController"].ToString();


            var response = await this.apiService.GetList<Suplidore>(url, prefix, controller);
            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(Languages.Error, Languages.NoServer, Languages.Accept);
                return;
            }

            this.MySuplidores = (List<Suplidore>)response.Result;
            this.RefreshList();
            this.IsRefreshing = false;
        }

        private void SearchCmd()
        {

            //if (string.IsNullOrEmpty(this.Filter))
            //{
            //    this.Suplidores = new ObservableCollection<SuplidoresItemViewModel>(this.ToSuplidoresItemViewModel());
            //}
            //else
            //{
            //    this.Suplidores = new ObservableCollection<SuplidoresItemViewModel>(
            //        this.ToSuplidoresItemViewModel().Where(a =>
            //        a.Nombre.ToLower().Contains(this.Filter.ToLower())));
            //}
        }

        #endregion

        #region Methods

        //private IEnumerable<SuplidoresItemViewModel> ToSuplidoresItemViewModel()
        //{
        //    return MainViewModel.GetInstance().SuplidorList.OrderBy(c => c.Nombre).Select(Suplidor => new SuplidoresItemViewModel
        //    {
        //        Apellido = Suplidor.Apellido,
        //        Cedula = Suplidor.Cedula,
        //        Ciudad = Suplidor.Ciudad,
        //        Comentario = Suplidor.Comentario,
        //        Direccion = Suplidor.Direccion,
        //        Fax = Suplidor.Fax,
        //        FechaCreación = Suplidor.FechaCreación,
        //        HorarioEntrada_LV = Suplidor.HorarioEntrada_LV,
        //        HorarioEntrada_S = Suplidor.HorarioEntrada_S,
        //        HorarioSalida_LV = Suplidor.HorarioSalida_LV,
        //        HorarioSalida_S = Suplidor.HorarioSalida_S,
        //        ITBIS_Separado = Suplidor.ITBIS_Separado,
        //        Nombre = Suplidor.Nombre,
        //        PaginaWeb = Suplidor.PaginaWeb,
        //        RegistroActivo = Suplidor.RegistroActivo,
        //        Representante = Suplidor.Representante,
        //        RNC = Suplidor.RNC,
        //        Secctor = Suplidor.Secctor,
        //        SuplidorID = Suplidor.SuplidorID,
        //        SuplidorRanking = Suplidor.SuplidorRanking,
        //        SuplidorTipo = Suplidor.SuplidorTipo,
        //        TelefonoCelular = Suplidor.TelefonoCelular,
        //        TelefonoRecidencial = Suplidor.TelefonoRecidencial,
        //        TiempoDeCredito = Suplidor.TiempoDeCredito,
        //        UsuarioNombre = Suplidor.UsuarioNombre,
        //    });
        //}

        public void RefreshList()
        {
            var MyListSuplidorItemViewModel = MySuplidores.Select(p => new SuplidoresItemViewModel
            {
                SuplidorID = p.SuplidorID,
                Nombre = p.Nombre,
                RegistroActivo = p.RegistroActivo,
                Comentario = p.Comentario,
                TelefonoCelular = p.TelefonoCelular,
                TelefonoRecidencial = p.TelefonoRecidencial,
                UsuarioNombre = p.UsuarioNombre,

            });
            this.Suplidores = new ObservableCollection<SuplidoresItemViewModel>(MyListSuplidorItemViewModel.OrderBy(c => c.Nombre).Where(x => x.RegistroActivo == true));

        }

        private void CerrarPrograma()
        {
            Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            {
                System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
                return true;
            });
        }

        #endregion
    }
}
