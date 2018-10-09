
namespace DBSS_Agua.Models
{
    using System;
    using System.Collections.Generic;

    public partial class DiarioGeneral
    {
        public int DiarioGeneralID { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string Referencia { get; set; }
        public string Descripcion { get; set; }
        public string CuentaNombre { get; set; }
        public Nullable<decimal> Auxiliar { get; set; }
        public Nullable<decimal> Debito { get; set; }
        public Nullable<decimal> Credito { get; set; }
        public string Usuario { get; set; }
        public Nullable<bool> RegistroUsado { get; set; }
        public decimal BalanceDebito { get; set; }

        public decimal BalanceCredito { get; set; }

        public decimal Balance { get; set; }

    }
}
