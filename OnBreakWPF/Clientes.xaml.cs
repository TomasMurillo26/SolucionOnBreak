﻿using System;
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
            InitializeComponent();
            GridClientes.ItemsSource = null;
            txtRut1.SetValue(TextBoxHelper.WatermarkProperty, "Ingrese RUT");
            cboActividadEmpresa.SetValue(TextBoxHelper.WatermarkProperty, "Seleccione");
            cboTipoEmpresa.SetValue(TextBoxHelper.WatermarkProperty, "Seleccione");
            LimpiarControles();

        }

        private void LimpiarControles()
        {
            /* Limpia los controles de texto */
            CargarActividadEmpresas();
            CargarTipoEmpresas();
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

        private async void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            GridClientes.ItemsSource = null;
            Cliente cliente = new Cliente();

            

            if(cboActividadEmpresa.SelectedItem != null && cboTipoEmpresa.SelectedItem != null)
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
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
    }
}