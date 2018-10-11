using System;
using System.Collections.Generic;
using System.Text;

//

namespace DBSS_Agua.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using DBSS_Agua.Helpers;
    using DBSS_Agua.Servives;
    using GalaSoft.MvvmLight.Command;
    using Xamarin.Forms;
    using System.Linq;
    using DBSS_Agua.Models;

    public class ClientesEnSuspensionViewModel : BaseViewModel
    {
        public List<Clientes> MyClientes { get; set; }
        private ObservableCollection<ClientesEnSuspensionItemViewModel> clientesList;
        private ApiService apiService;
        private bool isRefreshing;
        private string filter;

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }
        }

        public ObservableCollection<ClientesEnSuspensionItemViewModel> ClientesList
        {
            get { return this.clientesList; }
            set { this.SetValue(ref this.clientesList, value); }
        }

        public string Filter
        {
            get { return this.filter; }
            set { this.SetValue(ref this.filter, value); this.RefreshList(); }
        }

        public ClientesEnSuspensionViewModel()
        {
            this.apiService = new ApiService();
            this.LoadClientes();

        }

        public ICommand SearchCommand { get { return new RelayCommand(RefreshList); } }
        public ICommand RefreshCommand { get { return new RelayCommand(RefreshList); } }

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
            var controller = Application.Current.Resources["UrlClientesEnSuspensionController"].ToString();


            var response = await this.apiService.GetList<Clientes>(url, prefix, controller);
            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(Languages.Error, Languages.NoServer, Languages.Accept);
                return;
            }

            this.MyClientes = (List<Clientes>)response.Result;
            this.RefreshList();

        }

        public void RefreshList()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                var MyListClienteItemViewModel = MyClientes.Select(p => new ClientesEnSuspensionItemViewModel
                {
                    Cedula = p.Cedula,
                    RegistroActivo = p.RegistroActivo,
                    CasaPropia = p.CasaPropia,
                    ClientesID = p.ClientesID,
                    Comentario = p.Comentario,
                    Direccion = p.Direccion,
                    FechaCreación = p.FechaCreación,
                    ImagePath = p.ImagePath,
                    MontoMensual = p.MontoMensual,
                    NombreInquilino = p.NombreInquilino,
                    NombrePropietario = p.NombrePropietario,
                    ServicioSuspendido = p.ServicioSuspendido,
                    ServicioSuspendidoFecha = p.ServicioSuspendidoFecha,
                    ServicioTipo = p.ServicioTipo,
                    TelefonoCelular = p.TelefonoCelular,
                    TelefonoRecidencial = p.TelefonoRecidencial,
                    UsuarioNombre = p.UsuarioNombre,

                });
                this.ClientesList = new ObservableCollection<ClientesEnSuspensionItemViewModel>(MyListClienteItemViewModel.OrderBy(c => c.NombreInquilino).Where(x => x.RegistroActivo == true && x.ServicioSuspendido== false ));
                this.IsRefreshing = false;

            }
            else
            {
                var MyListClienteItemViewModel = MyClientes.Select(p => new ClientesEnSuspensionItemViewModel
                {
                    Cedula = p.Cedula,
                    RegistroActivo = p.RegistroActivo,
                    CasaPropia = p.CasaPropia,
                    ClientesID = p.ClientesID,
                    Comentario = p.Comentario,
                    Direccion = p.Direccion,
                    FechaCreación = p.FechaCreación,
                    ImagePath = p.ImagePath,
                    MontoMensual = p.MontoMensual,
                    NombreInquilino = p.NombreInquilino,
                    NombrePropietario = p.NombrePropietario,
                    ServicioSuspendido = p.ServicioSuspendido,
                    ServicioSuspendidoFecha = p.ServicioSuspendidoFecha,
                    ServicioTipo = p.ServicioTipo,
                    TelefonoCelular = p.TelefonoCelular,
                    TelefonoRecidencial = p.TelefonoRecidencial,
                    UsuarioNombre = p.UsuarioNombre,

                }).Where(x => x.NombreInquilino.ToLower().Contains(this.Filter.ToLower())).ToList();
                this.ClientesList = new ObservableCollection<ClientesEnSuspensionItemViewModel>(MyListClienteItemViewModel.OrderBy(c => c.NombreInquilino).Where(x => x.RegistroActivo == true && x.ServicioSuspendido == false));
                this.IsRefreshing = false;

            }
        }

        private void CerrarPrograma()
        {
            Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            {
                System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
                return true;
            });
        }

    }
}
