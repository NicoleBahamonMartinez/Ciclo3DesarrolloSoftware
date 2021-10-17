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
    public class EditModelMascota : PageModel
    {
        private readonly IRepositorioMascota repositorioMascotaDataBase;
        [BindProperty]
        public Mascota Mascota { get; set; }

        public EditModelMascota(IRepositorioMascota repositorioMascotaDataBase)
        {
            this.repositorioMascotaDataBase = repositorioMascotaDataBase;
        }
        public IActionResult OnGet(int? mascotaid)
        {
            if (mascotaid.HasValue)
            {
                Mascota = repositorioMascotaDataBase.GetMascotaPorId(mascotaid.Value);
            }
            else
            {
                Mascota = new Mascota();
            }
            if (Mascota == null)
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
            if(Mascota.id>0)
            {
            Mascota.Dueño=new Dueño{Nombres=Request.Form["Mascota.Dueño.Nombres"]};
            Mascota = repositorioMascotaDataBase.Update(Mascota);
            }
            else
            {
                Mascota.Dueño=new Dueño{Nombres=Request.Form["Mascota.Dueño.Nombres"]};
                Console.WriteLine("Crea dueño");
                repositorioMascotaDataBase.AddMascota(Mascota);
            }
            return Page();
        }


    }
}