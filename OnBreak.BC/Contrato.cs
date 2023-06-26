using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBreak.DB;

namespace OnBreak.BC
{
    public class Contrato
    {
        string _descripcionModalidad;
        string _descripcionTipoEvento;
        string _descripcionTerminado;
        public string Numero { get; set; }
        public DateTime Creacion { get; set; }
        public DateTime Termino { get; set; }
        public string RutCliente { get; set; }
        public int IdModalidad { get; set; }
        public int IdTipoEvento { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraTermino { get; set; }
        public int Asistentes { get; set; }
        public int PersonalAdicional { get; set; }
        public bool Realizado { get; set; }
        public double ValorTotalContrato { get; set; }
        public string Observaciones { get; set; }
        public string DescripcionModalidad { get => _descripcionModalidad; }
        public string DescripcionTipoEmpresa { get => _descripcionTipoEvento; }
        public string DescripcionTerminado { get => _descripcionTerminado; }

        public Contrato()
        {
            this.Init();
        }

        private void Init()
        {
            Numero = string.Empty;
            Creacion = new DateTime();
            Termino = new DateTime();
            RutCliente = string.Empty;
            IdModalidad = 0;
            IdTipoEvento = 0;
            FechaHoraInicio = new DateTime();
            FechaHoraTermino = new DateTime();
            Asistentes = 0;
            PersonalAdicional = 0;
            Realizado = false;
            ValorTotalContrato = 0;
            Observaciones = string.Empty;
            _descripcionModalidad = string.Empty;
            _descripcionTipoEvento = string.Empty;
            _descripcionTerminado = string.Empty;
        }
        public bool Create()
        {
            //Crear una conexión al Entities
            DB.onbreakEntities DB = new DB.onbreakEntities();
            DB.Contrato contrato = new DB.Contrato();
            try
            {
                //sincronizo el contenido de las propiedades a la DB
                CommonBC.Syncronize(this, contrato);
                DB.Contrato.Add(contrato);
                DB.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                DB.Contrato.Remove(contrato);
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
                DB.Contrato contrato =
                    DB.Contrato.First(e => e.Numero.Equals(this.Numero));
                CommonBC.Syncronize(contrato, this);

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
                DB.Contrato contrato =
                    DB.Contrato.First(e => e.Numero.Equals(this.Numero));
                CommonBC.Syncronize(this, contrato);
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
                DB.Contrato contrato =
                    DB.Contrato.First(e => e.Numero.Equals(this.Numero));
                DB.Contrato.Remove(contrato);
                DB.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }
        public List<Contrato> ReadAll()
        {
            //Crear una conexión al Entities
            DB.onbreakEntities DB = new DB.onbreakEntities();
            try
            {
                //Crear una lista de DATOS
                List<DB.Contrato> listaDatos = DB.Contrato.ToList();
                //Crear una lista de NEGOCIO
                List<Contrato> Contrato = GenerarListado(listaDatos);
                return Contrato;
            }
            catch (Exception)
            {
                return new List<Contrato>();
            }
        }

        private List<Contrato> GenerarListado(List<DB.Contrato> listaDatos)
        {
            List<Contrato> listaNegocio = new List<Contrato>();
            foreach (DB.Contrato datos in listaDatos)
            {
                Contrato contratos = new Contrato();
                CommonBC.Syncronize(datos, contratos);

                contratos.LeerDescripcionModalidad(contratos.IdModalidad);
                contratos.LeerDescripcionTipo(contratos.IdTipoEvento);

                if(contratos.Realizado)
                {
                    contratos._descripcionTerminado = "Si";
                }
                else
                {
                    contratos._descripcionTerminado = "No";
                }

                listaNegocio.Add(contratos);
            }
            return listaNegocio;
        }

        public void LeerDescripcionModalidad(int idMod)
        {
            ModalidadServicio modalidad = new ModalidadServicio() { Id = idMod };
            if (modalidad.Read())
            {
                _descripcionModalidad = modalidad.Nombre;
            }
            else
            {
                _descripcionModalidad = string.Empty;
            }
        }

        public void LeerDescripcionTipo(int idTipo)
        {
            TipoEvento tipoEvento = new TipoEvento() { Id = idTipo };
            if (tipoEvento.Read())
            {
                _descripcionTipoEvento = tipoEvento.Descripcion;
            }
            else
            {
                _descripcionTipoEvento = string.Empty;
            }
        }

        public List<Contrato> LeerPorRut(string rutCliente)
        {
            DB.onbreakEntities DB = new DB.onbreakEntities();
            try
            {
                //Crear una lista de DATOS
                List<DB.Contrato> listaDatos = DB.Contrato.Where(e => e.RutCliente.Equals(rutCliente)).ToList<DB.Contrato>();
                //Crear una lista de NEGOCIO
                List<Contrato> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception)
            {
                return new List<Contrato>();
            }
        }

        public List<Contrato> LeerPorNro(string nro)
        {
            DB.onbreakEntities DB = new DB.onbreakEntities();
            try
            {
                //Crear una lista de DATOS
                List<DB.Contrato> listaDatos = DB.Contrato.Where(e => e.Numero.Equals(nro)).ToList<DB.Contrato>();
                //Crear una lista de NEGOCIO
                List<Contrato> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception)
            {
                return new List<Contrato>();
            }
        }

        public List<Contrato> LeerPorTipoEvento(int idTipoevento)
        {
            DB.onbreakEntities DB = new DB.onbreakEntities();
            try
            {
                //Crear una lista de DATOS
                List<DB.Contrato> listaDatos = DB.Contrato.Where(e => e.IdTipoEvento == idTipoevento).ToList<DB.Contrato>();
                //Crear una lista de NEGOCIO
                List<Contrato> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception)
            {
                return new List<Contrato>();
            }
        }

        public List<Contrato> LeerPorModalidad(int id)
        {
            DB.onbreakEntities DB = new DB.onbreakEntities();
            try
            {
                //Crear una lista de DATOS
                List<DB.Contrato> listaDatos = DB.Contrato.Where(e => e.IdModalidad == id).ToList<DB.Contrato>();
                //Crear una lista de NEGOCIO
                List<Contrato> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception)
            {
                return new List<Contrato>();
            }
        }

        public List<Contrato> FiltrarPorTipoEventoyModalServ(int idTipoEvento, int idModalidad)
        {
            DB.onbreakEntities DB = new DB.onbreakEntities();
            try
            {
                
                List<DB.Contrato> listaDatos = DB.Contrato.Where(e => e.IdTipoEvento == idTipoEvento && e.IdModalidad == idModalidad).ToList();

                List<Contrato> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception)
            {
                return new List<Contrato>();
            }
        }
    }

}

