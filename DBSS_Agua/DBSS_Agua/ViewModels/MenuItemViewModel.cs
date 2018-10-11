namespace DBSS_Agua.ViewModels
{
    using DBSS_Agua.Views;
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
           App.Master.IsPresented = false;

            switch (this.PageName)
            {
                case "DiarioGeneralPage":
                    MainViewModel.GetInstance().DiarioGeneral = new DiarioGeneralViewModel();
                    await App.Navigator.PushAsync(new DiarioGeneralPage());
                    break;
                case "SuplidoresPage":
                    MainViewModel.GetInstance().Suplidores = new SuplidoresViewModel();
                    await App.Navigator.PushAsync(new SuplidoresPage());
                    break;
                case "AcercaPage":
                    //MainViewModel.GetInstance().Empleados = new EmpleadosViewModel();
                    await App.Navigator.PushAsync(new AcercaPage());
                    break;
                case "LogoutPage":
                    //await App.Navigator.PushAsync(new PickerMVVM());
                    //Logout();
                    break;
                case "ClientesEnSuspencionPage":
                    MainViewModel.GetInstance().ClientesSuspension = new ClientesEnSuspensionViewModel();
                    await App.Navigator.PushAsync(new ClientesEnSuspencionPage());
                    break;
                default:
                    break;
            }
        }


        #endregion

    }
}
