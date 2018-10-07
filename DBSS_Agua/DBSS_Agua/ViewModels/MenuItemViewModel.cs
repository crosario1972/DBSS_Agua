namespace DBSS_Agua.ViewModels
{
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
       // public ICommand NavigateCommand { get { return new RelayCommand(Navigate); } }

        //private async void Navigate()
        //{
        //    await navigationService.Navigate(PageName);
        //}
        #endregion

    }
}
