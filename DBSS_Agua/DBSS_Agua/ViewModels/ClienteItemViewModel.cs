
namespace DBSS_Agua.ViewModels
{
    using DBSS_Agua.Models;

    //public class ClienteItemViewModel : Clientes
    //{
    //    public ICommand ClienteDetallesCommand { get { return new RelayCommand(ClienteDetallesCmd); } }

    //    private async void ClienteDetallesCmd()
    //    {
    //        MainViewModel.GetInstance().Cliente = new ClienteViewModel(this);
    //        await Application.Current.MainPage.Navigation.PushAsync(new ClienteDetallesPage());
    //    }
    //}


    using DBSS_Agua.Servives;
    using DBSS_Agua.Views;
    using GalaSoft.MvvmLight.Command;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class ClientesItemViewModel : Clientes, INotifyPropertyChanged
    {
        #region Attributes

        private ApiService apiService;

        #endregion

        #region Properties

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        public string ClienteNombreCxC { get; set; }
        public int ClienteIdCxC { get; set; }
        public string ClienteCxCBalance { get; set; }

        #endregion

        #region Constructors

        public ClientesItemViewModel()
        {
            apiService = new ApiService();
            //dialogService = new DialogService();
            //TiposList = GetTipos().OrderBy(c => c.ValorTipo).ToList();

        }


        #endregion

        #region Commands


        public ICommand ClienteDetailCommand { get { return new RelayCommand(ClienteDetailCmd); } }

        #endregion

        #region Methods

        private async void ClienteDetailCmd()
        {

            //MainViewModel.GetInstance().Cliente = new ClienteViewModel(this);
            //await navigationService.Navigate("ClientesDetailPage");

            MainViewModel.GetInstance().Cliente = new ClienteViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new ClienteDetallesPage());

        }


        #endregion

        #region Singelton
        static ClientesItemViewModel instance;

        public static ClientesItemViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new ClientesItemViewModel();
            }

            return instance;
        }
        #endregion
    }
}
