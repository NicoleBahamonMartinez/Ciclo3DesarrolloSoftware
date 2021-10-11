using  MascotaFeliz.App.Dominio ;
using  System.Collections.Generic;

namespace MascotaFeliz.App.Persistencia.AppRepositories
{
    public interface iRepositorioDueño
    {
        IEnumerable<Dueño> GetAllDueño();
        Dueño AddDueño(Dueño dueño);
        Dueño UpdateDueño(Dueño dueño);
        void deleteDueño(int idDueño);
        Dueño GetDueño(int idDueño);
           
    }
}