using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia.AppRepositories
{
    public class RepositorioVeterinarioMemoria : IRepositorioVeterinario
    {
        List<Veterinario> veterinario;

        public RepositorioVeterinarioMemoria()
        {
            
            veterinario = new List<Veterinario>{
                new Veterinario{Id=1,TipoId="CédulaCiudadanía",Nombres="Martín",Apellidos="Ramírez",NumeroTelefono="6024175",Correo="martinr@gmail.com",Genero="Masculino",TarjetaProfesional="Mp1533545",CodigoProfesional=126},
                new Veterinario{Id=2,TipoId="CédulaExtranjería",Nombres="María Antonia",Apellidos="González Ortiz",NumeroTelefono="6804712",Correo="mariaagon@gmail.com",Genero="Femenino",TarjetaProfesional="Cg485671",CodigoProfesional=813},
                new Veterinario{Id=3,TipoId="CédulaCiudadanía",Nombres="Consuelo",Apellidos="Madrigal",NumeroTelefono="3052503471",Correo="madrigal0@gmail.com",Genero="Femenino",TarjetaProfesional="Ln258369",CodigoProfesional=421},
                new Veterinario{Id=4,TipoId="Cédula Extranjería",Nombres="Alicia",Apellidos="Osorio",NumeroTelefono="3209127411",Correo="alicia.osorio@gmail.com",Genero="Femenino",TarjetaProfesional="Lg741581",CodigoProfesional=872},
                new Veterinario{Id=5,TipoId="CedulaCiudadanía",Nombres="Francisco",Apellidos="Cáceres",NumeroTelefono="479642",Correo="conrado11.gmail.com",Genero="Masculino",TarjetaProfesional="Cs148752",CodigoProfesional=693},
            };
        }

        public Veterinario AddVeterinario(Veterinario pVeterinario)
        {
            pVeterinario.Id = veterinario.Max(r => r.Id) + 1;
            veterinario.Add(pVeterinario);
            return pVeterinario;
        }

        public void DeleteVeterinario(int pId)
        {
            var veterinarioEncontrado = veterinario.FirstOrDefault(vd => vd.Id == pId);
            if (veterinarioEncontrado == null)
                return;
            veterinario.Remove(veterinarioEncontrado);
        }

        public IEnumerable<Veterinario> GetAllVeterinario()
        {
            return veterinario;
        }

        public IEnumerable<Veterinario> GetAllVeterinarios()
        {
            return veterinario;
        }

        public Veterinario GetVeterinario(int pId)
        {
            return veterinario.SingleOrDefault(s => s.Id == pId);
        }

        public IEnumerable<Veterinario> GetVeterinariosPorFiltro(string filtro = null) // el parámetro es opcional 
        {
            var veterinarios = GetAllVeterinarios(); // Obtiene todos los saludos
            if (veterinarios != null)  //Si se tienen saludos
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    veterinarios = veterinarios.Where(s => s.Nombres.Contains(filtro));
                    /// <summary>
                    /// Filtra los mensajes que contienen el filtro
                    /// </summary>
                }
            }
            return veterinarios;
        }
        public Veterinario UpdateVeterinario(Veterinario pVeterinario)
        {
            var saludo= veterinario.SingleOrDefault(r => r.Id==pVeterinario.Id);
            if (saludo!=null)
            {
                saludo.Id = pVeterinario.Id;
                saludo.TipoId = pVeterinario.TipoId;
                saludo.Nombres = pVeterinario.Nombres;
                saludo.Apellidos = pVeterinario.Apellidos;
                saludo.NumeroTelefono = pVeterinario.NumeroTelefono;
                saludo.Correo = pVeterinario.Correo;
                saludo.Genero = pVeterinario.Genero;
                saludo.TarjetaProfesional = pVeterinario.TarjetaProfesional;
                saludo.CodigoProfesional = pVeterinario.CodigoProfesional;
            }
            return saludo;
        }
    }
}