using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;


namespace MascotaFeliz.App.Persistencia.AppRepositories

{
    public interface IRepositorioMascota
    {
        IEnumerable<Mascota> GetAllMascota();
        Mascota AddMascota(Mascota nuevaMascota);
        Mascota Update(Mascota mascotaActualizada);
        void DeleteMascota(int Idmascota);
        IEnumerable<Mascota> GetMascotaPorFiltro(string filtro);
        Mascota GetMascotaPorId(int Idmascota);
    }
}
