
namespace DBSS_Agua.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CuentasPorPagar
    {
        public int CuentasPorPagarID { get; set; }
        public Nullable<int> SuplidorID { get; set; }
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
    }
}
