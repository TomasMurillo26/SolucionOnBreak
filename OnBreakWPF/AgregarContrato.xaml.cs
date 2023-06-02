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

namespace OnBreakWPF
{
    /// <summary>
    /// Lógica de interacción para AgregarContrato.xaml
    /// </summary>
    public partial class AgregarContrato : MetroWindow
    {
        public AgregarContrato()
        {
            InitializeComponent();
        }

        private void DateTimePicker_SelectedDateTimeCreacion(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {

        }

        private void DateTimePicker_SelectedDateTimeTermino(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {

        }

        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {

            //Contrato contrato = new Contrato
            //{

            //    Asistentes = int.Parse(txtAsistentes.Text),
            //    PersonalAdicional = int.Parse(txtPersonalAdicional.Text),

            //};


            AdminContrato adminContrato = new AdminContrato();
            adminContrato.Show();
            this.Close();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            VentanaPrincipal ventanaPrincipal = new VentanaPrincipal();
            ventanaPrincipal.Show();
            this.Close();
        }

    }
}
