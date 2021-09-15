namespace Parking.App.Dominio
{

    public class Administrativo : Usuario
    {
        public string Dependencia { get; set; }
        public int Codigo { get; set; }
        public string NumeroOficina {get;set;}
    }
}