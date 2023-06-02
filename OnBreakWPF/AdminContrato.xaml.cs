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
    /// Lógica de interacción para AdminContrato.xaml
    /// </summary>
    public partial class AdminContrato : MetroWindow
    {
        public Cocktail Cocktail { get; set; }
        public CoffeeBreak CoffeeBreak { get; set; }
        public AdminContrato()
        {
            InitializeComponent();
        }

        private void tlCocktail_Click(object sender, RoutedEventArgs e)
        {
            Cocktail cocktail = new Cocktail();
            cocktail.Show();
            this.Close();
        }

        private void tlCoffee_Click(object sender, RoutedEventArgs e)
        {
            CoffeeBreak coffeBreak = new CoffeeBreak();
            coffeBreak.Show();
            this.Close();

        }

        private void tlCenas_Click(object sender, RoutedEventArgs e)
        {
            Cena cena = new Cena();
            cena.Show();
            this.Close();
        }

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            AgregarContrato agregarContrato = new AgregarContrato();
            agregarContrato.Show();
            this.Close();
        }
    }
}
