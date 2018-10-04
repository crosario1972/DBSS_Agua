
namespace DBSS_Agua.Domain.Models
{
    using DBSS_Agua.Common.Models;
    using System.Data.Entity;
    using System.Linq;

    public class DataContext: DbContext
    {
        public DataContext(): base("DefaultConnection")
        {
        }
        public DbSet<Clientes> Clientes { get; set; }

    }
}
