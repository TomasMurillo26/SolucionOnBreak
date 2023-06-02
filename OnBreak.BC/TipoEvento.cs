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
        public List<TipoEvento> ReadAll()
        {
            //Crear una conexión al Entities
            BD.OnbreakEntities bd = new BD.OnbreakEntities();
            try
            {
                //Crear una lista de DATOS
                List<BD.TipoEvento> listaDatos = bd.TipoEvento.ToList();
                //Crear una lista de NEGOCIO
                List<TipoEvento> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception)
            {
                return new List<TipoEvento>();
            }
        }

        private List<TipoEvento> GenerarListado(List<BD.TipoEvento> listaDatos)
        {
            List<TipoEvento> listaNegocio = new List<TipoEvento>();
            foreach (BD.TipoEvento datos in listaDatos)
            {
                TipoEvento negocio = new TipoEvento();
                CommonBC.Syncronize(datos, negocio);
                listaNegocio.Add(negocio);
            }
            return listaNegocio;
        }
    }
}
