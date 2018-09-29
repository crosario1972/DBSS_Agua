using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSS_Agua.Domain.Models
{
    public class DataContext: DbContext
    {
        public DataContext(): base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<DBSS_Agua.Common.Models.Clientes> Clientes { get; set; }
    }
}
