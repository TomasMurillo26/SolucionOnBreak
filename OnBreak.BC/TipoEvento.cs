using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.BC
{
    public class TipoEvento
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public TipoEvento()
        {
            this.Init();
        }

        private void Init()
        {
            Id = 0;
            Descripcion = string.Empty;
        }

        public bool Read()
        {
            //Crear una conexión al Entities
            DB.onbreakEntities DB = new DB.onbreakEntities();
            try
            {
                //busco por el id el contenido de la entidad
                DB.TipoEvento contrato =
                    DB.TipoEvento.First(e => e.Id.Equals(this.Id));
                CommonBC.Syncronize(contrato, this);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<TipoEvento> ReadAll()
        {
            //Crear una conexión al Entities
            DB.onbreakEntities DB = new DB.onbreakEntities();
            try
            {
                //Crear una lista de DATOS
                List<DB.TipoEvento> listaDatos = DB.TipoEvento.ToList();
                //Crear una lista de NEGOCIO
                List<TipoEvento> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception)
            {
                return new List<TipoEvento>();
            }
        }

        private List<TipoEvento> GenerarListado(List<DB.TipoEvento> listaDatos)
        {
            List<TipoEvento> listaNegocio = new List<TipoEvento>();
            foreach (DB.TipoEvento datos in listaDatos)
            {
                TipoEvento negocio = new TipoEvento();
                CommonBC.Syncronize(datos, negocio);
                listaNegocio.Add(negocio);
            }
            return listaNegocio;
        }
    }
}
