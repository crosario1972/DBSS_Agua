using DBSS_Agua.Interfaces;
using DBSS_Agua.Resorces;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DBSS_Agua.Helpers
{
    public static class Languages
    {
        static Languages()
        {
            var ci = DependencyService.Get<ILacalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            DependencyService.Get<ILacalize>().SetLocale(ci);
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

        public static string Products
        {
            get { return Resource.Products; }
        }

        public static string TurnOnInternet
        {
            get { return Resource.TurnOnInternet; }
        }
    }
}
