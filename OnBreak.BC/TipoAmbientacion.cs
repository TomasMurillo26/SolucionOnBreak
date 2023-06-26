using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.BC
{
    public class TipoAmbientacion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public TipoAmbientacion()
        {
            this.Init();
        }

        private void Init()
        {
            Id = 0;
            Descripcion = string.Empty;
        }
        public List<TipoAmbientacion> ReadAll()
        {
            //Crear una conexión al Entities
            DB.onbreakEntities DB = new DB.onbreakEntities();
            try
            {
                //Crear una lista de DATOS
                List<DB.TipoAmbientacion> listaDatos = DB.TipoAmbientacion.ToList();
                //Crear una lista de NEGOCIO
                List<TipoAmbientacion> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception)
            {
                return new List<TipoAmbientacion>();
            }
        }

        private List<TipoAmbientacion> GenerarListado(List<DB.TipoAmbientacion> listaDatos)
        {
            List<TipoAmbientacion> listaNegocio = new List<TipoAmbientacion>();
            foreach (DB.TipoAmbientacion datos in listaDatos)
            {
                TipoAmbientacion negocio = new TipoAmbientacion();
                CommonBC.Syncronize(datos, negocio);
                listaNegocio.Add(negocio);
            }
            return listaNegocio;
        }

    }
}
