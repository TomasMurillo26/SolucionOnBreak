using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.BC
{
    public class Cliente
    {
        string _descripcionActEmpresa;
        string _descripcionTipoEmpresa;
        #region Propiedades
        public string RutCliente { get; set; }
        public string RazonSocial { get; set; }
        public string NombreContacto { get; set; }
        public string MailContacto { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int IdActividadEmpresa { get; set; }
        public int IdTipoEmpresa { get; set; }
        public string DescripcionActividadEmpresa { get => _descripcionActEmpresa; }
        public string DescripcionTipoEmpresa { get => _descripcionTipoEmpresa; }
        #endregion

        public Cliente()
        {
            this.Init();
        }

        private void Init()
        {
            RutCliente = string.Empty;
            RazonSocial = string.Empty;
            NombreContacto = string.Empty;
            MailContacto = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            IdTipoEmpresa = 0;
            IdActividadEmpresa = 0;
            _descripcionActEmpresa = string.Empty;
            _descripcionTipoEmpresa = string.Empty;
        }
        public bool Create()
        {
            //Crear una conexión al Entities
            BD.OnbreakEntities bd = new BD.OnbreakEntities();
            BD.Cliente cliente = new BD.Cliente();
            try
            {
                //sincronizo el contenido de las propiedades a la BD
                CommonBC.Syncronize(this, cliente);
                bd.Cliente.Add(cliente);
                bd.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                bd.Cliente.Remove(cliente);
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
                BD.Cliente cliente =
                    bd.Cliente.First(e => e.RutCliente.Equals(this.RutCliente));
                CommonBC.Syncronize(cliente, this);

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
                BD.Cliente cliente =
                    bd.Cliente.First(e => e.RutCliente.Equals(this.RutCliente));
                CommonBC.Syncronize(this, cliente);
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
                BD.Cliente cliente =
                    bd.Cliente.First(e => e.RutCliente.Equals(this.RutCliente));
                bd.Cliente.Remove(cliente);
                bd.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void LeerDescripcionAct(int idAct)
        {
            ActividadEmpresa actEmpresa = new ActividadEmpresa() { Id = idAct };
            if (actEmpresa.Read())
            {
                _descripcionActEmpresa = actEmpresa.Descripcion;
            }
            else
            {
                _descripcionActEmpresa = string.Empty;
            }
        }

        public void LeerDescripcionTipo(int idTipo)
        {
            TipoEmpresa tipoEmpresa = new TipoEmpresa() { Id = idTipo };
            if (tipoEmpresa.Read())
            {
                _descripcionTipoEmpresa = tipoEmpresa.Descripcion;
            }
            else
            {
                _descripcionTipoEmpresa = string.Empty;
            }
        }

        private List<Cliente> GenerarListado(List<BD.Cliente> listaDatos)
        {
            List<Cliente> listaNegocio = new List<Cliente>();
            foreach (BD.Cliente datos in listaDatos)
            {
                Cliente clientes = new Cliente();
                CommonBC.Syncronize(datos, clientes);

                clientes.LeerDescripcionAct(clientes.IdActividadEmpresa);
                clientes.LeerDescripcionTipo(clientes.IdTipoEmpresa);

                listaNegocio.Add(clientes);
            }
            return listaNegocio;
        }

        public List<Cliente> ReadAll()
        {
            //Crear una conexión al Entities
            BD.OnbreakEntities bd = new BD.OnbreakEntities();
            try
            {
                //Crear una lista de DATOS
                List<BD.Cliente> listaDatos = bd.Cliente.ToList();
                //Crear una lista de NEGOCIO
                List<Cliente> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception)
            {
                return new List<Cliente>();
            }
        }

        public List<Cliente> LeerTipoEmpresa(int tipEmpresa)
        {
            BD.OnbreakEntities bd = new BD.OnbreakEntities();
            try
            {

                List<BD.Cliente> listaDatos = bd.Cliente.Where(e => e.IdTipoEmpresa == tipEmpresa).ToList();

                List<Cliente> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception)
            {
                return new List<Cliente>();
            }
        }

        public List<Cliente> LeerActividadEmpresa(int actEmpresa)
        {
            BD.OnbreakEntities bd = new BD.OnbreakEntities();
            try
            {

                List<BD.Cliente> listaDatos = bd.Cliente.Where(e => e.IdActividadEmpresa == actEmpresa).ToList();

                List<Cliente> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception)
            {
                return new List<Cliente>();
            }
        }

        public List<Cliente> FiltrarPorTipoYActividadEmpresa(int idTipoEmpresa, int idActividadEmpresa)
        {
            BD.OnbreakEntities bd = new BD.OnbreakEntities();
            try
            {
                List<BD.Cliente> listaDatos = bd.Cliente.Where(e => e.IdTipoEmpresa == idTipoEmpresa && e.IdActividadEmpresa == idActividadEmpresa).ToList();

                List<Cliente> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception)
            {
                return new List<Cliente>();
            }
        }
    }
}
