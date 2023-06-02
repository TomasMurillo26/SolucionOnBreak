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
    /// Lógica de interacción para Cena.xaml
    /// </summary>
    public partial class Cena : MetroWindow
    {
        public Cena()
        {
            InitializeComponent();
        }
        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            AdminContrato adminContrato = new AdminContrato();
            adminContrato.Show();
            this.Close();
        }

        private void opcion1SerCe_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void opcion2SerCe_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void opcion1LocCe_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void opcion2LocCe_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void opcion1AmbiCe_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void opcion2AmbiCe_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void btnSeleccionar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
