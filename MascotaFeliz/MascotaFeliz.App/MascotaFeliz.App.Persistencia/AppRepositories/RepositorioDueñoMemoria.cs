using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia.AppRepositories
{
    public class RepositorioDueñoMemoria : IRepositorioDueño
    {
        List<Dueño> dueño;

        public RepositorioDueñoMemoria()
        {
            dueño = new List<Dueño>{
                new Dueño{Id=1,TipoId="Tarjeta de Identidad",Nombres="Lilia Maria", Apellidos="Nuñez Zaar",NumeroTelefono="3284756",Correo="lilia@hotmail.com",Genero="Femenino", Direccion="Cra. 65 15 64",Ciudad="Bogotá",Pais="Colombia"},
                new Dueño{Id=2,TipoId="Cédula de Ciudadanía",Nombres="Daniela Estefanni",Apellidos="Martinez Full",NumeroTelefono="9494949",Correo="Martinez@hotmail.com",Genero="Femenino",Direccion="Calle 7 56 98",Ciudad="Cali",Pais="Colombia"},
                new Dueño{Id=3,TipoId="Cédula de Ciudadanía",Nombres="Mario Andres",Apellidos="Perez Gonzalez",NumeroTelefono="8906521",Correo="Gogo@yahoo.es",Genero="Masculino",Direccion="Cra. 89 198 65",Ciudad="Santamarta", Pais="Colombia"},
                new Dueño{Id=4,TipoId="Cédula de Ciudadanía",Nombres="Sofia",Apellidos="Masgarit Kiss", NumeroTelefono="7878002",Correo="Kisshoy@yahoo.es",Genero="Femenino",Direccion="Calle 9 176 39",Ciudad="Boyaca",Pais="Colombia"},
                new Dueño{Id=5,TipoId="Cédula de Ciudadanía",Nombres="Mateo Esteban",Apellidos="Quiroz feroz",NumeroTelefono="9081729",Correo="Fulltu@gmail.com",Genero="Masculino",Direccion="Calle 68 19 19",Ciudad="Bogota",Pais="Colombia"},
            };
        }

        public Dueño AddDueño(Dueño pDueño)
        {
            pDueño.Id = dueño.Max(r => r.Id) + 1;
            dueño.Add(pDueño);
            return pDueño;
        }

        public void DeleteDueño(int pId)
        {
            var DueñoEncontrada = dueño.FirstOrDefault(vd => vd.Id == pId);
            if (DueñoEncontrada == null)
                return;
            dueño.Remove(DueñoEncontrada);
        }

        public IEnumerable<Dueño> GetAllDueños()
        {
            return dueño;
        }

        public IEnumerable<Dueño> GetAllDueño()
        {
            return dueño;
        }

        public Dueño GetDueño(int pId)
        {
            return dueño.SingleOrDefault(s => s.Id == pId);
        }

        public IEnumerable<Dueño> GetDueñoPorFiltro(string filtro = null) // el parámetro es opcional 
        {
            var Dueños = GetAllDueños(); // Obtiene todos los saludos
            if (Dueños != null)  //Si se tienen saludos
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    Dueños = Dueños.Where(s => s.Genero.Contains(filtro));
                    /// <summary>
                    /// Filtra los mensajes que contienen el filtro
                    /// </summary>
                }
            }
            return Dueños;
        }
        public Dueño UpdateDueño(Dueño pDueño)
        {
            var saludo= dueño.SingleOrDefault(r => r.Id==pDueño.Id);
            if (saludo!=null)
            {
                saludo.Id= pDueño.Id;
                saludo.TipoId = pDueño.TipoId;
                saludo.Nombres = pDueño.Nombres;
                saludo.Apellidos = pDueño.Apellidos;
                saludo.NumeroTelefono = pDueño.NumeroTelefono;
                saludo.Correo = pDueño.Correo;
                saludo.Genero = pDueño.Genero;
                saludo.Direccion = pDueño.Direccion;
                saludo.Ciudad = pDueño.Ciudad;
                saludo.Pais = pDueño.Pais;


            }
            return saludo;
        }
    }
}