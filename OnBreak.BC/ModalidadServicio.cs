using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.BC
{
    public class ModalidadServicio
    {
        public int Id { get; set; }
        public int IdTipoEvento { get; set; }
        public string Nombre { get; set; }
        public double ValorBase { get; set; }
        public int PersonalBase { get; set; }

        public ModalidadServicio()
        {
            this.Init();
        }

        private void Init()
        {
            Id = 0;
            IdTipoEvento = 0;
            Nombre = string.Empty;
            ValorBase = 0;
            PersonalBase = 0;
        }

        public bool Read()
        {
            //Crear una conexión al Entities
            DB.onbreakEntities DB = new DB.onbreakEntities();
            try
            {
                //busco por el id el contenido de la entidad
                DB.ModalidadServicio modalidad =
                    DB.ModalidadServicio.First(e => e.Id.Equals(this.Id));
                CommonBC.Syncronize(modalidad, this);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<ModalidadServicio> ReadAll()
        {
            //Crear una conexión al Entities
            DB.onbreakEntities DB = new DB.onbreakEntities();
            try
            {
                //Crear una lista de DATOS
                List<DB.ModalidadServicio> listaDatos = DB.ModalidadServicio.ToList();
                //Crear una lista de NEGOCIO
                List<ModalidadServicio> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception)
            {
                return new List<ModalidadServicio>();
            }
        }

        public List<ModalidadServicio> ReadAllByTipo(int idTipo)
        {
            //Crear una conexión al Entities
            DB.onbreakEntities DB = new DB.onbreakEntities();
            try
            {
                //Crear una lista de DATOS
                List<DB.ModalidadServicio> listaDatos = DB.ModalidadServicio.Where(e => e.IdTipoEvento == idTipo).ToList<DB.ModalidadServicio>();
                //Crear una lista de NEGOCIO
                List<ModalidadServicio> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception)
            {
                return new List<ModalidadServicio>();
            }
        }

        private List<ModalidadServicio> GenerarListado(List<DB.ModalidadServicio> listaDatos)
        {
            List<ModalidadServicio> listaNegocio = new List<ModalidadServicio>();
            foreach (DB.ModalidadServicio datos in listaDatos)
            {
                ModalidadServicio negocio = new ModalidadServicio();
                CommonBC.Syncronize(datos, negocio);
                listaNegocio.Add(negocio);
            }
            return listaNegocio;
        }
    }
}
