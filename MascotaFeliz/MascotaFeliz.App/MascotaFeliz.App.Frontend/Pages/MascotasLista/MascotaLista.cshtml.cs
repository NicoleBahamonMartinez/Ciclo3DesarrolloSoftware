using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia.AppRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace MascotaFeliz.App.Frontend.Pages
{
    public class ListModelMascota : PageModel
    {
       
       // public List<string> ListaMascota { get; set; }
       private readonly IRepositorioMascota repositorioMascotaDataBase;
       public IEnumerable<Mascota> Mascota {get;set;}
       [BindProperty(SupportsGet =true)]
       public string FiltroBusqueda { get; set; }


       public ListModelMascota(IRepositorioMascota repositorioMascota)
       {
            this.repositorioMascotaDataBase=repositorioMascota;
       }
       
        public void OnGet(string filtroBusqueda)
        {
          FiltroBusqueda=filtroBusqueda;  
          Mascota=repositorioMascotaDataBase.GetMascotaPorFiltro(FiltroBusqueda);

        }
    }
}
