
namespace DBSS_Agua.Helpers
{
    using Xamarin.Forms;
    using Interfaces;
    using DBSS_Agua.Resources;

    public static class Languages
    {
        static Languages()
        {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        public static string Accept
        {
            get { return Resource.Accept; }
        }

        public static string Error
        {
            get { return Resource.Error; }
        }

        public static string NoServer
        {
            get { return Resource.NoServer; }
        }

        public static string Clients
        {
            get { return Resource.Clients; }
        }

        public static string TurnOnInternet
        {
            get { return Resource.TurnOnInternet; }
        }
    }
}
