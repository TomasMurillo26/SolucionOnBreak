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
using OnBreak.BC;
namespace OnBreakWPF
{
    /// <summary>
    /// Lógica de interacción para CrearContrato.xaml
    /// </summary>
    public partial class CrearContrato : MetroWindow
    {
        public CrearContrato()
        {
            InitializeComponent();
        }

        private void llenarTipoEvento()
        {
            TipoEvento tipoEvento = new TipoEvento();
            cboTipoEven.ItemsSource = tipoEvento.ReadAll();

            cboTipoEven.DisplayMemberPath = "Descripcion";
            cboTipoEven.SelectedValue = "Id";

            cboTipoEven.SelectedIndex = -1;
        }

        private void llenarTipoAmbientacion()
        {
            TipoAmbientacion tipoAmbi = new TipoAmbientacion();
            cboTipoAmbi.ItemsSource = tipoAmbi.ReadAll();

            cboTipoAmbi.DisplayMemberPath = "Descripcion";
            cboTipoAmbi.SelectedValuePath = "Id";
        }

        private void llenarModalidadServicio()
        {
            ModalidadServicio modalidadServicio = new ModalidadServicio();
            cboModalidadServ.ItemsSource = modalidadServicio.ReadAll();

            cboModalidadServ.DisplayMemberPath = "Nombre";
            cboModalidadServ.SelectedValuePath = "Id";

            cboModalidadServ.SelectedIndex = -1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCrearContra_Click(object sender, RoutedEventArgs e)
        {
            Contrato contrato = new Contrato()
            {
                Numero = DateTime.Now.ToString("yyyyMMddHHmm"),
                Creacion = dtInicio.DisplayDate,
                Termino = dtTermino.DisplayDate,
                RutCliente = txtRutCli3.Text,
                IdModalidad = (string)cboModalidadServ.SelectedValue,
                IdTipoEvento = (int)cboTipoEven.SelectedValue,
                FechaHoraInicio = (DateTime)tpInicio.SelectedDateTime,
                FechaHoraTermino = (DateTime)tpInicio.SelectedDateTime,
                Asistentes = int.Parse(txtAsistentes.Text),
                PersonalAdicional = int.Parse(txtPersonAdic.Text),
                Realizado = false,

                Observaciones = txtObservaciones.Text
            };
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            VentanaPrincipal ventanaPrincipal = new VentanaPrincipal();
            ventanaPrincipal.Show();
            this.Close();
        }
    }
}
