using MascotaFeliz.App.Dominio;
using System.Collections.Generic;

namespace MascotaFeliz.App.Persistencia.AppRepositories

{
    public interface iRepositorioVisitaDomiciliaria{
        IEnumerable<VisitaDomiciliaria> GetAllVisitasDomiciliaras();
        VisitaDomiciliaria AddVisitaDomiciliaria(VisitaDomiciliaria pVisitaDomiciliaria);
        VisitaDomiciliaria UpdateVisitaDomiciliaria(VisitaDomiciliaria pVisitaDomiciliaria); 
        void DeleteVisitaDomiciliaria(int pId);
        VisitaDomiciliaria GetVisitaDomiciliaria(int pId);
        IEnumerable<VisitaDomiciliaria> GetVisitasDomiciliariaPorFiltro(string filtro);
        
    }
}