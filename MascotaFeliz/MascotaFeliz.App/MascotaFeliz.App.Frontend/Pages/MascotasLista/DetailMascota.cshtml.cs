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

    public class DetailsModel : PageModel
    {
        private readonly IRepositorioMascota repositorioMascota;
        public Mascota Mascota { get; set; }

        public DetailsModel(IRepositorioMascota repositorioMascota)
        {
            this.repositorioMascota = repositorioMascota;
        }
        public IActionResult OnGet(int mascotaid)
        {
            Mascota = repositorioMascota.GetMascotaPorId(mascotaid);
            if(Mascota==null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();

        }
    }
}