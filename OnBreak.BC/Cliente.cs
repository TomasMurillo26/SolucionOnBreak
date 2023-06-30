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
            DB.onbreakEntities DB = new DB.onbreakEntities();
            DB.Cliente cliente = new DB.Cliente();
            try
            {
                //sincronizo el contenido de las propiedades a la DB
                CommonBC.Syncronize(this, cliente);
                DB.Cliente.Add(cliente);
                DB.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                DB.Cliente.Remove(cliente);
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
                DB.Cliente cliente =
                    DB.Cliente.First(e => e.RutCliente.Equals(this.RutCliente));
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
            DB.onbreakEntities DB = new DB.onbreakEntities();

            try
            {
                //busco por el id el contenido de la entidad a modificar
                DB.Cliente cliente =
                    DB.Cliente.First(e => e.RutCliente.Equals(this.RutCliente));
                CommonBC.Syncronize(this, cliente);
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
                DB.Cliente cliente =
                    DB.Cliente.First(e => e.RutCliente.Equals(this.RutCliente));
                DB.Cliente.Remove(cliente);
                DB.SaveChanges();
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

        private List<Cliente> GenerarListado(List<DB.Cliente> listaDatos)
        {
            List<Cliente> listaNegocio = new List<Cliente>();
            foreach (DB.Cliente datos in listaDatos)
            {
                Cliente cliente = new Cliente();
                CommonBC.Syncronize(datos, cliente);

                cliente.LeerDescripcionAct(cliente.IdActividadEmpresa);
                cliente.LeerDescripcionTipo(cliente.IdTipoEmpresa);

                listaNegocio.Add(cliente);
            }
            return listaNegocio;
        }

        public List<Cliente> BuscarClientes(string rutCliente)
        {
            // Crear una conexión al Entities
            DB.onbreakEntities DB = new DB.onbreakEntities();
            try
            {
                // Buscar coincidencias exactas
                var exactMatches = DB.Cliente.Where(c => c.RutCliente == rutCliente).ToList();

                // Buscar coincidencias parciales
                var partialMatches = DB.Cliente.Where(c => c.RutCliente.Contains(rutCliente) && c.RutCliente != rutCliente).ToList();

                // Combinar resultados
                List<DB.Cliente> listaDatos = new List<DB.Cliente>();
                listaDatos.AddRange(exactMatches);
                listaDatos.AddRange(partialMatches);

                // Crear una lista de NEGOCIO
                List<Cliente> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception)
            {
                return new List<Cliente>();
            }
        }

        public List<Cliente> ReadAll()
        {
            //Crear una conexión al Entities
            DB.onbreakEntities DB = new DB.onbreakEntities();
            try
            {
                //Crear una lista de DATOS
                List<DB.Cliente> listaDatos = DB.Cliente.ToList();
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
            DB.onbreakEntities DB = new DB.onbreakEntities();
            try
            {

                List<DB.Cliente> listaDatos = DB.Cliente.Where(e => e.IdTipoEmpresa == tipEmpresa).ToList();

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
            DB.onbreakEntities DB = new DB.onbreakEntities();
            try
            {

                List<DB.Cliente> listaDatos = DB.Cliente.Where(e => e.IdActividadEmpresa == actEmpresa).ToList();

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
            DB.onbreakEntities DB = new DB.onbreakEntities();
            try
            {
                List<DB.Cliente> listaDatos = DB.Cliente.Where(e => e.IdTipoEmpresa == idTipoEmpresa && e.IdActividadEmpresa == idActividadEmpresa).ToList();

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
