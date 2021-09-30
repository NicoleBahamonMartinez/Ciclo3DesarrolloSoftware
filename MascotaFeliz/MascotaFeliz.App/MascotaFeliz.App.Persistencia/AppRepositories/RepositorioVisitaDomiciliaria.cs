using System.Collections.Generic;
using MascotaFeliz.App.Dominio;
using System.Linq;

namespace MascotaFeliz.App.Persistencia.AppRepositories
{
    public class RepositorioVisitaDomiciliaria : iRepositorioVisitaDomiciliaria
    {
        private readonly AppContext _appContext;
        public RepositorioVisitaDomiciliaria(AppContext appContext){
            _appContext=appContext;
        }
        public VisitaDomiciliaria AddVisitaDomiciliaria(VisitaDomiciliaria pVisitaDomiciliaria)
        {
            var visitaDomiciliariaAdicionada=_appContext.VisitasDomiciliarias.Add(pVisitaDomiciliaria);
            _appContext.SaveChanges();
            return visitaDomiciliariaAdicionada.Entity;
        }

        public void DeleteVisitaDomiciliaria(int pId)
        {
            var visitaDomiciliariaEncontrada=_appContext.VisitasDomiciliarias.FirstOrDefault(vd => vd.Id==pId);
            if (visitaDomiciliariaEncontrada==null)
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
            return _appContext.VisitasDomiciliarias.FirstOrDefault(vd => vd.Id==pId);


        }

        public VisitaDomiciliaria UpdateVisitaDomiciliaria(VisitaDomiciliaria pVisitaDomiciliaria)
        {
            var visitaDomiciliariaEncontrada=_appContext.VisitasDomiciliarias.FirstOrDefault(vd => vd.Id==pVisitaDomiciliaria.Id);
            if (visitaDomiciliariaEncontrada!=null){
                visitaDomiciliariaEncontrada.FechaHoraVisita=pVisitaDomiciliaria.FechaHoraVisita;
                visitaDomiciliariaEncontrada.Temperatura=pVisitaDomiciliaria.Temperatura;
                visitaDomiciliariaEncontrada.Peso=pVisitaDomiciliaria.Peso;
                visitaDomiciliariaEncontrada.FrencuenciaCardiaca=pVisitaDomiciliaria.FrencuenciaCardiaca;
                visitaDomiciliariaEncontrada.FrencuenciaRespiratoria=pVisitaDomiciliaria.FrencuenciaRespiratoria;
                visitaDomiciliariaEncontrada.EstadoAnimo=pVisitaDomiciliaria.EstadoAnimo;
                visitaDomiciliariaEncontrada.Medicinas=pVisitaDomiciliaria.Medicinas;
                visitaDomiciliariaEncontrada.Remision=pVisitaDomiciliaria.Remision;
                visitaDomiciliariaEncontrada.Paciente=pVisitaDomiciliaria.Paciente;
                visitaDomiciliariaEncontrada.Encargado=pVisitaDomiciliaria.Encargado;
                _appContext.SaveChanges();
                
            }
            return visitaDomiciliariaEncontrada;
        }
    }
}