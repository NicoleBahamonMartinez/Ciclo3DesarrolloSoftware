using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;
using MascotaFeliz.App.Persistencia.AppRepositories;

namespace MascotaFeliz.App.Presentacion.Pages
{
    public class DetailsModelVeterinario : PageModel
    {
        private readonly IRepositorioVeterinario repositorioVeterinarios;
        
        public Veterinario Veterinario {set;get;}

        public DetailsModelVeterinario(IRepositorioVeterinario repositorioVeterinario)
        {
            this.repositorioVeterinarios=repositorioVeterinario;
        }
        public IActionResult OnGet(int veterinarioId)
        {
            Veterinario = repositorioVeterinarios.GetVeterinario(veterinarioId);
            if (Veterinario==null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
              return Page(); 
            }
        }
    }
}
