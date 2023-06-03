using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.BC
{
    public class ModalidadServicio
    {
        public string Id { get; set; }
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
            Id = string.Empty;
            IdTipoEvento = 0;
            Nombre = string.Empty;
            ValorBase = 0;
            PersonalBase = 0;
        }

        public bool Read()
        {
            //Crear una conexión al Entities
            BD.OnbreakEntities bd = new BD.OnbreakEntities();
            try
            {
                //busco por el id el contenido de la entidad
                BD.ModalidadServicio modalidad =
                    bd.ModalidadServicio.First(e => e.Id.Equals(Id));
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
            BD.OnbreakEntities bd = new BD.OnbreakEntities();
            try
            {
                //Crear una lista de DATOS
                List<BD.ModalidadServicio> listaDatos = bd.ModalidadServicio.ToList();
                //Crear una lista de NEGOCIO
                List<ModalidadServicio> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception)
            {
                return new List<ModalidadServicio>();
            }
        }

        private List<ModalidadServicio> GenerarListado(List<BD.ModalidadServicio> listaDatos)
        {
            List<ModalidadServicio> listaNegocio = new List<ModalidadServicio>();
            foreach (BD.ModalidadServicio datos in listaDatos)
            {
                ModalidadServicio negocio = new ModalidadServicio();
                CommonBC.Syncronize(datos, negocio);
                listaNegocio.Add(negocio);
            }
            return listaNegocio;
        }
    }
}
