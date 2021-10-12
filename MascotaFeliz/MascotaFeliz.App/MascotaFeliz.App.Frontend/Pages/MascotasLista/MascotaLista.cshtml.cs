using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MascotaFeliz.App.Frontend.Pages
{
    public class ListModel : PageModel
    {
       //private string[] mascota = { "Buenos dias", "Buenas tardes", "Buenas noches", "Hasta mañana" };
       // public List<string> ListaMascota { get; set; }
       private readonly IRepositorioMascota repositorioMascota;
       public IEnumerable<Mascota> Mascota {get;set;}

       [BindProperty(SupportsGet =true)]
       public string FiltroBusqueda { get; set; }


       public ListModel(IRepositorioMascota repositorioMascota)
       {
            this.repositorioMascota=repositorioMascota;
       }
       
        public void OnGet(string filtroBusqueda)
        {
           // ListaMascota = new List<string>();
           // ListaMascota.AddRange(mascotas);
          FiltroBusqueda=filtroBusqueda;
          Mascota=repositorioMascota.GetMascotaPorFiltro(filtroBusqueda);

        }
    }
}
