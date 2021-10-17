using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia.AppRepositories;
using Microsoft.AspNetCore.Authorization;


namespace MascotaFeliz.App.Presentacion.Pages
{
    public class ListModelDueño : PageModel
    {
        private readonly IRepositorioDueño repositorioDueños;
        public IEnumerable<Dueño> Dueños {set;get;}
        [BindProperty(SupportsGet =true)]
        public string FiltroBusqueda {get;set;}
        public ListModelDueño(IRepositorioDueño repositorioDueño) 
        {
             this.repositorioDueños=repositorioDueño;
        }
        public void OnGet(string filtroBusqueda)
        {
            FiltroBusqueda=filtroBusqueda;
            Dueños = repositorioDueños.GetAllDueños();
        }
    }
}
