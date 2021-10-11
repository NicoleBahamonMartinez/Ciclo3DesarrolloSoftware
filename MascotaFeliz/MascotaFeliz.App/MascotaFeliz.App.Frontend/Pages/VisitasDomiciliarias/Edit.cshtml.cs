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
    public class EditModel : PageModel
    {
       private readonly iRepositorioVisitaDomiciliaria repositorioVisitasDomiciliarias;
        [BindProperty]
        public VisitaDomiciliaria visitaDomiciliaria { get; set; }

        public EditModel(iRepositorioVisitaDomiciliaria repositorioSaludos)
        {
            this.repositorioVisitasDomiciliarias = repositorioSaludos;
        }
        public IActionResult OnGet(int? saludoId)
        {
            if (saludoId.HasValue)
            {
                visitaDomiciliaria = repositorioVisitasDomiciliarias.GetVisitaDomiciliaria(saludoId.Value);
                Console.WriteLine("Encontro Visita");
            }
            else
            {
                visitaDomiciliaria = new VisitaDomiciliaria();
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
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if(visitaDomiciliaria.Id>0)
            {
            visitaDomiciliaria = repositorioVisitasDomiciliarias.UpdateVisitaDomiciliaria(visitaDomiciliaria);
            }
            else
            {
             repositorioVisitasDomiciliarias.AddVisitaDomiciliaria(visitaDomiciliaria);
            }
            return Page();
        }


    }
}
