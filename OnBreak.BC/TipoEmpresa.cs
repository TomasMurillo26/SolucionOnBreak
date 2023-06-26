using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.BC
{
    public class TipoEmpresa
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public TipoEmpresa()
        {
            this.Init();
        }

        private void Init()
        {
            Id = 0;
            Descripcion = string.Empty;
        }
        public List<TipoEmpresa> ReadAll()
        {
            //Crear una conexión al Entities
            DB.onbreakEntities DB = new DB.onbreakEntities();
            try
            {
                //Crear una lista de DATOS
                List<DB.TipoEmpresa> listaDatos = DB.TipoEmpresa.ToList();
                //Crear una lista de NEGOCIO
                List<TipoEmpresa> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception)
            {
                return new List<TipoEmpresa>();
            }
        }

        private List<TipoEmpresa> GenerarListado(List<DB.TipoEmpresa> listaDatos)
        {
            List<TipoEmpresa> listaNegocio = new List<TipoEmpresa>();
            foreach (DB.TipoEmpresa datos in listaDatos)
            {
                TipoEmpresa negocio = new TipoEmpresa();
                CommonBC.Syncronize(datos, negocio);
                listaNegocio.Add(negocio);
            }
            return listaNegocio;
        }

        public bool Create()
        {
            //Crear una conexión al Entities
            DB.onbreakEntities DB = new DB.onbreakEntities();
            DB.TipoEmpresa tipoEmpresa = new DB.TipoEmpresa();
            try
            {
                //sincronizo el contenido de las propiedades a la DB
                CommonBC.Syncronize(this, tipoEmpresa);
                DB.TipoEmpresa.Add(tipoEmpresa);
                DB.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                DB.TipoEmpresa.Remove(tipoEmpresa);
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
                DB.TipoEmpresa tipoEmpresa =
                    DB.TipoEmpresa.First(e => e.Id.Equals(this.Id));
                CommonBC.Syncronize(tipoEmpresa, this);

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
                DB.TipoEmpresa tipoEmpresa =
                    DB.TipoEmpresa.First(e => e.Id.Equals(this.Id));
                CommonBC.Syncronize(this, tipoEmpresa);
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
                DB.TipoEmpresa tipoEmpresa =
                    DB.TipoEmpresa.First(e => e.Id.Equals(this.Id));
                DB.TipoEmpresa.Remove(tipoEmpresa);
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
