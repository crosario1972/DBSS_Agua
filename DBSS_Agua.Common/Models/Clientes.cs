﻿
namespace DBSS_Agua.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Clientes
    {
        [Key]
        public int ClientesID { get; set; }
        public bool RegistroActivo { get; set; }
        [Required]
        public string NombreInquilino { get; set; }
        public string NombrePropietario { get; set; }
        public bool CasaPropia { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public string TelefonoRecidencial { get; set; }
        public string TelefonoCelular { get; set; }
        public Nullable<System.DateTime> FechaCreación { get; set; }
        public string Comentario { get; set; }
        public string ServicioTipo { get; set; }
        public string UsuarioNombre { get; set; }
        public Nullable<System.DateTime> ServicioSuspendidoFecha { get; set; }
        public decimal MontoMensual { get; set; }
        public override string ToString()
        {
            return this.NombreInquilino;
        }

        public bool ServicioSuspendido { get; set; }

        public string Suspendido
        {
            get { return ServicioSuspendido == true ? "Si" : "No"; }
        }

    }
}
