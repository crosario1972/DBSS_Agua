
namespace DBSS_Agua.Backend.Models
{
    using DBSS_Agua.Domain.Models;

    public class LocalDataContext: DataContext
    {
        public new System.Data.Entity.DbSet<DBSS_Agua.Common.Models.Clientes> Clientes { get; set; }
    }
}