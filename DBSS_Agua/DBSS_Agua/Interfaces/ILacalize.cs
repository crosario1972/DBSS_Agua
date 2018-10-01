
namespace DBSS_Agua.Interfaces
{
    using System.Globalization;

    public interface ILacalize
    {
        CultureInfo GetCurrentCultureInfo();
        void SetLocale(CultureInfo ci);
    }
}
