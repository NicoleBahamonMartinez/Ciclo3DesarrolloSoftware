using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MascotaFeliz.App.Persistencia.AppRepositories;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Frontend.Pages
{
    public class ListModel : PageModel
    {
        private readonly iRepositorioVisitaDomiciliaria repositorioVisitasDomiciliarias;
        public IEnumerable<VisitaDomiciliaria> visitaDomiciliarias { get; set; }
        [BindProperty(SupportsGet = true)]
        public string FiltroBusqueda { get; set; }

        // private string[] VisitasDomiciliarias = { "Visita1", "Visita2", "Visita3", "Visita4" };
        // public List<string> ListaVisitasDomiciliarias { get; set; }
        // private readonly iRepositorioVisitaDomiciliaria repositorioVisitaDomiciliaria;
        // public IEnumerable<VisitaDomiciliaria> VisitasDomiciliarias {get;set;}
        public ListModel(iRepositorioVisitaDomiciliaria repositorioVisitaDomiciliaria)
        {
            this.repositorioVisitasDomiciliarias = repositorioVisitaDomiciliaria;
        }
        public void OnGet(string filtroBusqueda)
        {
            FiltroBusqueda=filtroBusqueda;
            visitaDomiciliarias=repositorioVisitasDomiciliarias.GetVisitasDomiciliariaPorFiltro(filtroBusqueda);
        }
    }

}