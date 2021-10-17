using System;
using MascotaFeliz.App.Dominio ;
using System.Collections.Generic;
using System.Linq;

namespace  MascotaFeliz.App.Persistencia.AppRepositories
{
    public interface IRepositorioVeterinario
    {
        IEnumerable<Veterinario> GetAllVeterinario();
        Veterinario AddVeterinario(Veterinario veterinario);
        Veterinario UpdateVeterinario(Veterinario veterinario);
        void DeleteVeterinario(int idVeterinario);
        Veterinario GetVeterinario(int idveterinario);
           
    }
}