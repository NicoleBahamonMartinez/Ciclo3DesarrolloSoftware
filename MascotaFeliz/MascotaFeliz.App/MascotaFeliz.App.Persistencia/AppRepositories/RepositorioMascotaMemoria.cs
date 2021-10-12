using System;
using System.Collections.Generic;
using MascotaFeliz.App.Dominio;
using System.Linq;


namespace MascotaFeliz.App.Persistencia
{
   public class RepositorioMascotaMemoria : IRepositorioMascota
 {
        
        List<Mascota> mascotas;
        
        public RepositorioMascotaMemoria()
        {
            mascotas = new List<Mascota>
            {
                new Mascota { id = 1, Nombre = "chiqui", Edad = "6", Tipo = "gato", Raza = "criollo", Color = "gris", Dueño = "Alejandro" },
                new Mascota { id = 2, Nombre = "katy", Edad = "7", Tipo = "perro", Raza = "criollo", Color = "gris", Dueño = "luis" },
                new Mascota { id = 3, Nombre = "toma", Edad = "9", Tipo = "gato", Raza = "criollo", Color = "gris", Dueño = "matias" },
            };
        }

    


        public Mascota Add(Mascota nuevaMascota)
        {
            nuevaMascota.id=mascotas.Max(r => r.id) +1;
            mascotas.Add(nuevaMascota);
            
            return nuevaMascota;
        }

        public IEnumerable<Mascota> GetAllMascota()
        {
            return mascotas;
        }

        public Mascota Update(Mascota mascotaActualizada)
        {
            var mascota= mascotas.SingleOrDefault(r => r.id==mascotaActualizada.id);
            if (mascota!=null)
            {
                 mascota.id = mascotaActualizada.id;
                mascota.Nombre = mascotaActualizada.Nombre;
                mascota.Edad = mascotaActualizada.Edad;
                mascota.Tipo = mascotaActualizada.Tipo;
                mascota.Raza = mascotaActualizada.Raza;
                mascota.Color = mascotaActualizada.Color;
                mascota.Dueño = mascotaActualizada.Dueño;
                //_appContext.SaveChanges();
            }
            return mascota;
        }

        /*public void DeleteMascota(int idmascota)
        {
            var MascotaEncontrada=Mascota.FirstOrDefault(m => m.id==idmascota);
            if (MascotaEncontrada==null)
                return;
            Mascota.Remove(MascotaEncontrada);
            //Mascota.SaveChanges();  
        }*/


        public IEnumerable<Mascota> GetMascotaPorFiltro(string filtro=null)
        {
            var mascotas = GetAllMascota(); // Obtiene todos las mascota
            if (mascotas != null)  //Si se tienen mascotas
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    mascotas = mascotas.Where(m => m.Nombre.Contains(filtro)); 
                    /// <summary>
                    /// Filtra los mensajes que contienen el filtro
                    /// </summary>
                }
            }
            return mascotas;
        }

        public Mascota GetMascotaPorId(int idmascota)
        {
            return mascotas.FirstOrDefault(m => m.id==idmascota);
        }

        
        
    }
}