using System;
namespace MascotaFeliz.App.Dominio
{
    public class VisitaDomiciliaria
    {
        public DateTime FechaHoraVisita {get;set;}
        public int Id {get;set;}
        public int Temperatura {get;set;}
        public float Peso {get;set;}
        public int FrencuenciaCardiaca {get;set;}
        public int FrencuenciaRespiratoria {get;set;}
        public string EstadoAnimo {get;set;}
        public List<string> Medicinas {get;set;}
        public string Remision {get;set;}
        public Veterinario Encargado {get:set:}
        public Mascota Paciente {get:set:}

    }
}
