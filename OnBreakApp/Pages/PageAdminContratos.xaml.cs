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
    /// Interaction logic for PageAdminContratos.xaml
    /// </summary>
    public partial class PageAdminContratos : Page
    {
        Valorizador valorizador = new Valorizador();

        public PageAdminContratos()
        {
            InitializeComponent();
            PopCbo();
        }

        // Init con constructor para llamar del listado
        public PageAdminContratos(string numContrato)
        {
            InitializeComponent();
            PopCbo();
            Contrato contrato = new Contrato().Read(numContrato);
            DataContrato(contrato);
        }

        /********************************* CRUD BOTONES*********************************/

        private async void BtnRegistrarContrato_Click(object sender, RoutedEventArgs e)
        {
            if (FaltanCamposObligatorios())
            {
                await MetroDialogue("Registrar contrato",
                    "Debes ingresar todos los campos obligatorios");
                return;
            }
            else if (InvalidEntry())
            {
                await MetroDialogue("Registrar contrato",
                    "Cantidad de asistentes y personal sólo acepta números");
                return;
            }
            DateTime creationDate = DateTime.Now;
            Contrato contrato = new Contrato()
            {
                Numero = creationDate.ToString("yyyyMMddHHmm"),
                Creacion = creationDate,
                Termino = (DateTime)dpFechaTermino.SelectedDateTime,
                Cliente = new Cliente()
                {
                    RutCliente = txtRut.Text.ToUpper().Trim()
                },
                ModalidadServicio = new ModalidadServicio()
                {
                    IdModalidad = cboModalidad.SelectedValue.ToString(),
                    TipoEvento = new TipoEvento()
                    {
                        IdTipoEvento = int.Parse(cboTipoEvento.SelectedValue.ToString())
                    }
                },
                FechaHoraInicio = (DateTime)dpFechaInicio.SelectedDateTime,
                FechaHoraTermino = (DateTime)dpFechaTermino.SelectedDateTime,
                Asistentes = int.Parse(txtCantAsist.Text),
                PersonalAdicional = int.Parse(txtCantPersonal.Text),
                Realizado = chkRealizado.IsChecked.Value,
                ValorTotalContrato = double.Parse(lblMonto.Content.ToString()),
                Observaciones = txtObservaciones.Text,
            };
            if (contrato.Create(contrato))
            {
                lblNumContrato.Content = creationDate.ToString("yyyyMMddHHmm");
                await MetroDialogue("Registrar contrato",
                    "Contrato registrado correctamente");
            }
            else
            {
                await MetroDialogue("Registrar contrato",
                    "No se ha encontrado el rut del cliente");
            }
        }

        private async void BtnBuscarContrato_Click(object sender, RoutedEventArgs e)
        {
            // missing: codigo que busca cliente desde txtrutin
            if (txtNumContrato.Text == String.Empty)
            {
                await MetroDialogue("Buscar contrato",
                    "Debes ingresar el número de contrato");
            }
            else
            {
                Contrato contrato = new Contrato().Read(txtNumContrato.Text.Trim());
                DataContrato(contrato);
            }
        }

        private async void BtnModificarContrato_Click(object sender, RoutedEventArgs e)
        {
            if (FaltanCamposObligatorios())
            {
                await MetroDialogue("Modificar contrato",
                    "Debes ingresar todos los campos obligatorios");
                return;
            }
            else if (InvalidEntry())
            {
                await MetroDialogue("Registrar contrato",
                    "Cantidad de asistentes y personal sólo acepta números");
                return;
            }

            Contrato contrato = new Contrato()
            {
                Numero = lblNumContrato.Content.ToString(),
                Observaciones = txtObservaciones.Text,
                FechaHoraInicio = (DateTime)dpFechaInicio.SelectedDateTime,
                FechaHoraTermino = (DateTime)dpFechaTermino.SelectedDateTime,
                Asistentes = int.Parse(txtCantAsist.Text),
                PersonalAdicional = int.Parse(txtCantPersonal.Text),
                Realizado = chkRealizado.IsChecked.Value,
                ValorTotalContrato = double.Parse(lblMonto.Content.ToString()),
                ModalidadServicio = new ModalidadServicio()
                {
                    IdModalidad = cboModalidad.SelectedValue.ToString(),
                    TipoEvento = new TipoEvento()
                    {
                        IdTipoEvento = int.Parse(cboTipoEvento.SelectedValue.ToString())
                    }
                }

            };

            if (contrato.Update(contrato))
            {
                await MetroDialogue("Modificar contrato",
                    "Contrato modificado correctamente");
            }
            else
            {
                await MetroDialogue("Modificar contrato",
                    "Contrato no encontrado");
            }
        }


        private async void BtnFinalizarContrato_Click(object sender, RoutedEventArgs e)
        {
            //missing: codigo eliminar cliente lista
            if (FaltanCamposObligatorios())
            {
                await MetroDialogue("Finalizar contrato",
                    "Debes ingresar todos los datos obligatorios");
                return;
            }

            var result = await this.TryFindParent<MetroWindow>()
                                .ShowMessageAsync("Eliminar cliente",
                                "¿Estás seguro que deseas finalizar este contrato?",
                                MessageDialogStyle.AffirmativeAndNegative);

            if (result == MessageDialogResult.Affirmative)
            {
                Contrato contrato = new Contrato();
                if (contrato.Delete(lblNumContrato.Content.ToString()))
                {
                    await MetroDialogue("Finalizar contrato",
                        "Contrato finalizado correctamente");
                    LimpiarCampos();
                }
                else
                {
                    await MetroDialogue("Finalizar contrato",
                        "Contrato no encontrado");
                }
            }
        }

        /**********************************END CRUD************************************/
        private bool InvalidEntry()
        {
            if (int.TryParse(txtCantAsist.Text, out int a) == false ||
                int.TryParse(txtCantPersonal.Text, out int p) == false ||
                int.Parse(txtCantAsist.Text) < 0 ||
                int.Parse(txtCantPersonal.Text) < 0)
            {
                return true;
            }
            return false;
        }

        // metodo que habilita/deshabilita los botones de modificar/finalizar 
        private void EnableButtons(bool enable)
        {
            btnModificarContrato.IsEnabled = enable;
            btnFinalizarContrato.IsEnabled = enable;
            if (btnModificarContrato.IsEnabled == false)
            {
                btnModificarContrato.Opacity = 0.5;
                btnFinalizarContrato.Opacity = 0.5;
            }
            else
            {
                btnModificarContrato.Opacity = 1;
                btnFinalizarContrato.Opacity = 1;
            }
        }

        private void EnableRut(bool enable)
        {
            txtRut.IsEnabled = enable;
            if (txtRut.IsEnabled == false)
            {
                txtRut.Opacity = 0.5;
            }
            else
            {
                txtRut.Opacity = 1;
            }
        }

        //Metodo que se encarga de popular datos del contrato al buscar
        //entrega notificación si no es encontrado
        private async void DataContrato(Contrato contrato)
        {
            if (contrato == null)
            {
                await MetroDialogue("Buscar contrato",
                "Contrato no encontrado");
            }
            else
            {
                lblNumContrato.Content = contrato.Numero;
                txtRut.Text = contrato.Cliente.RutCliente;
                txtObservaciones.Text = contrato.Observaciones;
                cboTipoEvento.SelectedValue = contrato.ModalidadServicio.TipoEvento.IdTipoEvento;
                cboModalidad.SelectedValue = contrato.ModalidadServicio.IdModalidad;
                dpFechaInicio.SelectedDateTime = contrato.FechaHoraInicio;
                dpFechaTermino.SelectedDateTime = contrato.FechaHoraTermino;
                txtCantAsist.Text = contrato.Asistentes.ToString();
                txtCantPersonal.Text = contrato.PersonalAdicional.ToString();
                chkRealizado.IsChecked = contrato.Realizado;
                CalcularMonto();
                EnableButtons(true);
                EnableRut(false);
            }
        }

        // limpiar todos los campos
        private void LimpiarCampos()
        {
            lblNumContrato.Content = string.Empty;
            txtRut.Text = string.Empty;
            cboTipoEvento.SelectedIndex = 0;
            cboModalidad.SelectedIndex = 0;
            txtCantAsist.Text = string.Empty;
            txtCantPersonal.Text = string.Empty;
            dpFechaInicio.SelectedDateTime = null;
            dpFechaTermino.SelectedDateTime = null;
            txtObservaciones.Text = string.Empty;
            lblMonto.Content = "0";
            chkRealizado.IsChecked = false;
            // habilitar edición de rut
            EnableRut(true);
            EnableButtons(false);
        }

        // metodo que entrega true cuando faltan datos obligatorios
        public bool FaltanCamposObligatorios()
        {
            if (txtRut.Text == string.Empty ||
                txtCantAsist.Text == string.Empty ||
                txtCantPersonal.Text == string.Empty ||
                dpFechaInicio.SelectedDateTime == null ||
                dpFechaTermino.SelectedDateTime == null)
            {
                return true;
            }
            return false;
        }

        // metodo que trae el parentWindow del currentPage para mostrar metro dialogue
        private async Task MetroDialogue(string title, string message)
        {
            await this.TryFindParent<MetroWindow>()
                                .ShowMessageAsync(title, message);
        }

        private void LimpiarDatos_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();
        }

        public void PopCbo()
        {
            TipoEvento tipoEvento = new TipoEvento();
            // tipos de eventos
            cboTipoEvento.ItemsSource = tipoEvento.ReadAll();
            cboTipoEvento.DisplayMemberPath = "Descripcion";
            cboTipoEvento.SelectedValuePath = "IdTipoEvento";
            cboTipoEvento.SelectedIndex = 0;
        }


        // Metodo que filtra cbo de modalidad por el cbo de tipo seleccionado
        private void CboTipoEvento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ModalidadServicio modalidadServicio = new ModalidadServicio();
            // recuperar id tipo evento a través del SelectedValue
            int tipoId = int.Parse(cboTipoEvento.SelectedValue.ToString());
            cboModalidad.ItemsSource = modalidadServicio.ReadAll(tipoId);
            cboModalidad.DisplayMemberPath = "Nombre";
            cboModalidad.SelectedValuePath = "IdModalidad";
            cboModalidad.SelectedIndex = 0;
        }

        // calcular monto en UF al escribir cantidad de asistentes/personal
        private void CalcularMonto()
        {
            if (txtCantAsist.Text == string.Empty ||
                txtCantPersonal.Text == string.Empty ||
                cboModalidad.SelectedValue == null ||
                InvalidEntry())
            {
                lblMonto.Content = "0";
                return;
            }
            Contrato contrato = new Contrato()
            {
                Asistentes = int.Parse(txtCantAsist.Text),
                PersonalAdicional = int.Parse(txtCantPersonal.Text),
                ModalidadServicio = new ModalidadServicio()
                {
                    IdModalidad = cboModalidad.SelectedValue.ToString(),
                    TipoEvento = new TipoEvento()
                    {
                        IdTipoEvento = int.Parse(cboTipoEvento.SelectedValue.ToString())
                    }
                }
            };
            lblMonto.Content = valorizador.CalcularValorEvento(contrato);
        }

        private void txtCantPersonal_KeyUp(object sender, KeyEventArgs e)
        {
            CalcularMonto();
        }

        private void TxtCantAsist_KeyUp(object sender, KeyEventArgs e)
        {
            CalcularMonto();
        }

        private void CboModalidad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalcularMonto();
        }
    }
}