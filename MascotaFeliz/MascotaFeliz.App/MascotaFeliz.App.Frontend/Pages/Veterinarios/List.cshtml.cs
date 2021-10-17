using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using MascotaFeliz.App.Persistencia.AppRepositories;

namespace MascotaFeliz.App.Presentacion.Pages
{
    public class ListModelVeterinario : PageModel
    {
        private readonly IRepositorioVeterinario repositorioVeterinarios;
        public IEnumerable<Veterinario> Veterinarios { set; get; }

        public ListModelVeterinario(IRepositorioVeterinario repositorioVeterinario)
        {
            this.repositorioVeterinarios = repositorioVeterinario;
        }

        public void OnGet(string filtroBusqueda)
        {
            Veterinarios = repositorioVeterinarios.GetAllVeterinario();
        }
    }
}
