using System.Collections.Generic;
using MascotaFeliz.App.Dominio;
using System.Linq;
using System;

namespace MascotaFeliz.App.Persistencia.AppRepositories
{
    public class RepositorioVisitaDomiciliaria : iRepositorioVisitaDomiciliaria
    {
        private readonly AppContext _appContext;
        public RepositorioVisitaDomiciliaria(AppContext appContext)
        {
            _appContext = appContext;
        }
        public VisitaDomiciliaria AddVisitaDomiciliaria(VisitaDomiciliaria pVisitaDomiciliaria)
        {
            var visitaDomiciliariaAdicionada = _appContext.VisitasDomiciliarias.Add(pVisitaDomiciliaria);
            _appContext.SaveChanges();
            return visitaDomiciliariaAdicionada.Entity;
        }

        public void DeleteVisitaDomiciliaria(int pId)
        {
            var visitaDomiciliariaEncontrada = _appContext.VisitasDomiciliarias.FirstOrDefault(vd => vd.Id == pId);
            if (visitaDomiciliariaEncontrada == null)
                return;
            _appContext.VisitasDomiciliarias.Remove(visitaDomiciliariaEncontrada);
            _appContext.SaveChanges();
        }

        public IEnumerable<VisitaDomiciliaria> GetAllVisitasDomiciliaras()
        {
            return _appContext.VisitasDomiciliarias;
        }

        public VisitaDomiciliaria GetVisitaDomiciliaria(int pId)
        {
            return _appContext.VisitasDomiciliarias.FirstOrDefault(vd => vd.Id == pId);


        }

        public VisitaDomiciliaria UpdateVisitaDomiciliaria(VisitaDomiciliaria pVisitaDomiciliaria)
        {
            var visitaDomiciliariaEncontrada = _appContext.VisitasDomiciliarias.FirstOrDefault(vd => vd.Id == pVisitaDomiciliaria.Id);
            if (visitaDomiciliariaEncontrada != null)
            {
                visitaDomiciliariaEncontrada.FechaHoraVisita = pVisitaDomiciliaria.FechaHoraVisita;
                visitaDomiciliariaEncontrada.Temperatura = pVisitaDomiciliaria.Temperatura;
                visitaDomiciliariaEncontrada.Peso = pVisitaDomiciliaria.Peso;
                visitaDomiciliariaEncontrada.FrencuenciaCardiaca = pVisitaDomiciliaria.FrencuenciaCardiaca;
                visitaDomiciliariaEncontrada.FrencuenciaRespiratoria = pVisitaDomiciliaria.FrencuenciaRespiratoria;
                visitaDomiciliariaEncontrada.EstadoAnimo = pVisitaDomiciliaria.EstadoAnimo;
                visitaDomiciliariaEncontrada.Medicinas = pVisitaDomiciliaria.Medicinas;
                visitaDomiciliariaEncontrada.Remision = pVisitaDomiciliaria.Remision;
                visitaDomiciliariaEncontrada.Paciente = pVisitaDomiciliaria.Paciente;
                visitaDomiciliariaEncontrada.Encargado = pVisitaDomiciliaria.Encargado;
                _appContext.SaveChanges();

            }
            return visitaDomiciliariaEncontrada;
        }
        public IEnumerable<VisitaDomiciliaria> GetVisitasDomiciliariaPorFiltro(string filtro = null) // el parámetro es opcional 
        {
            List<VisitaDomiciliaria> visitasDomiciliarias;
            DateTime fecha1 = new DateTime(2010, 8, 18);
            DateTime fecha2 = new DateTime(2021, 5, 30);
            DateTime fecha3 = new DateTime(2019, 2, 15);
            Dueño dueño = new Dueño { Direccion = "Cra 33A#26a-12", Ciudad = "Bogotá", Pais = "Colombia" };
            Veterinario veterinario = new Veterinario { TarjetaProfesional = "ULALA", CodigoProfesional = 12345 };
            Mascota mascota1 = new Mascota { id = 1, Nombre = "Manotas", Edad = 12, Tipo = "Perro", Raza = "Pastor Aleman", Color = "Negro", Dueño = dueño };
            Mascota mascota2 = new Mascota { id = 2, Nombre = "Phoenix", Edad = 3, Tipo = "Gato", Raza = "Criollo", Color = "Gris", Dueño = dueño };

            visitasDomiciliarias = new List<VisitaDomiciliaria>{
                new VisitaDomiciliaria{FechaHoraVisita=fecha1,Id=1,Temperatura=36,Peso=3.5F,FrencuenciaCardiaca=160,FrencuenciaRespiratoria=25,EstadoAnimo="Feliz",Medicinas="",Remision="Nutricionista",Encargado=veterinario,Paciente=mascota1},
                new VisitaDomiciliaria{FechaHoraVisita=fecha2,Id=2,Temperatura=30,Peso=2.5F,FrencuenciaCardiaca=170,FrencuenciaRespiratoria=35,EstadoAnimo="Triste",Medicinas="Ivermectina",Remision="",Encargado=veterinario,Paciente=mascota2},
                new VisitaDomiciliaria{FechaHoraVisita=fecha3,Id=3,Temperatura=25,Peso=3.8F,FrencuenciaCardiaca=260,FrencuenciaRespiratoria=21,EstadoAnimo="Feliz",Medicinas="Acetaminofen",Remision="",Encargado=veterinario,Paciente=mascota1},
                new VisitaDomiciliaria{FechaHoraVisita=fecha2,Id=4,Temperatura=39,Peso=1.5F,FrencuenciaCardiaca=130,FrencuenciaRespiratoria=45,EstadoAnimo="Hambriento",Medicinas="Ibuprofeno",Remision="Neurologo",Encargado=veterinario,Paciente=mascota2},
                new VisitaDomiciliaria{FechaHoraVisita=fecha1,Id=5,Temperatura=30,Peso=3.0F,FrencuenciaCardiaca=165,FrencuenciaRespiratoria=29,EstadoAnimo="Bravo",Medicinas="",Remision="",Encargado=veterinario,Paciente=mascota1},
            };
            return visitasDomiciliarias;
        }
    }
}