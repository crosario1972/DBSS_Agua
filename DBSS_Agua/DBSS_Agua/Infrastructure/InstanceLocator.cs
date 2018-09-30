
namespace DBSS_Agua.Infrastructure
{
    using DBSS_Agua.ViewModels;

    public class InstanceLocator
    {
        public MainViewModel Main { get; set; }

        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }

    }
}
