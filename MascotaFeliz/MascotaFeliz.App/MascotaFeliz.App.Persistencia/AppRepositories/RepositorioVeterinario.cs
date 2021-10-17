using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia.AppRepositories
{
    public class RepositorioVeterinario:IRepositorioVeterinario 
    {
        private readonly AppContext _appContext; 

        public RepositorioVeterinario(AppContext appContext)
        {
            _appContext = appContext;
        }
        
        Veterinario IRepositorioVeterinario.AddVeterinario(Veterinario veterinario)
        {
            var veterinarioAdicionado = _appContext.Veterinarios.Add(veterinario);
            _appContext.SaveChanges();
            return veterinarioAdicionado.Entity;
        }

        Veterinario IRepositorioVeterinario.UpdateVeterinario(Veterinario veterinario)
        {
            var veterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(c => c.Id == veterinario.Id);
            if (veterinarioEncontrado != null)
            {
                veterinarioEncontrado.TipoId=veterinario.TipoId;
                veterinarioEncontrado.Nombres=veterinario.Nombres;
                veterinarioEncontrado.Apellidos=veterinario.Apellidos;
                veterinarioEncontrado.NumeroTelefono=veterinario.NumeroTelefono;
                veterinarioEncontrado.Correo=veterinario.Correo;
                veterinarioEncontrado.Genero=veterinario.Genero;
                veterinarioEncontrado.TarjetaProfesional=veterinario.TarjetaProfesional;
                veterinarioEncontrado.CodigoProfesional=veterinario.CodigoProfesional;

                _appContext.SaveChanges();
            }
            return veterinarioEncontrado;
        } 
        void IRepositorioVeterinario.DeleteVeterinario(int idPersona) 
        {
            var veterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(c =>c.Id == idPersona);
            if (veterinarioEncontrado == null)
                return;
            _appContext.Veterinarios.Remove(veterinarioEncontrado);
            _appContext.SaveChanges();

        }
        Veterinario IRepositorioVeterinario.GetVeterinario(int idPersona)
        {
            return _appContext.Veterinarios.FirstOrDefault(c =>c.Id == idPersona);
            }
            

        IEnumerable<Veterinario> IRepositorioVeterinario.GetAllVeterinario()
        {
            return _appContext.Veterinarios;
        } 
    }
}