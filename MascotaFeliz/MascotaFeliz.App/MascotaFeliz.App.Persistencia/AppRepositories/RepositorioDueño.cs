using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia.AppRepositories
{
    public class RepositorioDueño:IRepositorioDueño
    { 
        private readonly AppContext _appContext;
        
        public RepositorioDueño(AppContext appContext)
        {
            _appContext = appContext;
        }
        
        Dueño IRepositorioDueño.AddDueño(Dueño dueño)
        {
            var dueñoAdicionado = _appContext.Dueños.Add(dueño);
            _appContext.SaveChanges();
            return dueñoAdicionado.Entity;
        }

        Dueño IRepositorioDueño.UpdateDueño(Dueño dueño)
        {
            var dueñoEncontrado = _appContext.Dueños.FirstOrDefault(c => c.Id == dueño.Id);
            if (dueñoEncontrado != null)
                {
                    dueñoEncontrado.TipoId=dueño.TipoId;
                    dueñoEncontrado.Nombres=dueño.Nombres;
                    dueñoEncontrado.Apellidos=dueño.Apellidos;
                    dueñoEncontrado.NumeroTelefono=dueño.NumeroTelefono;

                    _appContext.SaveChanges();
                }
                return dueñoEncontrado;
        }
        void IRepositorioDueño.DeleteDueño(int idDueño)
        {
            var dueñoEncontrado = _appContext.Dueños.FirstOrDefault(c => c.Id == idDueño);
            if (dueñoEncontrado == null)
                return;
            _appContext.Dueños.Remove(dueñoEncontrado);
            _appContext.SaveChanges();
        }
        Dueño IRepositorioDueño.GetDueño(int TipoId)
        {
            return _appContext.Dueños.FirstOrDefault(c => c.Id == TipoId);
        } 

        IEnumerable<Dueño> IRepositorioDueño.GetAllDueños()
        {
            return _appContext.Dueños;
        }
    }
}

