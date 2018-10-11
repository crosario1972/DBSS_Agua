

namespace DBSS_Agua.ViewModels
{
    using DBSS_Agua.Models;
    using DBSS_Agua.Servives;
    using DBSS_Agua.Views;
    using GalaSoft.MvvmLight.Command;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;

    public class ClientesEnSuspensionItemViewModel : Clientes, INotifyPropertyChanged
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

        public ClientesEnSuspensionItemViewModel()
        {
            apiService = new ApiService();

        }


        #endregion

        #region Commands


        public ICommand ClienteDetailCommand { get { return new RelayCommand(ClienteDetailCmd); } }

        #endregion

        #region Methods

        private async void ClienteDetailCmd()
        {
            MainViewModel.GetInstance().Cliente = new ClienteViewModel(this);
            await App.Navigator.PushAsync(new ClienteDetallesPage());

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
