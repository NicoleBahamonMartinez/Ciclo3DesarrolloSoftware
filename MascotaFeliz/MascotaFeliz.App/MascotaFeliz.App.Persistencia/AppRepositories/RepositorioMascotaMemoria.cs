using System.Collections.Generic;
using MascotaFeliz.App.Dominio;
using System.Linq;
using System;


namespace MascotaFeliz.App.Persistencia.AppRepositories
{
    public class RepositorioMascotaMemoria : IRepositorioMascota
    {
        List<Mascota> mascotas;
        public RepositorioMascotaMemoria(){
            Dueño dueño = new Dueño{Id=1010247041,TipoId="Cedula de Ciudadania",Nombres="Nicole",Apellidos="Bahamón Martínez",NumeroTelefono="3204756531",Correo="nbahamon@gmail.com",Ciudad="Ibague",Direccion="Cra 33a",Pais="Colombia",Genero="Femenino"};
            mascotas=new List<Mascota>{
                 new Mascota { id = 1, Nombre = "Manotas", Edad = 12, Tipo = "Perro", Raza = "Pastor Aleman", Color = "Negro", Dueño = dueño},
                 new Mascota { id = 2, Nombre = "Phoenix", Edad = 3, Tipo = "Gato", Raza = "Criollo", Color = "Gris", Dueño = dueño },};

        }
        public Mascota AddMascota(Mascota nuevaMascota)
        {
            nuevaMascota.id = mascotas.Max(r => r.id) + 1;
            mascotas.Add(nuevaMascota);
            return nuevaMascota;
        }

        public void DeleteMascota(int Idmascota)
        {
            var mascotaEncontrada=mascotas.FirstOrDefault(m => m.id == Idmascota);
            if (mascotaEncontrada==null)
                return;
            mascotas.Remove(mascotaEncontrada);
        }

        public IEnumerable<Mascota> GetAllMascota()
        {
            return mascotas;
        }

        public IEnumerable<Mascota> GetMascotaPorFiltro(string filtro)
        {
            var mascotas= GetAllMascota();
            if (mascotas != null)
            {
                if(!String.IsNullOrEmpty(filtro)){
                    mascotas=mascotas.Where(m => m.Nombre.Contains(filtro));
                }
            }
            return mascotas;
        }

        public Mascota GetMascotaPorId(int Idmascota)
        {
            return mascotas.SingleOrDefault(m => m.id == Idmascota);
        }

        public Mascota Update(Mascota mascotaActualizada)
        {
            var mascota=mascotas.SingleOrDefault(m => m.id == mascotaActualizada.id);
            if(mascota!=null){
                mascota.Color=mascotaActualizada.Color;
                mascota.Edad=mascotaActualizada.Edad;
                mascota.Nombre=mascotaActualizada.Nombre;
                mascota.Raza=mascotaActualizada.Raza;
                mascota.Tipo=mascotaActualizada.Tipo;
                mascota.Dueño=mascotaActualizada.Dueño;
            }
            return mascota;
        }
    }
}