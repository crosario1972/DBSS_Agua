namespace DBSS_Agua.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Suplidore
    {
        public int SuplidorID { get; set; }
        public Nullable<bool> RegistroActivo { get; set; }
        public string Nombre { get; set; }
        public string TelefonoRecidencial { get; set; }
        public string TelefonoCelular { get; set; }
        public string Comentario { get; set; }
        public string UsuarioNombre { get; set; }
    }
}
