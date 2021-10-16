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
    public class DeleteModel : PageModel
    {
        private readonly iRepositorioVisitaDomiciliaria repositorioVisitasDomiciliarias;
        [BindProperty]
        public VisitaDomiciliaria visitaDomiciliaria { get; set; }

        public DeleteModel(iRepositorioVisitaDomiciliaria repositorioSaludos)
        {
            this.repositorioVisitasDomiciliarias = repositorioSaludos;
        }
        public IActionResult OnGet(int? visitaDomiciliariaId)
        {
            if (visitaDomiciliariaId.HasValue)
            {
                visitaDomiciliaria = repositorioVisitasDomiciliarias.GetVisitaDomiciliaria(visitaDomiciliariaId.Value);
                Console.WriteLine("Encontro Visita");
            }
            if (visitaDomiciliaria == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page();

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (visitaDomiciliaria.Id > 0)
            {
                repositorioVisitasDomiciliarias.DeleteVisitaDomiciliaria(visitaDomiciliaria.Id);
            }
            return Page();
        }


    }

}

