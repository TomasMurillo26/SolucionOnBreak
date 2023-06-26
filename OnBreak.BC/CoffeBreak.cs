using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.BC
{
    public class CoffeeBreak
    {
        public string Numero { get; set; }
        public bool Vegetariana { get; set; }

        public CoffeeBreak()
        {
            this.Init();
        }

        private void Init()
        {
            Numero = string.Empty;
            Vegetariana = false;
        }
        public bool Create()
        {
            //Crear una conexión al Entities
            DB.onbreakEntities DB = new DB.onbreakEntities();
            DB.CoffeeBreak coffee = new DB.CoffeeBreak();
            try
            {
                //sincronizo el contenido de las propiedades a la DB
                CommonBC.Syncronize(this, coffee);
                DB.CoffeeBreak.Add(coffee);
                DB.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                DB.CoffeeBreak.Remove(coffee);
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
                DB.CoffeeBreak coffee =
                    DB.CoffeeBreak.First(e => e.Numero.Equals(this.Numero));
                CommonBC.Syncronize(coffee, this);

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
                DB.CoffeeBreak coffee =
                    DB.CoffeeBreak.First(e => e.Numero.Equals(this.Numero));
                CommonBC.Syncronize(this, coffee);
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
                DB.CoffeeBreak coffee =
                    DB.CoffeeBreak.First(e => e.Numero.Equals(this.Numero));
                DB.CoffeeBreak.Remove(coffee);
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
