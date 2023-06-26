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
    /// Lógica de interacción para CrearContrato.xaml
    /// </summary>
    public partial class CrearContrato : MetroWindow
    {
        private bool otroLocalOnBreak = false;
        private bool actTipoAmbientacion = false;
        private bool vegetariana = false;
        private int ambientacion = 0;
        private bool añadirAmbi = false;
        private bool musicaAmbiente = false;
        private bool musicaCliente = false;

        private bool localOnBreak = false;
        private bool localArriendo = false;
        private int valorAriendoLocal = 0;
        private double valorcoti = 0;
        private int ambientacionCena = 0;
        public CrearContrato()
        {
            InitializeComponent();
            Limpiar();
        }

        private void LlenarTipoEvento()
        {
            TipoEvento tipoEvento = new TipoEvento();
            cboTipoEven2.ItemsSource = tipoEvento.ReadAll();

            cboTipoEven2.DisplayMemberPath = "Descripcion";
            cboTipoEven2.SelectedValuePath = "Id";

            cboTipoEven2.SelectedIndex = -1;
        }

        private void LlenarTipoAmbientacion()
        {
            TipoAmbientacion tipoAmbi = new TipoAmbientacion();
            cboTipoAmbi2.ItemsSource = tipoAmbi.ReadAll();

            cboTipoAmbi2.DisplayMemberPath = "Descripcion";
            cboTipoAmbi2.SelectedValuePath = "Id";

        }

        private void LlenarModalidadServicio()
        {
            ModalidadServicio modalidadServicio = new ModalidadServicio();
            cboModalidadServ2.ItemsSource = modalidadServicio.ReadAll();

            cboModalidadServ2.DisplayMemberPath = "Nombre";
            cboModalidadServ2.SelectedValuePath = "Id";

            cboModalidadServ2.SelectedIndex = -1;
        }



        private async void btnCrearContra_Click(object sender, RoutedEventArgs e)
        {


            Contrato contrato = new Contrato()
            {
                Numero = DateTime.Now.ToString("yyyyMMddHHmm"),
                Creacion = DateTime.Now,
                Termino = new DateTime(2030, 1, 1),
                RutCliente = txtRunCli.Text,
                IdModalidad = (int)cboModalidadServ2.SelectedValue,
                IdTipoEvento = (int)cboTipoEven2.SelectedValue,
                FechaHoraInicio = (DateTime)dtInicio.SelectedDateTime,
                FechaHoraTermino = (DateTime)dtTermino.SelectedDateTime,
                Asistentes = int.Parse(txtAsistentes.Text),
                PersonalAdicional = int.Parse(txtPersonAdic.Text),
                Realizado = false,
                ValorTotalContrato = valorcoti,
                Observaciones = txtObservaciones.Text,

            };


            CoffeeBreak coffee = new CoffeeBreak()
            {
                Numero = DateTime.Now.ToString("yyyyMMddHHmm"),
                Vegetariana = vegetariana
            };

            if ((int)cboTipoEven2.SelectedValue == 3)
            {
                if (chkAmbientacion.IsChecked == false)
                {
                    ambientacion = 1;
                    añadirAmbi = false;
                }
                else
                {
                    ambientacion = (int)cboTipoAmbi2.SelectedValue;
                    añadirAmbi = true;
                }
            }

            if ((int)cboTipoEven2.SelectedValue == 3)
            {
                if (chkMusica.IsChecked == false)
                {
                    musicaCliente = true;
                    musicaAmbiente = false;
                }
                else
                {
                    musicaCliente = false;
                    musicaAmbiente = true;
                }
            }


            Cocktail cocktail = new Cocktail()
            {
                Numero = DateTime.Now.ToString("yyyyMMddHHmm"),
                IdTipoAmbientacion = ambientacion,
                Ambientacion = añadirAmbi,
                MusicaAmbiental = musicaAmbiente,
                MusicaCliente = musicaCliente,
            };

            if ((int)cboTipoEven2.SelectedValue == 2)
            {
                if (rdOnBreak.IsChecked == true)
                {
                    localOnBreak = true;

                    localArriendo = false;
                }
                else if (rdArriendo.IsChecked == true)
                {
                    localOnBreak = false;
                    localArriendo = true;
                    valorAriendoLocal = int.Parse(txtValor.Text);
                }
                else if (rdCliente.IsChecked == true)
                {
                    localOnBreak = false;
                    otroLocalOnBreak = true;
                }
            }

            if ((int)cboTipoEven2.SelectedValue == 2)
            {
                if (cboTipoAmbi2.SelectedValue == null)
                {
                    ambientacionCena = 1;
                }
                else
                {
                    ambientacionCena = (int)cboTipoAmbi2.SelectedValue;
                }
            }
            Cenas cenas = new Cenas()
            {
                Numero = DateTime.Now.ToString("yyyyMMddHHmm"),
                IdTipoAmbientacion = ambientacionCena,
                MusicaAmbiental = musicaAmbiente,
                LocalOnBreak = localOnBreak,
                OtroLocalOnBreak = otroLocalOnBreak,
                ValorArriendo = valorAriendoLocal,
            };
            if ((int)cboTipoEven2.SelectedValue == 1)
            {

                if (contrato.Create() && coffee.Create())
                {
                    await this.ShowMessageAsync("Alerta", "Contrato registrado exitosamente.");
                    Limpiar();
                }
                else
                {
                    await this.ShowMessageAsync("Alerta", "Contrato no registrado exitosamente.");

                }

            }
            else if ((int)cboTipoEven2.SelectedValue == 2)
            {
                if (contrato.Create() && cenas.Create())
                {
                    await this.ShowMessageAsync("Alerta", "Contrato registrado exitosamente.");
                    Limpiar();
                }
                else
                {
                    await this.ShowMessageAsync("Alerta", "Contrato no registrado exitosamente.");
                }
            }

            else if ((int)cboTipoEven2.SelectedValue == 3)
            {
                if (contrato.Create() && cocktail.Create())
                {
                    await this.ShowMessageAsync("Alerta", "Contrato registrado exitosamente.");
                    Limpiar();
                }
                else
                {
                    await this.ShowMessageAsync("Alerta", "Contrato no registrado exitosamente.");
                }
            }


        }

        private void Limpiar()
        {
            cboTipoEven2.SelectedIndex = -1;
            cboModalidadServ2.SelectedIndex = -1;
            txtObservaciones.Text = string.Empty;
            txtRunCli.Text = string.Empty;
            txtPersonAdic.Text = string.Empty;
            txtAsistentes.Text = string.Empty;

            chkVegetariana.IsEnabled = false;

            rdArriendo.IsEnabled = false;
            rdCliente.IsEnabled = false;
            rdOnBreak.IsEnabled = false;
            txtValor.IsEnabled = false;
            chkMusica.IsEnabled = false;

            txtValor.Text = string.Empty;
            txtValor.IsEnabled = false;

            txtValorTotal.Text = string.Empty;

            LlenarModalidadServicio();
            LlenarTipoAmbientacion();
            LlenarTipoEvento();


        }


        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            Contratos contratos = new Contratos();

            contratos.Show();
            this.Close();
        }

        private void cboTipoEven_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboTipoEven2.SelectedValue != null)
            {
                if ((int)cboTipoEven2.SelectedValue == 1)
                {
                    chkVegetariana.IsEnabled = true;

                    rdArriendo.IsEnabled = false;
                    rdCliente.IsEnabled = false;
                    rdOnBreak.IsEnabled = false;
                    txtValor.IsEnabled = false;
                    chkAmbientacion.IsEnabled = false;
                    chkMusica.IsEnabled = false;

                }
                else if ((int)cboTipoEven2.SelectedValue == 3)
                {
                    chkVegetariana.IsEnabled = false;
                    rdArriendo.IsEnabled = false;
                    rdCliente.IsEnabled = false;
                    rdOnBreak.IsEnabled = false;

                    chkAmbientacion.IsEnabled = true;
                    chkMusica.IsEnabled = true;
                    if (chkAmbientacion.IsChecked == true)
                    {
                        cboTipoAmbi2.IsEnabled = true;
                    }
                    else if (chkAmbientacion.IsChecked == false)
                    {
                        cboTipoAmbi2.IsEnabled = false;
                    }
                }
                else if ((int)cboTipoEven2.SelectedValue == 2)
                {
                    chkVegetariana.IsEnabled = false;
                    txtValor.IsEnabled = false;
                    chkAmbientacion.IsEnabled = false;

                    chkMusica.IsEnabled = true;
                    cboTipoAmbi2.IsEnabled = true;
                    rdArriendo.IsEnabled = true;
                    rdCliente.IsEnabled = true;
                    rdOnBreak.IsEnabled = true;


                    if (rdArriendo.IsChecked == true)
                    {
                        txtValor.IsEnabled = true;
                    }
                    else if (rdArriendo.IsChecked == false)
                    {
                        txtValor.IsEnabled = false;
                    }

                }
            }
        }

        private void rdArriendo_Checked(object sender, RoutedEventArgs e)
        {
            otroLocalOnBreak = true;
            txtValor.IsEnabled = true;
        }

        private void chkAmbientacion_Checked(object sender, RoutedEventArgs e)
        {
            cboTipoAmbi2.IsEnabled = true;
        }

        private void cboTipoAmbi2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void chkVegetariana_Checked(object sender, RoutedEventArgs e)
        {
            vegetariana = true;
        }



    }


}
