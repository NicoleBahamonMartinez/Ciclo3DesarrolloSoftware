using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MascotaFeliz.App.Persistencia.AppRepositories;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Presentacion.Pages
{
    public class DeleteModelDueño : PageModel
    {
        private readonly IRepositorioDueño repositorioDueños;
        [BindProperty]

        public Dueño Dueño {set;get;}

        public DeleteModelDueño(IRepositorioDueño repositorioDueño)
        {
            this.repositorioDueños=repositorioDueño;
        }
        public IActionResult OnGet(int? dueñoId)
        {
            if (dueñoId.HasValue)
            {
                Dueño = repositorioDueños.GetDueño(dueñoId.Value);
            }
            if (Dueño == null)
            {
                return RedirectToPage("./NotFound"); 
            }
            else
            {
                return Page();
            }
        }
        public IActionResult OnPost()
        {
                
            if(!ModelState.IsValid)
            {
                return Page();      
            }
            if (Dueño.Id>0)
            {
                repositorioDueños.DeleteDueño(Dueño.Id);                
            }
            else
            {
                repositorioDueños.AddDueño(Dueño);
            }
            return Page();
        }
      
    }
}

