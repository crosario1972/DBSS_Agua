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
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class DiarioGeneral
    {
        [JsonIgnore]
        public int DiarioGeneralID { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        [JsonIgnore]
        public string Referencia { get; set; }
        [JsonIgnore]
        public string Descripcion { get; set; }
        public string CuentaNombre { get; set; }
        [JsonIgnore]
        public Nullable<decimal> Auxiliar { get; set; }
        public Nullable<decimal> Debito { get; set; }
        public Nullable<decimal> Credito { get; set; }
        [JsonIgnore]
        public string Usuario { get; set; }
        [JsonIgnore]
        public Nullable<bool> RegistroUsado { get; set; }
    }
}
