using DBSS_Agua.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DBSS_Agua
{
    public partial class App : Application
    {
        //public const string BaseAdd = "http://crosario.ddns.net:8006";

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ClientesPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
