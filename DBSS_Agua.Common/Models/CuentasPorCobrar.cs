using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSS_Agua.Common.Models
{
    public class CuentasPorCobrar
    {
        //[Key]
        //public int CuentasPorCobrarID { get; set; }
        //public int ClienteID { get; set; }
        //[DataType(DataType.Date)]
        //public Nullable<System.DateTime> FechaCreacion { get; set; }
        //[DataType(DataType.Date)]
        //public Nullable<System.DateTime> FechaDePago { get; set; }
        //public string TransaccionReferencia { get; set; }
        //public string Descripcion { get; set; }
        //[DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        //public decimal Debito { get; set; }
        //[DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        //public decimal Credito { get; set; }
        //public string UsuarioNombre { get; set; }

        public int CuentasPorCobrarID { get; set; }
        public int ClienteID { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Nullable<System.DateTime> FechaDePago { get; set; }
        public string TransaccionReferencia { get; set; }
        public string Descripcion { get; set; }
        public Nullable<decimal> Debito { get; set; }
        public Nullable<decimal> Credito { get; set; }
        public string UsuarioNombre { get; set; }
        public decimal BalanceDebito { get; set; }

        public decimal BalanceCredito { get; set; }

        public decimal Balance { get; set; }

        public override int GetHashCode()
        {
            return ClienteID;
        }
    }
}
