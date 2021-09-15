namespace Parking.App.Dominio
{

    public class Estudiante : Usuario
    {
        public string RazonVisita { get; set; }
        public Estudiante AutorizacionVisitaE { get; set; }
        public Docente AutorizacionVisitaD { get; set; }
        public Administrativo AutorizacionVisitaA { get; set; }


    }
}