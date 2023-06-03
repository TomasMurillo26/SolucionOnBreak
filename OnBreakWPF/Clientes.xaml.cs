using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using OnBreak.BC;

namespace OnBreakWPF
{
    /// <summary>
    /// Lógica de interacción para Clientes.xaml
    /// </summary>
    public partial class Clientes : MetroWindow
    {
        public Clientes()
        {
            Cliente cliente = new Cliente();
            InitializeComponent();
            GridClientes.ItemsSource = cliente.ReadAll();
            txtRut1.SetValue(TextBoxHelper.WatermarkProperty, "Ingrese RUT");
            cboActividadEmpresa.SetValue(TextBoxHelper.WatermarkProperty, "Seleccione");
            cboTipoEmpresa.SetValue(TextBoxHelper.WatermarkProperty, "Seleccione");
            LimpiarControles();
            txtRut.IsReadOnly = true;

        }

        private void LimpiarControles()
        {
            /* Limpia los controles de texto */
            Cliente cliente = new Cliente();
            CargarActividadEmpresas();
            CargarTipoEmpresas();
            GridClientes.ItemsSource = cliente.ReadAll();
        }

        private void CargarActividadEmpresas()
        {
            /* Carga todas las Actividades de Empresas */
            ActividadEmpresa actividadEmp = new ActividadEmpresa();
            cboActividadEmpresa.ItemsSource = actividadEmp.ReadAll();

            /* Configura los datos en el ComboBox */
            cboActividadEmpresa.DisplayMemberPath = "Descripcion"; //Propiedad para mostrar
            cboActividadEmpresa.SelectedValuePath = "Id"; //Propiedad con el valor a rescatar

            cboActividadEmpresa.SelectedIndex = -1; //Posiciona en el primer registro

        }

        private void CargarTipoEmpresas()
        {
            /* Carga todas las Tipo de Empresas */
            TipoEmpresa tipoEmpresa = new TipoEmpresa();
            cboTipoEmpresa.ItemsSource = tipoEmpresa.ReadAll();

            /* Configura los datos en el ComboBox */
            cboTipoEmpresa.DisplayMemberPath = "Descripcion"; //Propiedad para mostrar
            cboTipoEmpresa.SelectedValuePath = "Id"; //Propiedad con el valor a rescatar

            cboTipoEmpresa.SelectedIndex = -1; //Posiciona en el primer registro

        }

        private void CargarActActividadEmpresas()
        {
            /* Carga todas las Actividades de Empresas */
            ActividadEmpresa actividadEmp = new ActividadEmpresa();
            cboActualizarActividadEmp.ItemsSource = actividadEmp.ReadAll();

            /* Configura los datos en el ComboBox */
            cboActualizarActividadEmp.DisplayMemberPath = "Descripcion"; //Propiedad para mostrar
            cboActualizarActividadEmp.SelectedValuePath = "Id"; //Propiedad con el valor a rescatar

            cboActualizarActividadEmp.SelectedIndex = -1; //Posiciona en el primer registro

        }

        private void CargarActTipoEmpresas()
        {
            /* Carga todas las Tipo de Empresas */
            TipoEmpresa tipoEmpresa = new TipoEmpresa();
            cboActualizarTipoEmp.ItemsSource = tipoEmpresa.ReadAll();

            /* Configura los datos en el ComboBox */
            cboActualizarTipoEmp.DisplayMemberPath = "Descripcion"; //Propiedad para mostrar
            cboActualizarTipoEmp.SelectedValuePath = "Id"; //Propiedad con el valor a rescatar

            cboActualizarTipoEmp.SelectedIndex = -1; //Posiciona en el primer registro

        }

        private async void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            string rutCliente = txtRut1.Text.Trim();
            GridClientes.ItemsSource = null;
            Cliente cliente = new Cliente();

            if (!string.IsNullOrWhiteSpace(rutCliente))
            {
                Cliente clienteBuscar = new Cliente();
                List<Cliente> clientes = clienteBuscar.BuscarClientes(rutCliente);

                if (clientes.Count > 0)
                {
                    GridClientes.ItemsSource = clientes;
                    return;
                }
                else
                {
                    await this.ShowMessageAsync("Búsqueda de Clientes","No se encontraron coincidencias." );
                }
            }

