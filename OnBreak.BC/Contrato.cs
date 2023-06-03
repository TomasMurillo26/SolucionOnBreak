using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string IdModalidad { get; set; }
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
            IdModalidad = string.Empty;
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
            BD.OnbreakEntities bd = new BD.OnbreakEntities();
            BD.Contrato contrato = new BD.Contrato();
            try
            {
                //sincronizo el contenido de las propiedades a la BD
                CommonBC.Syncronize(this, contrato);
                bd.Contrato.Add(contrato);
                bd.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                bd.Contrato.Remove(contrato);
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
                BD.Contrato contrato =
                    bd.Contrato.First(e => e.Numero.Equals(this.Numero));
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
            BD.OnbreakEntities bd = new BD.OnbreakEntities();
            try
            {
                //busco por el id el contenido de la entidad a modificar
                BD.Contrato contrato =
                    bd.Contrato.First(e => e.Numero.Equals(this.Numero));
                CommonBC.Syncronize(this, contrato);
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
                BD.Contrato contrato =
                    bd.Contrato.First(e => e.Numero.Equals(this.Numero));
                bd.Contrato.Remove(contrato);
                bd.SaveChanges();
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
            BD.OnbreakEntities bd = new BD.OnbreakEntities();
            try
            {
                //Crear una lista de DATOS
                List<BD.Contrato> listaDatos = bd.Contrato.ToList();
                //Crear una lista de NEGOCIO
                List<Contrato> Contrato = GenerarListado(listaDatos);
                return Contrato;
            }
            catch (Exception)
            {
                return new List<Contrato>();
            }
        }

        private List<Contrato> GenerarListado(List<BD.Contrato> listaDatos)
        {
            List<Contrato> listaNegocio = new List<Contrato>();
            foreach (BD.Contrato datos in listaDatos)
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

        public void LeerDescripcionModalidad(string idMod)
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
            BD.OnbreakEntities bd = new BD.OnbreakEntities();
            try
            {
                //Crear una lista de DATOS
                List<BD.Contrato> listaDatos = bd.Contrato.Where(e => e.RutCliente.Equals(rutCliente)).ToList<BD.Contrato>();
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
            BD.OnbreakEntities bd = new BD.OnbreakEntities();
            try
            {
                //Crear una lista de DATOS
                List<BD.Contrato> listaDatos = bd.Contrato.Where(e => e.Numero.Equals(nro)).ToList<BD.Contrato>();
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
            BD.OnbreakEntities bd = new BD.OnbreakEntities();
            try
            {
                //Crear una lista de DATOS
                List<BD.Contrato> listaDatos = bd.Contrato.Where(e => e.IdTipoEvento == idTipoevento).ToList<BD.Contrato>();
                //Crear una lista de NEGOCIO
                List<Contrato> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception)
            {
                return new List<Contrato>();
            }
        }

        public List<Contrato> LeerPorModalidad(string idModalidad)
        {
            BD.OnbreakEntities bd = new BD.OnbreakEntities();
            try
            {
                //Crear una lista de DATOS
                List<BD.Contrato> listaDatos = bd.Contrato.Where(e => e.IdModalidad.Equals(idModalidad)).ToList<BD.Contrato>();
                //Crear una lista de NEGOCIO
                List<Contrato> listaNegocio = GenerarListado(listaDatos);
                return listaNegocio;
            }
            catch (Exception)
            {
                return new List<Contrato>();
            }
        }

        public List<Contrato> FiltrarPorTipoEventoyModalServ(int idTipoEvento, string idModalidad)
        {
            BD.OnbreakEntities bd = new BD.OnbreakEntities();
            try
            {
                var _idmod = idModalidad.ToString();
                List<BD.Contrato> listaDatos = bd.Contrato.Where(e => e.IdTipoEvento == idTipoEvento && e.IdModalidad.Equals(_idmod)).ToList();

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

