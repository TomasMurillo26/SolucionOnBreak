using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.BC
{
    public class Cenas
    {
        public string Numero { get; set; }
        public int IdTipoAmbientacion { get; set; }
        public bool MusicaAmbiental { get; set; }
        public bool LocalOnBreak { get; set; }
        public bool OtroLocalOnBreak { get; set; }
        public double ValorArriendo { get; set; }

        public Cenas()
        {
            this.Init();
        }

        private void Init()
        {
            Numero = string.Empty;
            IdTipoAmbientacion = 0;
            MusicaAmbiental = false;
            LocalOnBreak = false;
            OtroLocalOnBreak = false;
            ValorArriendo = 0;
        }
        public bool Create()
        {
            //Se crea una conexión a Entities
            BD.OnbreakEntities bd = new BD.OnbreakEntities();
            BD.Cenas cenas = new BD.Cenas();
            try
            {
                //Sincronizo el contenido de las propiedades a la BD
                CommonBC.Syncronize(this, cenas);
                bd.Cenas.Add(cenas);
                bd.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                bd.Cenas.Remove(cenas);
                return false;
            }
        }

        public bool Read()
        {
            //Se crea una conexión a Entities
            BD.OnbreakEntities bd = new BD.OnbreakEntities();
            try
            {
                //Se busca el ID del elemento
                BD.Cenas cenas =
                    bd.Cenas.First(e => e.Numero.Equals(this.Numero));
                CommonBC.Syncronize(cenas, this);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update()
        {
            //Se crea una conexión a Entities
            BD.OnbreakEntities bd = new BD.OnbreakEntities();

            try
            {
                //Se busca el ID del elemento que se va a modificar
                BD.Cenas cenas =
                    bd.Cenas.First(e => e.Numero.Equals(this.Numero));
                CommonBC.Syncronize(this, cenas);
                bd.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete()
        {
            //Se crea una conexión a Entities
            BD.OnbreakEntities bd = new BD.OnbreakEntities();

            try
            {
                //Se busca el ID del elemento que se va a eliminar
                BD.Cenas cenas =
                    bd.Cenas.First(e => e.Numero.Equals(this.Numero));
                bd.Cenas.Remove(cenas);
                bd.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
