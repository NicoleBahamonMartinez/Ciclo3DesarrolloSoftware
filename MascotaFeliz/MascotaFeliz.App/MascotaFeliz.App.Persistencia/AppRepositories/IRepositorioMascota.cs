using MascotaFeliz.App.Dominio;
using System.Collections.Generic;


namespace MascotaFeliz.App.Persistencia

{
    public interface IRepositorioMascota
    {
        IEnumerable<Mascota> GetAllMascota();
        Mascota Add(Mascota nuevaMascota);
        Mascota Update(Mascota mascotaActualizada);
        //void DeleteMascota(int idmascota);
        IEnumerable<Mascota> GetMascotaPorFiltro(string filtro);
        Mascota GetMascotaPorId(int idmascota);
    }
}
