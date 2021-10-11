using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MascotaFeliz.App.Persistencia.AppRepositories;
using MascotaFeliz.App.Dominio;

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MascotaFeliz.App.Frontend.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly iRepositorioVisitaDomiciliaria repositorioVisitaDomiciliaria;
        public VisitaDomiciliaria vd { get; set; }

        public DetailsModel(iRepositorioVisitaDomiciliaria repositorioVisitaDomiciliaria)
        {
            this.repositorioVisitaDomiciliaria = repositorioVisitaDomiciliaria;
        }
        public IActionResult OnGet(int? saludoId)
        {
            if (saludoId.HasValue)
            {
                vd = repositorioVisitaDomiciliaria.GetVisitaDomiciliaria(saludoId.Value);
                Console.WriteLine("Encontro Visita");
            }
            else
            {
                vd = new VisitaDomiciliaria();
            }
            if(vd==null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();

        }
    }
}
