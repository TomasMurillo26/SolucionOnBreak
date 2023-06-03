using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using OnBreak.BC;

namespace OnBreakWPF
{
    /// <summary>
    /// Lógica de interacción para AgregarCliente.xaml
    /// </summary>
    public partial class AgregarCliente : MetroWindow
    {
        public AgregarCliente()
        {
            InitializeComponent();
            txtRut.SetValue(TextBoxHelper.WatermarkProperty, "RUT");
            txtNombre.SetValue(TextBoxHelper.WatermarkProperty, "Nombre");
            txtMail.SetValue(TextBoxHelper.WatermarkProperty, "Correo Electronico");
            txtDireccion.SetValue(TextBoxHelper.WatermarkProperty, "Dirección");
            txtTelefono.SetValue(TextBoxHelper.WatermarkProperty, "Telefono");
            txtRazon.SetValue(TextBoxHelper.WatermarkProperty, "Razón Social");
            cboActividadEmp.SetValue(TextBoxHelper.WatermarkProperty, "Seleccione");
            cboTipoEmp.SetValue(TextBoxHelper.WatermarkProperty, "Seleccione");
            LimpiarControles();

        }

        private void LimpiarControles()
        {
            /* Limpia los controles de texto */
            txtRut.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtMail.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtRazon.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            CargarActividadEmpresas();
            CargarTipoEmpresas();
        }

        private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;

            // Validar el campo RutCliente
            if (string.IsNullOrWhiteSpace(txtRut.Text))
            {
                txtRutMessage.Text = "Ingrese el Rut";
                isValid = false;
            }
            else
            {
                txtRutMessage.Text = string.Empty;
            }

            // Validar el campo NombreContacto
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                txtNombreMessage.Text = "Ingrese el nombre";
                isValid = false;
            }
            else
            {
                txtNombreMessage.Text = string.Empty;
            }

            // Validar el campo Razon Social
            if (string.IsNullOrWhiteSpace(txtRazon.Text))
            {
                txtRazonMessage.Text = "Ingrese la razón social";
                isValid = false;
            }
            else
            {
                txtRazonMessage.Text = string.Empty;
            }

            // Validar el campo Mail
            if (string.IsNullOrWhiteSpace(txtMail.Text))
            {
                txtMailMessage.Text = "Ingrese un mail";
                isValid = false;
            }
            else
            {
                txtMailMessage.Text = string.Empty;
            }

            // Validar el campo Dirección
            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                txtDireccionMessage.Text = "Ingrese una dirección";
                isValid = false;
            }
            else
            {
                txtDireccionMessage.Text = string.Empty;
            }

            // Validar el campo Telefono
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                txtTelefonoMessage.Text = "Ingrese un telefono";
                isValid = false;
            }
            else
            {
                txtTelefonoMessage.Text = string.Empty;
            }

            // Validar el campo Act. Empresa
            if (string.IsNullOrWhiteSpace(cboActividadEmp.Text))
            {
                txtActMessage.Text = "Seleccione una opción";
                isValid = false;
            }
            else
            {
                txtActMessage.Text = string.Empty;
            }

            // Validar el campo Tipo Empresa
            if (string.IsNullOrWhiteSpace(cboTipoEmp.Text))
            {
                txtTipoMessage.Text = "Seleccione una opción";
                isValid = false;
            }
            else
            {
                txtTipoMessage.Text = string.Empty;
            }


            if (!isValid)
            {
                await this.ShowMessageAsync("Error de validación", "Favor completar todos los campos en rojo");
                return;
            }

            Cliente cliente = new Cliente()
            {
                RutCliente = txtRut.Text,
            };

            if(cliente.Read())
            {
                await this.ShowMessageAsync("Alerta", "Ya existe un cliente con este RUT");
                return;
            }

            cliente.NombreContacto = txtNombre.Text;
            cliente.RazonSocial = txtRazon.Text;
            cliente.MailContacto = txtMail.Text;
            cliente.Direccion = txtDireccion.Text;
            cliente.Telefono = txtTelefono.Text;
            cliente.IdActividadEmpresa = (int)cboActividadEmp.SelectedValue;
            cliente.IdTipoEmpresa = (int)cboTipoEmp.SelectedValue;

            if (cliente.Create())
            {

                await this.ShowMessageAsync("¡Listo!", "Cliente agregado con éxito");
                LimpiarControles();
            }
            else
            {
                await this.ShowMessageAsync("Ha habido un problema", "No se pudo agregar un nuevo cliente");
            }
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            Clientes cliente = new Clientes();
            cliente.Show();
            this.Close();
        }

        private void CargarActividadEmpresas()
        {
            /* Carga todas las Actividades de Empresas */
            ActividadEmpresa actividadEmp = new ActividadEmpresa();
            cboActividadEmp.ItemsSource = actividadEmp.ReadAll();

            /* Configura los datos en el ComboBox */
            cboActividadEmp.DisplayMemberPath = "Descripcion"; //Propiedad para mostrar
            cboActividadEmp.SelectedValuePath = "Id"; //Propiedad con el valor a rescatar

            cboActividadEmp.SelectedIndex = -1; //Posiciona en el primer registro

        }

        private void CargarTipoEmpresas()
        {
            /* Carga todas las Tipo de Empresas */
            TipoEmpresa tipoEmpresa = new TipoEmpresa();
            cboTipoEmp.ItemsSource = tipoEmpresa.ReadAll();

            /* Configura los datos en el ComboBox */
            cboTipoEmp.DisplayMemberPath = "Descripcion"; //Propiedad para mostrar
            cboTipoEmp.SelectedValuePath = "Id"; //Propiedad con el valor a rescatar

            cboTipoEmp.SelectedIndex = -1; //Posiciona en el primer registro

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string rutCliente = txtRut.Text.Trim();
            Cliente cliente = new Cliente()
            {
                RutCliente = rutCliente
            };

            if (cliente.Read())
            {
                txtNombre.Text = cliente.NombreContacto;
                txtRazon.Text = cliente.RazonSocial;
                txtMail.Text = cliente.MailContacto;
                txtDireccion.Text = cliente.Direccion;
                txtTelefono.Text = cliente.Telefono;
                cboActividadEmp.SelectedValue = cliente.IdActividadEmpresa;
                cboTipoEmp.SelectedValue = cliente.IdTipoEmpresa;

                await this.ShowMessageAsync("¡Listo!", "Cliente encontrado");
            }
            else
            {
                return;
            }
        }
    }
}

