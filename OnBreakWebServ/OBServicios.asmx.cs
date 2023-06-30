using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using OnBreak.BC;

namespace OnBreakWebServ
{
    /// <summary>
    /// Descripción breve de OBServicios
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class OBServicios : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public List<Cliente> ReadAllClientes()
        {
            Cliente cliente = new Cliente();
            return cliente.ReadAll();
        }

        [WebMethod]
        public Cliente ReadCliente(string rutCliente)
        {
            Cliente cliente = new Cliente() { RutCliente = rutCliente };
            if (cliente.Read())
            {
                return cliente;
            }
            return null;
        }

        [WebMethod]
        public bool UpdateCliente(Cliente cliente)
        {
            return cliente.Update();
        }

        [WebMethod]
        public bool DeleteCliente(string rutCliente)
        {
            Cliente cliente = new Cliente() { RutCliente = rutCliente };
            return cliente.Delete();
        }
    }
}
