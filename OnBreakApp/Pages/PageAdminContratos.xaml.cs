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
using System.Runtime.Caching;
using OnBreak.Library.Models;

namespace OnBreakApp.Pages
{
    /// <summary>
    /// Interaction logic for PageAdminContratos.xaml
    /// </summary>
    public partial class PageAdminContratos : Page
    {
        Valorizador valorizador = new Valorizador();
        FileCache f = new FileCache(new ObjectBinder());
        private bool invalidDate;

        public PageAdminContratos()
        {
            InitializeComponent();
            PopCbo();

            lblRespaldo.Content = f["horaRespaldo"];

        }

        // Init con parámetro para llamar del listado
        public PageAdminContratos(string numContrato)
        {
            InitializeComponent();
            PopCbo();
            Contrato contrato = new Contrato().Read(numContrato);
            DataContrato(contrato);

            lblRespaldo.Content = f["horaRespaldo"];

        }

        // Init con parámetro para llamar de admin clientes
        public PageAdminContratos(string rut, string name)
        {
            InitializeComponent();
            PopCbo();

            txtRut.Text = rut;
            lblRespaldo.Content = f["horaRespaldo"];

        }

        #region respaldo
        public void Backup()
        {
            Dispatcher.Invoke(() =>
            {
                Contrato contrato = new Contrato();
                CoffeeBreak coffeeBreak = new CoffeeBreak();
                Cocktail cocktail = new Cocktail();
                Cenas cenas = new Cenas();

                if (lblNumContrato.Content != null)
                {
                    contrato.Numero = lblNumContrato.Content.ToString();
                }

                contrato.Cliente = new Cliente()
                {
                    RutCliente = txtRut.Text.ToString()
                };

                if (dpFechaInicio.SelectedDateTime != null)
                {
                    contrato.FechaHoraInicio = (DateTime)dpFechaInicio.SelectedDateTime;
                }

                if (dpFechaTermino.SelectedDateTime != null)
                {
                    contrato.FechaHoraTermino = (DateTime)dpFechaTermino.SelectedDateTime;
                }

                contrato.ModalidadServicio = new ModalidadServicio()
                {
                    IdModalidad = cboModalidad.SelectedValue.ToString(),
                    TipoEvento = new TipoEvento()
                    {
                        IdTipoEvento = int.Parse(cboTipoEvento.SelectedValue.ToString())
                    }
                };

                // SE VALIDA TIPO EVENTO PARA CREAR EL CACHE CORRESPONDIENTE
                // coffeeBreak
                if (cboTipoEvento.SelectedValue.ToString() == "10")
                {
                    coffeeBreak.Vegetariana = chkVegetariana.IsChecked.Value;
                    f["coffeeBreak"] = coffeeBreak;
                }
                // cocktail
                else if (cboTipoEvento.SelectedValue.ToString() == "20"
                && cboAmbientacion.SelectedValue != null)
                {
                    cocktail.TipoAmbientacion = new TipoAmbientacion()
                    {
                        Id = int.Parse(cboAmbientacion.SelectedValue.ToString())
                    };

                    cocktail.MusicaAmbiental = chkMusica.IsChecked.Value;

                    f["cocktail"] = cocktail;
                }
                // cenas
                else if (cboTipoEvento.SelectedValue.ToString() == "30")
                {
                    cenas.TipoAmbientacion = new TipoAmbientacion()
                    {
                        Id = int.Parse(cboAmbientacion.SelectedValue.ToString())
                    };

                    cenas.MusicaAmbiental = chkMusica.IsChecked.Value;
                    cenas.LocalOnBreak = chkLocalOnBreak.IsChecked.Value;
                    f["cenas"] = cenas;
                }
                

                if (int.TryParse(txtCantAsist.Text, out int a) == true)
                {
                    contrato.Asistentes = a;
                }
                if (int.TryParse(txtCantPersonal.Text, out int p) == true)
                {
                    contrato.PersonalAdicional = p;
                }

                contrato.Observaciones = txtObservaciones.Text;
                contrato.Realizado = chkRealizado.IsChecked.Value;

                string horaRespaldo = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                f["contrato"] = contrato;
                f["horaRespaldo"] = horaRespaldo;
                lblRespaldo.Content = horaRespaldo;
            });
        }

