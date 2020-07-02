using MahApps.Metro.Controls;
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
    /// Interaction logic for PageListadoContratos.xaml
    /// </summary>
    public partial class PageListadoContratos : Page
    {
        public PageListadoContratos()
        {
            InitializeComponent();
            PopDg();
            PopCbo();
        }

        // init con constructor para llamar como modulo // dg filtrada
        public PageListadoContratos(string rut)
        {
            InitializeComponent();
            PopCbo();
            txtRut.Text = rut;
            Contrato contrato = new Contrato();
            List<Contrato> contratos = contrato.ReadAllByRut(rut);
            PopDgFiltered(contratos);
        }

        #region botones de navegacion
        private async void BtnVerInfoCliente_Click(object sender, RoutedEventArgs e)
        {
            if (dgContratos.SelectedItem == null)
            {
                await MetroDialogue("Ver cliente", "No has seleccionado ningún contrato");
                return;
            }
            Contrato contrato = dgContratos.SelectedItem as Contrato;
            string rut = contrato.Cliente.RutCliente;
            NavigationService.Navigate(new PageAdminClientes(rut));
        }

        private async void BtnVerContrato_Click(object sender, RoutedEventArgs e)
        {
            if (dgContratos.SelectedItem == null)
            {
                await MetroDialogue("Ver contrato", "No has seleccionado ningún contrato");
                return;
            }
            Contrato contrato = dgContratos.SelectedValue as Contrato;
            string numContrato = contrato.Numero;
            NavigationService.Navigate(new PageAdminContratos(numContrato));
        }
        #endregion

        #region popular datos
        public void PopDg()
        {
            Contrato contrato = new Contrato();
            dgContratos.ItemsSource = null;
            dgContratos.ItemsSource = contrato.ReadAll();
        }

        public void PopCbo()
        {
            TipoEvento tipoEvento = new TipoEvento();
            cboTipoEvento.ItemsSource = tipoEvento.ReadAll();
            cboTipoEvento.DisplayMemberPath = "Descripcion";
            cboTipoEvento.SelectedValuePath = "IdTipoEvento";
        }
        #endregion

        #region botones de accion
        private void BtnLimpiarFiltros_Click(object sender, RoutedEventArgs e)
        {
            txtNumContrato.Text = string.Empty;
            txtRut.Text = string.Empty;
            cboTipoEvento.SelectedIndex = -1;
            cboModalidad.SelectedIndex = -1;
            PopDg();
        }
        #endregion

        #region metodos que performan una accion
        private void PopDgFiltered(List<Contrato> contratos)
        {
            dgContratos.ItemsSource = null;
            dgContratos.ItemsSource = contratos;
        }
        private async Task MetroDialogue(string title, string message)
        {
            await this.TryFindParent<MetroWindow>()
                                .ShowMessageAsync(title, message);
        }
        #endregion

        #region deteccion de cambios en la visual
        // SECCION FILTROS
        private void TxtNumContrato_KeyUp(object sender, KeyEventArgs e)
        {
            Contrato contrato = new Contrato();
            List<Contrato> contratos = contrato.ReadAllByNumeroContrato(txtNumContrato.Text);
            PopDgFiltered(contratos);
        }
        private void TxtRut_KeyUp(object sender, KeyEventArgs e)
        {
            Contrato contrato = new Contrato();
            List<Contrato> contratos = contrato.ReadAllByRut(txtRut.Text);
            PopDgFiltered(contratos);
        }
        private void CboTipoEvento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboTipoEvento.SelectedValue != null)
            {
                Contrato contrato = new Contrato();
                int idTipo = int.Parse(cboTipoEvento.SelectedValue.ToString());
                List<Contrato> contratos = contrato.ReadAllByTipoEvento(idTipo);
                PopDgFiltered(contratos);
                // ENLAZAR CBO MODALIDAD
                ModalidadServicio modalidadServicio = new ModalidadServicio();
                cboModalidad.ItemsSource = modalidadServicio.ReadAll(idTipo);
                cboModalidad.DisplayMemberPath = "Nombre";
                cboModalidad.SelectedValuePath = "IdModalidad";
            }
        }
        private void CboModalidad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboModalidad.SelectedValue != null)
            {
                Contrato contrato = new Contrato();
                string idMod = cboModalidad.SelectedValue.ToString();
                List<Contrato> contratos = contrato.ReadAllByModalidad(idMod);
                PopDgFiltered(contratos);
            }
        }
        #endregion
    }
}
