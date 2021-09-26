using System;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;

namespace MascotaFeliz.App.Consola
{
    class Program
    {
            private static iRepositorioVisitaDomiciliaria _repoVisitaDomiciliaria=new RepositorioVisitaDomiciliaria(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            AddVisitaDomiciliaria();
        }
        private static void AddVisitaDomiciliaria(){
            var VisitaDomiciliariaNueva=new VisitaDomiciliaria{
                FechaHoraVisita=new DateTime(2021,5,5),
                Temperatura=5,
                Peso=3,
                FrencuenciaRespiratoria=100,
                FrencuenciaCardiaca=120,
                EstadoAnimo="Feliz",
                Medicinas="Paracetamol",
                Remision="",
                Encargado=new Veterinario(),
                Paciente=new Mascota()
            };
            _repoVisitaDomiciliaria.AddVisitaDomiciliaria(VisitaDomiciliariaNueva);

        }
    }
}
