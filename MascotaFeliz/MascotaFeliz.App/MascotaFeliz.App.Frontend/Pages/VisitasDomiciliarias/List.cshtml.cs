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
        //private string[] VisitasDomiciliarias={"Visita1","Visita2","Visita3","Visita4"};
        //public List<string> ListaVisitasDomiciliarias {get;set;}
        private readonly iRepositorioVisitaDomiciliaria repositorioVisitaDomiciliaria;
        public IEnumerable<VisitaDomiciliaria> VisitasDomiciliarias {get;set;}
        public ListModel(iRepositorioVisitaDomiciliaria repositorioVisitaDomiciliaria){
            this.repositorioVisitaDomiciliaria=repositorioVisitaDomiciliaria;
        }
        public void OnGet()
        {
            //ListaVisitasDomiciliarias=new List<string>();
            //ListaVisitasDomiciliarias.AddRange(VisitasDomiciliarias);
            VisitasDomiciliarias=repositorioVisitaDomiciliaria.GetAllVisitasDomiciliaras();
        }
    }
}
