namespace Parking.App.Dominio
{

    public class Docente : Usuario
    {
        public string Departamento { get; set; }
        public int Codigo { get; set; }
        public string Facultad {get;set;}
        public string Cubiculo {get;set;}
    }
}