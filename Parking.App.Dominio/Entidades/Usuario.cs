using System;
namespace Parking.App.Dominio
{
    public class Usuario
    {
        public string TipoId {get;set;}
        public int Id {get;set;}
        public string Nombres {get;set;}
        public string Apellidos {get;set;}
        public string NumeroContacto {get;set;}
        public string CorreoElectronico {get;set;}
        public Vehiculo CarroGuardado {get;set;}
        public Transaccion Pago {get;set;}

    }
}