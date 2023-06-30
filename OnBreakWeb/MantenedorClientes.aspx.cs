using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnBreak.BC;
namespace OnBreakWeb
{
    public partial class MantenedorClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /* Necesito diferenciar si es la primera carga o no, ya que si no lo hago
             * cada vez que instancio un método, por ejemplo el update, el combo se vuelve a cargar
             * y quedo con el primer elemento seleccionado*/
            if (!IsPostBack)
            {
                cboEmpresa.Items.Insert(0, new ListItem("Seleccione", ""));
                cboActEmpresa.Items.Insert(0, new ListItem("Seleccione", ""));
            
                CargarEmpresa();
                CargarActEmp();
                CargarGrilla();
            }
        }

        private void CargarGrilla()
        {
            /*cargo todos los empleados de la BD en la grilla*/
            WebServices.OBServiciosSoapClient misServicios =
                new WebServices.OBServiciosSoapClient();
            gdClientes.DataSource = misServicios.ReadAllClientes();
            gdClientes.DataBind();
        }

        private void CargarActEmp()
        {
            WebServices.OBServiciosSoapClient misServicios =
                new WebServices.OBServiciosSoapClient();
            cboActEmpresa.DataValueField = "Id";
            cboActEmpresa.DataTextField = "Descripcion";
            cboActEmpresa.DataSource = misServicios.ReadAllAct();
            cboActEmpresa.DataBind();
        }


        private void CargarEmpresa()
        {
            WebServices.OBServiciosSoapClient misServicios =
                new WebServices.OBServiciosSoapClient();
            cboEmpresa.DataValueField = "Id";
            cboEmpresa.DataTextField = "Descripcion";
            cboEmpresa.DataSource = misServicios.ReadAllTipo();
            cboEmpresa.DataBind();
        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            Cliente cli = new Cliente()
            {
                RutCliente = txtRut.Text,
                RazonSocial = txtRazSocial.Text,
                NombreContacto = txtNombre.Text,
                MailContacto = txtEmail.Text,
                Direccion = txtDireccion.Text,
                Telefono = txtTelefono.Text,
                IdTipoEmpresa = int.Parse(cboEmpresa.SelectedValue),
                IdActividadEmpresa = int.Parse(cboActEmpresa.SelectedValue)

            };
            Console.WriteLine(cli);
            if (cli.Create())
            {
                lblMsg.Text = "Cliente Registrado con Éxito";
                LimpiarControles();
                CargarGrilla();
            }
            else
            {
                lblMsg.Text = "Cliente pudo ser registrado";
            }

            

        }
        private void LimpiarControles()
        {
            /*Limpiar controles de texto*/
            txtRut.Text = string.Empty;
            txtRazSocial.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }
    }
}