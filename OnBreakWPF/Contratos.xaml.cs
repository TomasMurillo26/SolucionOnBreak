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
    /// Lógica de interacción para Contratos.xaml
    /// </summary>
    public partial class Contratos : MetroWindow
    {
        public Contratos()
        {
            Contrato contrato = new Contrato();
            InitializeComponent();
            GridContratos.ItemsSource = contrato.ReadAll();
            txtNroContra.SetValue(TextBoxHelper.WatermarkProperty, "Ingrese Número de contrato");
            txtRut1.SetValue(TextBoxHelper.WatermarkProperty, "Ingrese RUT");

            cboModalServi.SetValue(TextBoxHelper.WatermarkProperty, "Seleccione");
            cboModalServi.SelectionChanged += ComboBox_SelectedIndexChanged;
            cboTipoEvento.SetValue(TextBoxHelper.WatermarkProperty, "Seleccione");
            LimpiarControles();

        }

        private void LimpiarControles()
        {
            /* Limpia los controles de texto */
            Contrato contrato = new Contrato();
            CargarTipoEvento();
            GridContratos.ItemsSource = contrato.ReadAll();
        }


        public void CargarTipoEvento()
        {
            /* Carga todas las Actividades de eventos */
            TipoEvento tipoEvento = new TipoEvento();
            cboTipoEvento.ItemsSource = tipoEvento.ReadAll();

            /* Configura los datos en el ComboBox */
            cboTipoEvento.DisplayMemberPath = "Descripcion"; //Propiedad para mostrar
            cboTipoEvento.SelectedValuePath = "Id"; //Propiedad con el valor a rescatar

            cboTipoEvento.SelectedIndex = -1; //Posiciona en el primer registro

        }

        public void CargarModalidadServicio(int tipo)
        {
            /* Carga todas las Modalidades de Servicio */
            if (cboTipoEvento.SelectedItem != null)
            {
                ModalidadServicio modalidadServicio = new ModalidadServicio();
                cboModalServi.ItemsSource = modalidadServicio.ReadAllByTipo(tipo);

                /* Configura los datos en el ComboBox */
                cboModalServi.DisplayMemberPath = "Nombre"; //Propiedad para mostrar
                cboModalServi.SelectedValuePath = "Id"; //Propiedad con el valor a rescatar

                cboModalServi.SelectedIndex = -1; //posiciona en el primer registro
            }
            return;
        }

        public void CargarActTipoEvento()
        {
            /* Carga todas las Actividades de eventos */
            TipoEvento tipoEvento = new TipoEvento();
            cboActualizarTipo.ItemsSource = tipoEvento.ReadAll();

            /* Configura los datos en el ComboBox */
            cboActualizarTipo.DisplayMemberPath = "Descripcion"; //Propiedad para mostrar
            cboActualizarTipo.SelectedValuePath = "Id"; //Propiedad con el valor a rescatar

            cboActualizarTipo.SelectedIndex = -1; //Posiciona en el primer registro
        }

        public void CargarActModalidadServicio()
        {
            /* Carga todas las Modalidades de Servicio */

            ModalidadServicio modalidadServicio = new ModalidadServicio();
            cboActualizarModalidad.ItemsSource = modalidadServicio.ReadAll();

            /* Configura los datos en el ComboBox */
            cboActualizarModalidad.DisplayMemberPath = "Nombre"; //Propiedad para mostrar
            cboActualizarModalidad.SelectedValuePath = "Id"; //Propiedad con el valor a rescatar

            cboActualizarModalidad.SelectedIndex = -1; //posiciona en el primer registro
        }

        private async void btnBuscar2_Click(object sender, RoutedEventArgs e)
        {

            GridContratos.ItemsSource = null;
            Contrato contrato = new Contrato();
            string rutCliente = txtRut1.Text.Trim();
            string nroContrato = txtNroContra.Text.Trim();

            if (!string.IsNullOrWhiteSpace(rutCliente))
            {
                Contrato contratoBuscar = new Contrato();
                List<Contrato> contratos = contratoBuscar.LeerPorRut(rutCliente);

                if (contratos.Count > 0)
                {
                    GridContratos.ItemsSource = contratos;
                    return;
                }
                else
                {
                    await this.ShowMessageAsync("Búsqueda por Rut del Cliente", "No se encontraron coincidencias.");
                }
            }

            if (!string.IsNullOrWhiteSpace(nroContrato))
            {
                Contrato contratoBuscar = new Contrato();
                List<Contrato> contratos = contratoBuscar.LeerPorNro(nroContrato);

                if (contratos.Count > 0)
                {
                    GridContratos.ItemsSource = contratos;
                    return;
                }
                else
                {
                    await this.ShowMessageAsync("Búsqueda de Contrato", "No se encontraron coincidencias.");
                }
            }

            if (cboModalServi.SelectedItem != null && cboTipoEvento.SelectedItem != null)
            {
                GridContratos.ItemsSource = contrato.FiltrarPorTipoEventoyModalServ((int)cboTipoEvento.SelectedValue, (int)cboModalServi.SelectedValue);
                if (GridContratos.Items.Count == 1)
                {
                    await this.ShowMessageAsync("Información", "No se encontraron coincidencias.");
                }
                return;
            }
            else if (cboModalServi.SelectedItem != null)
            {
                GridContratos.ItemsSource = contrato.LeerPorModalidad((int)cboModalServi.SelectedValue);
                if (GridContratos.Items.Count == 1)
                {
                    await this.ShowMessageAsync("Información", "No se encontraron coincidencias.");
                }
                return;
            }
            else if (cboTipoEvento.SelectedItem != null)
            {
                GridContratos.ItemsSource = contrato.LeerPorTipoEvento((int)cboTipoEvento.SelectedValue);
                if (GridContratos.Items.Count == 1)
                {
                    await this.ShowMessageAsync("Información", "No se encontraron coincidencias.");
                }
                return;
            }

            GridContratos.ItemsSource = contrato.ReadAll();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            VentanaPrincipal ventanaPrincipal = new VentanaPrincipal();
            this.Close();
            ventanaPrincipal.Show();
        }

        private void Button_Clean(object sender, RoutedEventArgs e)
        {
            LimpiarControles();
        }

        private void botonAgregar_Click(object sender, RoutedEventArgs e)
        {
            CrearContrato crearContrato = new CrearContrato();
            this.Close();
            crearContrato.Show();
        }

        private async void Button_Editar_Click(object sender, RoutedEventArgs e)
        {
            Contrato contratoDato = (Contrato)GridContratos.SelectedItem;
            if (contratoDato == null)
            {
                await this.ShowMessageAsync("Alerta", "Debes seleccionar un contrato.");
                return;
            }
            flyout.IsOpen = true;
            CargarActTipoEvento();
            CargarActModalidadServicio();

            txtRut.Text = contratoDato.RutCliente;
            txtAsistentes.Text = contratoDato.Asistentes.ToString();
            txtPersonal.Text = contratoDato.PersonalAdicional.ToString();
            txtObservaciones.Text = contratoDato.Observaciones;
            txtTotal.Text = contratoDato.ValorTotalContrato.ToString();
            txtNro.Text = contratoDato.Numero;
            cboActualizarModalidad.SelectedValue = contratoDato.IdModalidad;
            cboActualizarTipo.SelectedValue = contratoDato.IdTipoEvento;
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void CloseFlyout(object sender, RoutedEventArgs e)
        {
            flyout.IsOpen = false;
        }

        private void txtNro_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            // Obtener el ComboBox que ha desencadenado el evento
            ComboBox cboTipoEvento = (ComboBox)sender;

            // Verificar si se ha seleccionado un elemento
            if (cboTipoEvento.SelectedItem != null)
            {
                CargarModalidadServicio((int)cboTipoEvento.SelectedValue);
            }
            return;
        }
    }
}
