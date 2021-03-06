﻿using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using OnBreak.Library;
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

namespace OnBreakApp.Pages
{
    /// <summary>
    /// Interaction logic for PageListadoClientes.xaml
    /// </summary>
    public partial class PageListadoClientes : Page
    {
        public PageListadoClientes()
        {
            InitializeComponent();
            PopCbo();
            PopDg();
        }

        #region botones navegacion
        private async void BtnVerCliente(object sender, RoutedEventArgs e)
        {
            if (dgClientes.SelectedItem == null)
            {
                await MetroDialogue("Ver cliente", "No has seleccionado ningún cliente");
                return;
            }
            Cliente cliente = dgClientes.SelectedItem as Cliente;
            string rut = cliente.RutCliente;
            NavigationService.Navigate(new PageAdminClientes(rut));
        }

        private async void BtnVerContratosCliente_Click(object sender, RoutedEventArgs e)
        {
            if (dgClientes.SelectedItem == null)
            {
                await MetroDialogue("Ver contratos", "No has seleccionado ningún cliente");
                return;
            }
            Cliente cliente = dgClientes.SelectedItem as Cliente;
            string rut = cliente.RutCliente;
            NavigationService.Navigate(new PageListadoContratos(rut));
        }
        #endregion

        #region popular datos
        public void PopCbo()
        {
            TipoEmpresa tipoEmpresa = new TipoEmpresa();
            ActividadEmpresa actividadEmpresa = new ActividadEmpresa();
            cboTipoEmpresa.ItemsSource = tipoEmpresa.ReadAll();
            cboTipoEmpresa.DisplayMemberPath = "Descripcion";
            cboTipoEmpresa.SelectedValuePath = "IdTipoEmpresa";
            cboActividadEmpresa.ItemsSource = actividadEmpresa.ReadAll();
            cboActividadEmpresa.DisplayMemberPath = "Descripcion";
            cboActividadEmpresa.SelectedValuePath = "IdActividadEmpresa";
        }

        public void PopDg()
        {
            Cliente cliente = new Cliente();
            dgClientes.ItemsSource = null;
            dgClientes.ItemsSource = cliente.ReadAll();
        }
        #endregion

        #region otros botones
        private void BtnLimpiarFiltros_Click(object sender, RoutedEventArgs e)
        {
            txtRut.Text = string.Empty;
            cboTipoEmpresa.SelectedIndex = -1;
            cboActividadEmpresa.SelectedIndex = -1;
            PopDg();
        }
        #endregion

        #region deteccion de cambios en la visual
        // SECCION FILTROS
        private void TxtRut_KeyUp(object sender, KeyEventArgs e)
        {
            List<Cliente> clientes = new Cliente().ReadAllByRut(txtRut.Text);
            PopDgFiltered(clientes);
        }

        private void CboTipoEmpresa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboTipoEmpresa.SelectedValue != null)
            {
                Cliente cliente = new Cliente();
                int idTipo = int.Parse(cboTipoEmpresa.SelectedValue.ToString());
                List<Cliente> clientes = cliente.ReadAllByTipoEmpresa(idTipo);
                PopDgFiltered(clientes);
            }
        }

        private void CboActividadEmpresa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboActividadEmpresa.SelectedValue != null)
            {
                Cliente cliente = new Cliente();
                int idAct = int.Parse(cboActividadEmpresa.SelectedValue.ToString());
                List<Cliente> clientes = cliente.ReadAllByActividadEmpresa(idAct);
                PopDgFiltered(clientes);
            }
        }
        #endregion

        #region metodos que performan una accion
        private void PopDgFiltered(List<Cliente> clientes)
        {
            dgClientes.ItemsSource = null;
            dgClientes.ItemsSource = clientes;
        }

        private async Task MetroDialogue(string title, string message)
        {
            await this.TryFindParent<MetroWindow>()
                                .ShowMessageAsync(title, message);
        }
        #endregion
    }
}
