using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.BC
{
    public class ActividadEmpresa
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public ActividadEmpresa()
        {
            this.Init();
        }

        private void Init()
        {
            Id = 0;
            Descripcion = string.Empty;

        }
        public List<ActividadEmpresa> ReadAll()
        {
            //Crear una conexión al Entities
            DB.onbreakEntities DB = new DB.onbreakEntities();
            try
            {
                //Crear una lista de DATOS
                List<DB.ActividadEmpresa> listaDatos = DB.ActividadEmpresa.ToList();
                //Crear una lista de NEGOCIO
                List<ActividadEmpresa> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception)
            {
                return new List<ActividadEmpresa>();
            }
        }

        private List<ActividadEmpresa> GenerarListado(List<DB.ActividadEmpresa> listaDatos)
        {
            List<ActividadEmpresa> listaNegocio = new List<ActividadEmpresa>();
            foreach (DB.ActividadEmpresa datos in listaDatos)
            {
                ActividadEmpresa negocio = new ActividadEmpresa();
                CommonBC.Syncronize(datos, negocio);
                listaNegocio.Add(negocio);
            }
            return listaNegocio;
        }

        public bool Create()
        {
            //Crear una conexión al Entities
            DB.onbreakEntities DB = new DB.onbreakEntities();
            DB.ActividadEmpresa actividadEmpresa = new DB.ActividadEmpresa();
            try
            {
                //sincronizo el contenido de las propiedades a la DB
                CommonBC.Syncronize(this, actividadEmpresa);
                DB.ActividadEmpresa.Add(actividadEmpresa);
                DB.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                DB.ActividadEmpresa.Remove(actividadEmpresa);
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
                DB.ActividadEmpresa actividadEmpresa =
                    DB.ActividadEmpresa.First(e => e.Id.Equals(this.Id));
                CommonBC.Syncronize(actividadEmpresa, this);

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
                DB.ActividadEmpresa actividadEmpresa =
                    DB.ActividadEmpresa.First(e => e.Id.Equals(this.Id));
                CommonBC.Syncronize(this, actividadEmpresa);
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
                DB.ActividadEmpresa actividadEmpresa =
                    DB.ActividadEmpresa.First(e => e.Id.Equals(this.Id));
                DB.ActividadEmpresa.Remove(actividadEmpresa);
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