        private void RestoreBackup()
        {
            FileCache f = new FileCache(new ObjectBinder());

            if (f["contrato"] != null)
            {
                Contrato contrato = (Contrato)f["contrato"];

                lblRespaldo.Content = f["horaRespaldo"];

                lblNumContrato.Content = contrato.Numero;
                txtRut.Text = contrato.Cliente.RutCliente;

                if (contrato.FechaHoraInicio.Year != 1)
                {
                    dpFechaInicio.SelectedDateTime = contrato.FechaHoraInicio;
                }
                if (contrato.FechaHoraTermino.Year != 1)
                {
                    dpFechaTermino.SelectedDateTime = contrato.FechaHoraTermino;
                }

                cboTipoEvento.SelectedValue = contrato.ModalidadServicio.TipoEvento.IdTipoEvento;
                cboModalidad.SelectedValue = contrato.ModalidadServicio.IdModalidad;
                txtCantAsist.Text = contrato.Asistentes.ToString();
                txtCantPersonal.Text = contrato.PersonalAdicional.ToString();
                txtObservaciones.Text = contrato.Observaciones;
                chkRealizado.IsChecked = contrato.Realizado;
            }

            // SE VALIDA EL TIPO EVENTO RESTAURADO PARA RESTAURAR EL CACHE CORRESPONDIENTE
            if (cboTipoEvento.SelectedValue.ToString() == "10" &&
                f["coffeeBreak"] != null)
            {
                CoffeeBreak cofeeBreak = (CoffeeBreak)f["coffeeBreak"];
                chkVegetariana.IsChecked = cofeeBreak.Vegetariana;
            }
            else if (cboTipoEvento.SelectedValue.ToString() == "20" &&
                f["cocktail"] != null)
            {
                Cocktail cocktail = (Cocktail)f["cocktail"];
                cboAmbientacion.SelectedValue = cocktail.TipoAmbientacion.Id;
                chkMusica.IsChecked = cocktail.MusicaAmbiental;
            }
            else if (cboTipoEvento.SelectedValue.ToString() == "30" &&
                f["cenas"] != null)
            {
                Cenas cenas = (Cenas)f["cenas"];
                cboAmbientacion.SelectedValue = cenas.TipoAmbientacion.Id;
                chkMusica.IsChecked = cenas.MusicaAmbiental;
                chkLocalOnBreak.IsChecked = cenas.LocalOnBreak;
            }
            CalcularMonto();
        }
        #endregion

        #region botones CRUD

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
            await InvalidDate();

            if (invalidDate)
            {
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
                EnableButtons(true);
                btnRegistrarContrato.IsEnabled = false;
                btnRegistrarContrato.Opacity = 0.5;
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
                await MetroDialogue("Modificar contrato",
                    "Cantidad de asistentes y personal sólo acepta números");
                return;
            }
            await InvalidDate();

