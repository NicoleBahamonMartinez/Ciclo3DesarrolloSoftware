using  MascotaFeliz.App.Dominio ;
using  System.Collections.Generic;
using System;
using System.Linq;

namespace  MascotaFeliz.App.Persistencia.AppRepositories
{
    public interface IRepositorioDueño
    {
        IEnumerable<Dueño> GetAllDueños();
        Dueño AddDueño(Dueño dueño);
        Dueño UpdateDueño(Dueño dueño);
        void DeleteDueño(int idDueño);
        Dueño GetDueño(int idDueño);
           
    }
}
