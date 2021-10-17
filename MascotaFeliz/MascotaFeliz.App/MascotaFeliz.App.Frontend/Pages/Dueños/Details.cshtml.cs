using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia.AppRepositories;

namespace MascotaFeliz.App.Presentacion.Pages
{
    public class DetailsModelDueño : PageModel
    {
        private readonly IRepositorioDueño repositorioDueños;

        public Dueño Dueño {set;get;}

        public DetailsModelDueño(IRepositorioDueño repositorioDueño)
        {
            this.repositorioDueños=repositorioDueño;
        }
        public IActionResult OnGet(int dueñoId)
        {
            Dueño = repositorioDueños.GetDueño(dueñoId);
            if(Dueño==null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page ();
            }
        }
    }
}
