using System.Collections.Generic;
using MascotaFeliz.App.Dominio;
using System.Linq;
using System;

namespace MascotaFeliz.App.Persistencia.AppRepositories
{
    public class RepositorioMascotaDataBase : IRepositorioMascota
    {
        private readonly AppContext _appContext;
        
        public RepositorioMascotaDataBase(AppContext appContext)
        {
          _appContext = appContext;

        }

        Mascota IRepositorioMascota.AddMascota(Mascota nuevaMascota)
        {
            var mascotaAdicionada = _appContext.Mascotas.Add(nuevaMascota);
            _appContext.SaveChanges();
            return mascotaAdicionada.Entity;
        }

         void IRepositorioMascota.DeleteMascota(int Idmascota)
        {
            var mascotaEncontrada = _appContext.Mascotas.FirstOrDefault(m => m.id == Idmascota);
            if (mascotaEncontrada == null)
                return; 
            _appContext.Mascotas.Remove(mascotaEncontrada);
            _appContext.SaveChanges();
        }

         IEnumerable<Mascota> IRepositorioMascota.GetAllMascota()
        { 
            return _appContext.Mascotas;
        }

        Mascota IRepositorioMascota.GetMascotaPorId(int Idmascota)
        {
            return _appContext.Mascotas.FirstOrDefault(m => m.id == Idmascota);


        }

        Mascota IRepositorioMascota.Update(Mascota mascotaActualizada)
        {
            var mascotaEncontrada = _appContext.Mascotas.FirstOrDefault(m => m.id == mascotaActualizada.id);
            if (mascotaEncontrada != null)
            {
                mascotaEncontrada.id = mascotaActualizada.id;
                mascotaEncontrada.Nombre = mascotaActualizada.Nombre;
                mascotaEncontrada.Edad = mascotaActualizada.Edad;
                mascotaEncontrada.Tipo = mascotaActualizada.Tipo;
                mascotaEncontrada.Raza = mascotaActualizada.Raza;
                mascotaEncontrada.Color = mascotaActualizada.Color;
                mascotaEncontrada.Dueño = mascotaActualizada.Dueño;
    
                _appContext.SaveChanges();

            }
            return mascotaEncontrada;
        }
        public IEnumerable<Mascota> GetMascotaPorFiltro(string filtro = null) // el parámetro es opcional 
        {
            List<Mascota> Mascotas;
            DateTime fecha1 = new DateTime(2010, 8, 18);
            DateTime fecha2 = new DateTime(2021, 5, 30);
            DateTime fecha3 = new DateTime(2019, 2, 15);
            Dueño dueño = new Dueño { Direccion = "Cra 33A#26a-12", Ciudad = "Bogotá", Pais = "Colombia" };
            Veterinario veterinario = new Veterinario { TarjetaProfesional = "ULALA", CodigoProfesional = 12345 };
            Mascota mascota1 = new Mascota { id = 1, Nombre = "Manotas", Edad = 12, Tipo = "Perro", Raza = "Pastor Aleman", Color = "Negro", Dueño=dueño };
            Mascota mascota2 = new Mascota { id = 2, Nombre = "Phoenix", Edad = 3, Tipo = "Gato", Raza = "Criollo", Color = "Gris", Dueño = dueño};

            Mascotas = new List<Mascota>{
                new Mascota{id=1,Edad=5,Tipo="perro",Raza="pitbull",Color="gris",Dueño=dueño},
                new Mascota{id=2,Edad=6,Tipo="gato",Raza="criollo",Color="negro",Dueño=dueño},
                new Mascota{id=3,Edad=7,Tipo="perro",Raza="pitbull",Color="blanco",Dueño=dueño},
                new Mascota{id=4,Edad=8,Tipo="perro",Raza="doverman",Color="negro",Dueño=dueño},
                new Mascota{id=5,Edad=9,Tipo="gato",Raza="criollo",Color="amarillo",Dueño=dueño},
            };
            return Mascotas;
        }
    }
}
