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
            BD.OnbreakEntities bd = new BD.OnbreakEntities();
            try
            {
                //Crear una lista de DATOS
                List<BD.TipoEmpresa> listaDatos = bd.TipoEmpresa.ToList();
                //Crear una lista de NEGOCIO
                List<TipoEmpresa> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception)
            {
                return new List<TipoEmpresa>();
            }
        }

        private List<TipoEmpresa> GenerarListado(List<BD.TipoEmpresa> listaDatos)
        {
            List<TipoEmpresa> listaNegocio = new List<TipoEmpresa>();
            foreach (BD.TipoEmpresa datos in listaDatos)
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
            BD.OnbreakEntities bd = new BD.OnbreakEntities();
            BD.TipoEmpresa tipoEmpresa = new BD.TipoEmpresa();
            try
            {
                //sincronizo el contenido de las propiedades a la BD
                CommonBC.Syncronize(this, tipoEmpresa);
                bd.TipoEmpresa.Add(tipoEmpresa);
                bd.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                bd.TipoEmpresa.Remove(tipoEmpresa);
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
                BD.TipoEmpresa tipoEmpresa =
                    bd.TipoEmpresa.First(e => e.Id.Equals(this.Id));
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
            BD.OnbreakEntities bd = new BD.OnbreakEntities();

            try
            {
                //busco por el id el contenido de la entidad a modificar
                BD.TipoEmpresa tipoEmpresa =
                    bd.TipoEmpresa.First(e => e.Id.Equals(this.Id));
                CommonBC.Syncronize(this, tipoEmpresa);
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
                BD.TipoEmpresa tipoEmpresa =
                    bd.TipoEmpresa.First(e => e.Id.Equals(this.Id));
                bd.TipoEmpresa.Remove(tipoEmpresa);
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