            if (invalidDate)
            {
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
                                .ShowMessageAsync("Finalizar contrato",
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
        #endregion

        #region otros botones
        private void LimpiarDatos_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();
        }

        private void BtnBackup(object sender, RoutedEventArgs e)
        {
            Backup();
        }

        private void BtnRestoreBackup(object sender, RoutedEventArgs e)
        {
            RestoreBackup();
        }
        #endregion

        #region validaciones
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

        private async Task InvalidDate()
        {
            if (dpFechaInicio.SelectedDateTime > dpFechaTermino.SelectedDateTime)
            {
                invalidDate = true;
                await MetroDialogue("Fecha inválida", 
                    "La fecha de término no puede ser menor a la de inicio del evento");
            }
            else if(dpFechaInicio.SelectedDateTime < DateTime.Now)
            {
                invalidDate = true;
                await MetroDialogue("Fecha inválida",
                    "La fecha de inicio del evento no puede ser menor a la de fecha actual");
            }
            else if (DateTime.Now.AddMonths(10) < dpFechaInicio.SelectedDateTime)
            {
                invalidDate = true;
                await MetroDialogue("Fecha inválida",
                    "El inicio del evento no puede superar los 10 meses desde la fecha actual");
            }
            else if(dpFechaInicio.SelectedDateTime.Value.AddHours(24) < dpFechaTermino.SelectedDateTime)
            {
                invalidDate = true;
                await MetroDialogue("Fecha inválida",
                    "La duración del evento debe ser de un máximo de 24 horas");
            }
            else
            {
                invalidDate = false;
            }
        }
        #endregion

        #region enable/disable sections
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

        private void AditionalOptions()
        {
            if (cboTipoEvento.SelectedValue.ToString() == "10")
            {
                chkVegetariana.IsEnabled = true;
                chkVegetariana.IsChecked = false;
                chkVegetariana.Opacity = 1;

                cboAmbientacion.IsEnabled = false;
                cboAmbientacion.SelectedIndex = -1;
                cboAmbientacion.Opacity = 0.5;

                chkMusica.IsEnabled = false;
                chkMusica.IsChecked = false;
                chkMusica.Opacity = 0.5;

                chkLocalOnBreak.IsEnabled = false;
                chkLocalOnBreak.IsChecked = false;
                chkLocalOnBreak.Opacity = 0.5;
            }
            else if (cboTipoEvento.SelectedValue.ToString() == "20")
            {
                cboAmbientacion.IsEnabled = true;
                cboAmbientacion.SelectedIndex = -1;
                cboAmbientacion.Opacity = 1;

                chkMusica.IsEnabled = true;
                chkMusica.Opacity = 1;

                chkVegetariana.IsEnabled = false;
                chkVegetariana.IsChecked = false;
                chkVegetariana.Opacity = 0.5;

                chkLocalOnBreak.IsEnabled = false;
                chkLocalOnBreak.IsChecked = false;
                chkLocalOnBreak.Opacity = 0.5;
            }
            else
            {
                cboAmbientacion.IsEnabled = true;
                cboAmbientacion.SelectedIndex = 0;
                cboAmbientacion.Opacity = 1;

                chkMusica.IsEnabled = true;
                chkMusica.Opacity = 1;

                chkLocalOnBreak.IsEnabled = true;
                chkLocalOnBreak.Opacity = 1;

                chkVegetariana.IsEnabled = false;
                chkVegetariana.IsChecked = false;
                chkVegetariana.Opacity = 0.5;
            }
        }
        #endregion

        #region popular datos
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

        public void PopCbo()
        {
            TipoEvento tipoEvento = new TipoEvento();
            TipoAmbientacion tipoAmbientacion = new TipoAmbientacion();
            // tipos de eventos
            cboTipoEvento.ItemsSource = tipoEvento.ReadAll();
            cboTipoEvento.DisplayMemberPath = "Descripcion";
            cboTipoEvento.SelectedValuePath = "IdTipoEvento";
            cboTipoEvento.SelectedIndex = 0;

            cboAmbientacion.ItemsSource = tipoAmbientacion.ReadAll();
            cboAmbientacion.DisplayMemberPath = "Desc";
            cboAmbientacion.SelectedValuePath = "Id";
            cboAmbientacion.SelectedIndex = -1;
        }
        #endregion    

        #region metodos que performan una accion
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
            AditionalOptions();
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

        // metodo que trae el parentWindow del currentPage para mostrar metro dialogue
        private async Task MetroDialogue(string title, string message)
        {
            await this.TryFindParent<MetroWindow>()
                                .ShowMessageAsync(title, message);
        }
        #endregion

        #region cambios del usuario en la visual
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

            AditionalOptions();
        }

        // calcular monto 
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

        // BACKUPS AL PERDER FOCO EN CADA ELEMENTO DE LA UI
        private void txtRut_LostFocus(object sender, RoutedEventArgs e)
        {
            Backup();
        }

        private void dpFechaInicio_LostFocus(object sender, RoutedEventArgs e)
        {
            Backup();
        }

        private void dpFechaTermino_LostFocus(object sender, RoutedEventArgs e)
        {
            Backup();
        }

        private void chkVegetariana_Checked(object sender, RoutedEventArgs e)
        {
            Backup();
        }

        private void chkVegetariana_Unchecked(object sender, RoutedEventArgs e)
        {
            Backup();
        }

        private void cboAmbientacion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cboAmbientacion.SelectedValue != null)
            {
                Backup();
            }
        }

        private void chkMusica_Checked(object sender, RoutedEventArgs e)
        {
            Backup();
        }

        private void chkMusica_Unchecked(object sender, RoutedEventArgs e)
        {
            Backup();
        }

        private void chkLocalOnBreak_Checked(object sender, RoutedEventArgs e)
        {
            Backup();
        }

        private void chkLocalOnBreak_Unchecked(object sender, RoutedEventArgs e)
        {
            Backup();
        }

        private void txtObservaciones_LostFocus(object sender, RoutedEventArgs e)
        {
            Backup();
        }

        private void chkRealizado_Checked(object sender, RoutedEventArgs e)
        {
            Backup();
        }

        private void chkRealizado_Unchecked(object sender, RoutedEventArgs e)
        {
            Backup();
        }

        private void txtCantAsist_LostFocus(object sender, RoutedEventArgs e)
        {
            Backup();
        }

        private void txtCantPersonal_LostFocus(object sender, RoutedEventArgs e)
        {
            Backup();
        }
        private void cboModalidad_LostFocus(object sender, RoutedEventArgs e)
        {
            Backup();
        }

        private void cboTipoEvento_LostFocus(object sender, RoutedEventArgs e)
        {
            Backup();
        }
        #endregion
    }
}