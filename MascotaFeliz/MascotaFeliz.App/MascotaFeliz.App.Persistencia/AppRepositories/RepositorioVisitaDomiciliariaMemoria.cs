using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia.AppRepositories
{
    public class RepositorioVisitaDomiciliariaMemoria : iRepositorioVisitaDomiciliaria
    {
        List<VisitaDomiciliaria> visitasDomiciliarias;

        public RepositorioVisitaDomiciliariaMemoria()
        {
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
        }

        public VisitaDomiciliaria AddVisitaDomiciliaria(VisitaDomiciliaria pVisitaDomiciliaria)
        {
            pVisitaDomiciliaria.Id = visitasDomiciliarias.Max(r => r.Id) + 1;
            visitasDomiciliarias.Add(pVisitaDomiciliaria);
            return pVisitaDomiciliaria;
        }

        public void DeleteVisitaDomiciliaria(int pId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VisitaDomiciliaria> GetAllVisitasDomiciliaras()
        {
            return visitasDomiciliarias;
        }

        public VisitaDomiciliaria GetVisitaDomiciliaria(int pId)
        {
            return visitasDomiciliarias.SingleOrDefault(s => s.Id == pId);
        }

        public IEnumerable<VisitaDomiciliaria> GetVisitasDomiciliariaPorFiltro(string filtro = null) // el parámetro es opcional 
        {
            var visitasDomiciliarias = GetAllVisitasDomiciliaras(); // Obtiene todos los saludos
            if (visitasDomiciliarias != null)  //Si se tienen saludos
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    visitasDomiciliarias = visitasDomiciliarias.Where(s => s.Medicinas.Contains(filtro));
                    /// <summary>
                    /// Filtra los mensajes que contienen el filtro
                    /// </summary>
                }
            }
            return visitasDomiciliarias;
        }
        public VisitaDomiciliaria UpdateVisitaDomiciliaria(VisitaDomiciliaria pVisitaDomiciliaria)
        {
            var saludo= visitasDomiciliarias.SingleOrDefault(r => r.Id==pVisitaDomiciliaria.Id);
            if (saludo!=null)
            {
                saludo.FechaHoraVisita = pVisitaDomiciliaria.FechaHoraVisita;
                saludo.Temperatura = pVisitaDomiciliaria.Temperatura;
                saludo.Peso = pVisitaDomiciliaria.Peso;
                saludo.FrencuenciaCardiaca = pVisitaDomiciliaria.FrencuenciaCardiaca;
                saludo.FrencuenciaRespiratoria = pVisitaDomiciliaria.FrencuenciaRespiratoria;
                saludo.EstadoAnimo = pVisitaDomiciliaria.EstadoAnimo;
                saludo.Medicinas = pVisitaDomiciliaria.Medicinas;
                saludo.Remision = pVisitaDomiciliaria.Remision;
                saludo.Paciente = pVisitaDomiciliaria.Paciente;
                saludo.Encargado = pVisitaDomiciliaria.Encargado;
            }
            return saludo;
        }
    }
}