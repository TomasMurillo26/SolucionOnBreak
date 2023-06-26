using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.BC
{
    public class Cocktail
    {
        public string Numero { get; set; }
        public int IdTipoAmbientacion { get; set; }
        public bool Ambientacion { get; set; }
        public bool MusicaAmbiental { get; set; }
        public bool MusicaCliente { get; set; }

        public Cocktail()
        {
            this.Init();
        }
        private void Init()
        {
            Numero = string.Empty;
            IdTipoAmbientacion = 0;
            Ambientacion = false;
            MusicaAmbiental = false;
            MusicaCliente = false;
        }
        public bool Create()
        {
            //Crear una conexión al Entities
            DB.onbreakEntities DB = new DB.onbreakEntities();
            DB.Cocktail cocktail = new DB.Cocktail();
            try
            {
                //sincronizo el contenido de las propiedades a la DB
                CommonBC.Syncronize(this, cocktail);
                DB.Cocktail.Add(cocktail);
                DB.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                DB.Cocktail.Remove(cocktail);
                return false;
            }
        }

        public bool Read()
        {
            //Crear una conexión al Entities
            DB.onbreakEntities DB = new DB.onbreakEntities();
            try
            {
                //busco por el id el contenido de la entidad
                DB.Cocktail cocktail =
                    DB.Cocktail.First(e => e.Numero.Equals(this.Numero));
                CommonBC.Syncronize(cocktail, this);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update()
        {
            //Crear una conexión al Entities
            DB.onbreakEntities DB = new DB.onbreakEntities();

            try
            {
                //busco por el id el contenido de la entidad a modificar
                DB.Cocktail cocktail =
                    DB.Cocktail.First(e => e.Numero.Equals(this.Numero));
                CommonBC.Syncronize(this, cocktail);
                DB.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete()
        {
            //Crear una conexión al Entities
            DB.onbreakEntities DB = new DB.onbreakEntities();

            try
            {
                //busco por el id el contenido de la entidad a eliminar
                DB.Cocktail cocktail =
                    DB.Cocktail.First(e => e.Numero.Equals(this.Numero));
                DB.Cocktail.Remove(cocktail);
                DB.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
