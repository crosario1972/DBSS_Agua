//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBSS_Agua.API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CuentasPorCobrar
    {
        public int CuentasPorCobrarID { get; set; }
        public Nullable<int> ClienteID { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Nullable<System.DateTime> FechaDePago { get; set; }
        public string TransaccionReferencia { get; set; }
        public string Descripcion { get; set; }
        public Nullable<decimal> Debito { get; set; }
        public Nullable<decimal> Credito { get; set; }
        public string UsuarioNombre { get; set; }
    }
}