            if (cboActividadEmpresa.SelectedItem != null && cboTipoEmpresa.SelectedItem != null)
            {
                GridClientes.ItemsSource = cliente.FiltrarPorTipoYActividadEmpresa((int)cboActividadEmpresa.SelectedValue, (int)cboTipoEmpresa.SelectedValue);
                if (GridClientes.Items.Count == 1)
                {
                    await this.ShowMessageAsync("Información", "No se encontraron coincidencias.");
                }
                return;
            }else if (cboActividadEmpresa.SelectedItem != null)
            {
                GridClientes.ItemsSource = cliente.LeerActividadEmpresa((int)cboActividadEmpresa.SelectedValue);
                if (GridClientes.Items.Count == 1)
                {
                    await this.ShowMessageAsync("Información", "No se encontraron coincidencias.");
                }
                return;
            }else if (cboTipoEmpresa.SelectedItem != null)
            {
                GridClientes.ItemsSource = cliente.LeerTipoEmpresa((int)cboTipoEmpresa.SelectedValue);
                if (GridClientes.Items.Count == 1)
                {
                    await this.ShowMessageAsync("Información", "No se encontraron coincidencias.");
                }
                return;
            }

            GridClientes.ItemsSource = cliente.ReadAll();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AgregarCliente agregarCliente = new AgregarCliente();
            this.Close();
            agregarCliente.Show();
        }



        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Clean(object sender, RoutedEventArgs e)
        {
            LimpiarControles();
        }

        private async void Button_Eliminar_Click(object sender, RoutedEventArgs e)
        {
            Cliente datos = (Cliente)GridClientes.SelectedItem;

            if(datos == null)
            {
                await this.ShowMessageAsync("Alerta", "Debes seleccionar un cliente.");
                return;
            }

            Cliente cliente = new Cliente()
            {
                RutCliente = datos.RutCliente
            };

            if (cliente.Delete())
            {
                await this.ShowMessageAsync("Alerta", "Cliente eliminado exitosamente.");
                LimpiarControles();
            }
            else
            {
                await this.ShowMessageAsync("Alerta", "No se ha podido eliminar el cliente.");
            }
        }

        private async void Button_Editar_Click(object sender, RoutedEventArgs e)
        {
            Cliente clidato = (Cliente)GridClientes.SelectedItem;
            if (clidato == null)
            {
                await this.ShowMessageAsync("Alerta", "Debes seleccionar un cliente.");
                return;
            }
            flyout.IsOpen = true;
            CargarActActividadEmpresas();
            CargarActTipoEmpresas();
            Console.WriteLine(clidato);
            txtRut.Text = clidato.RutCliente;
            txtRazon.Text = clidato.RazonSocial;
            txtNombre.Text = clidato.NombreContacto;
            txtMail.Text = clidato.MailContacto;
            txtDireccion.Text = clidato.Direccion;
            txtTelefono.Text = clidato.Telefono;
            cboActualizarActividadEmp.SelectedValue = clidato.IdActividadEmpresa;
            cboActualizarTipoEmp.SelectedValue = clidato.IdTipoEmpresa;
        }

        private async void btnActualizar_Click(object sender, RoutedEventArgs e)
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
            if (string.IsNullOrWhiteSpace(cboActualizarActividadEmp.Text))
            {
                txtActMessage.Text = "Seleccione una opción";
                isValid = false;
            }
            else
            {
                txtActMessage.Text = string.Empty;
            }

            // Validar el campo Tipo Empresa
            if (string.IsNullOrWhiteSpace(cboActualizarTipoEmp.Text))
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
                RazonSocial = txtRazon.Text,
                NombreContacto = txtNombre.Text,
                MailContacto = txtMail.Text,
                Direccion = txtDireccion.Text,
                Telefono = txtTelefono.Text,
                IdActividadEmpresa = (int)cboActualizarActividadEmp.SelectedValue,
                IdTipoEmpresa = (int)cboActualizarTipoEmp.SelectedValue,
            };

            if (cliente.Update())
            {
                flyout.IsOpen = false;
                await this.ShowMessageAsync("¡Listo!", "Cliente actualizado con éxito");
                GridClientes.ItemsSource = cliente.ReadAll();
            }
            else
            {
                await this.ShowMessageAsync("Alerta", "No se actualizó el cliente");
            }
        }

        private void CloseFlyout(object sender, RoutedEventArgs e)
        {
            flyout.IsOpen = false;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            VentanaPrincipal ventanaPrincipal = new VentanaPrincipal();
            this.Close();
            ventanaPrincipal.Show();
        }

        private void txtRut1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
