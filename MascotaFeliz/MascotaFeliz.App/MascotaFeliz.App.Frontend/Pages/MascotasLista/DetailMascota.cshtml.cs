using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia.AppRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MascotaFeliz.App.Frontend.Pages
{

    public class DetailsModelMascota : PageModel
    {
        private readonly IRepositorioMascota repositorioMascotaDataBase;
        public Mascota m { get; set; }

        public DetailsModelMascota(IRepositorioMascota repositorioMascotaDataBase)
        {
            this.repositorioMascotaDataBase = repositorioMascotaDataBase;
        }
        public IActionResult OnGet(int? mascotaId)
        {
            if (mascotaId.HasValue)
            {
                m = repositorioMascotaDataBase.GetMascotaPorId(mascotaId.Value);
                Console.WriteLine("Encontro Visita");
            }
            else
            {
                m = new Mascota();
            }
            if(m==null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();

        }
    }
}