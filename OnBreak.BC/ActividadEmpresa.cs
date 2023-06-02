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
            BD.OnbreakEntities bd = new BD.OnbreakEntities();
            try
            {
                //Crear una lista de DATOS
                List<BD.ActividadEmpresa> listaDatos = bd.ActividadEmpresa.ToList();
                //Crear una lista de NEGOCIO
                List<ActividadEmpresa> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception)
            {
                return new List<ActividadEmpresa>();
            }
        }

        private List<ActividadEmpresa> GenerarListado(List<BD.ActividadEmpresa> listaDatos)
        {
            List<ActividadEmpresa> listaNegocio = new List<ActividadEmpresa>();
            foreach (BD.ActividadEmpresa datos in listaDatos)
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
            BD.OnbreakEntities bd = new BD.OnbreakEntities();
            BD.ActividadEmpresa actividadEmpresa = new BD.ActividadEmpresa();
            try
            {
                //sincronizo el contenido de las propiedades a la BD
                CommonBC.Syncronize(this, actividadEmpresa);
                bd.ActividadEmpresa.Add(actividadEmpresa);
                bd.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                bd.ActividadEmpresa.Remove(actividadEmpresa);
                return false;
            }
        }

        public bool Read()
        {
            //Crear una conexión al Entities
            BD.OnbreakEntities bd = new BD.OnbreakEntities();
            try
            {
                //busco por el id el contenido de la entidad
                BD.ActividadEmpresa actividadEmpresa =
                    bd.ActividadEmpresa.First(e => e.Id.Equals(this.Id));
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
            BD.OnbreakEntities bd = new BD.OnbreakEntities();

            try
            {
                //busco por el id el contenido de la entidad a modificar
                BD.ActividadEmpresa actividadEmpresa =
                    bd.ActividadEmpresa.First(e => e.Id.Equals(this.Id));
                CommonBC.Syncronize(this, actividadEmpresa);
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
            //Crear una conexión al Entities
            BD.OnbreakEntities bd = new BD.OnbreakEntities();

            try
            {
                //busco por el id el contenido de la entidad a eliminar
                BD.ActividadEmpresa actividadEmpresa =
                    bd.ActividadEmpresa.First(e => e.Id.Equals(this.Id));
                bd.ActividadEmpresa.Remove(actividadEmpresa);
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
