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
    /// Lógica de interacción para VentanaPrincipal.xaml
    /// </summary>
    public partial class VentanaPrincipal : MetroWindow
    {
        public VentanaPrincipal()
        {
            InitializeComponent();
        }

        private void tlAdminClie_Click(object sender, RoutedEventArgs e)
        {
            Clientes cliente = new Clientes();
            cliente.Show();
            this.Close();
        }

        private void tlAdminContra_Click(object sender, RoutedEventArgs e)
        {
            Contratos contrato = new Contratos();
            contrato.Show();
            this.Close();
        }
    }
}
