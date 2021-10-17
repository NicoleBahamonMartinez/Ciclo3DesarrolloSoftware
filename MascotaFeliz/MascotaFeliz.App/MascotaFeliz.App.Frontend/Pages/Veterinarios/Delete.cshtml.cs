using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MascotaFeliz.App.Persistencia;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia.AppRepositories;
namespace MascotaFeliz.App.Presentacion.Pages
{
       public class DeleteModelVeterinario : PageModel
    {
        private readonly IRepositorioVeterinario repositorioVeterinarios;
        [BindProperty]

        public Veterinario Veterinario{set;get;}

        public DeleteModelVeterinario(IRepositorioVeterinario repositorioVeterinario)
        {
            this.repositorioVeterinarios=repositorioVeterinario;
        }
        public IActionResult OnGet(int? veterinarioId)
        {
            if (veterinarioId.HasValue)
            {
                Veterinario = repositorioVeterinarios.GetVeterinario(veterinarioId.Value);
            }
            if (Veterinario == null)
            {
                return RedirectToPage("./Notfound");
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost()
        {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                if (Veterinario.Id>0)
                {
                    repositorioVeterinarios.DeleteVeterinario(Veterinario.Id);
                }
                else
                {
                    repositorioVeterinarios.AddVeterinario(Veterinario);
                }
                return Page();
        }
        
    }
}


