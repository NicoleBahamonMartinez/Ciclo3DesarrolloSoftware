using System;
using System.ComponentModel.DataAnnotations;


namespace MascotaFeliz.App.Dominio
{
    public class Usuario
    {
        public string TipoIdentificacion {get;set;}
        [Key] 
        public int NroIdentificacion {get;set;}
        public string Nombres {get;set;}
        public string Apellidos {get;set;}
        public long NumeroContacto {get;set;}
        public string CorreoElectronico {get;set;}

    }
}

