namespace DBSS_Agua.ViewModels
{
    using DBSS_Agua.Views;
    //using DBSS_Phone.Services;
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    public class MenuItemViewModel
    {
        #region Attributes
        //private NavigationService navigationService;
        #endregion


        #region Properties
        public string Icon { get; set; }

        public string Title { get; set; }

        public string PageName { get; set; }
        #endregion


        #region Contructors
        public MenuItemViewModel()
        {
           // navigationService = new NavigationService();
        }
        #endregion


        #region Commands
        public ICommand NavigateCommand { get { return new RelayCommand(GoTo); } }

        private async void GoTo()
        {
            //MainViewModel.GetInstance().CuentaPorCobar = new CuentasPorCobrarViewModel();
            //await App.Navigator.PushAsync(new ClienteCxC_DetailsPage());
           App.Master.IsPresented = false;

            switch (this.PageName)
            {
                case "CuentasPorPagarPage":
                  //  MainViewModel.GetInstance().Clientes = new ClientesViewModel();
                    await App.Navigator.PushAsync(new CuentasPorPagarPage());
                    break;
                case "AcercaPage":
                    //MainViewModel.GetInstance().Empleados = new EmpleadosViewModel();
                    await App.Navigator.PushAsync(new AcercaPage());
                    break;
                case "LogoutPage":
                    //await App.Navigator.PushAsync(new PickerMVVM());
                    //Logout();
                    break;
                default:
                    break;
            }
        }


        #endregion

    }
}
