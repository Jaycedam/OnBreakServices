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


        public PageAdminContratos()
        {
            InitializeComponent();
            PopCbo();

            lblRespaldo.Content = f["horaRespaldo"];

        }

        // Init con constructor para llamar del listado
        public PageAdminContratos(string numContrato)
        {
            InitializeComponent();
            PopCbo();
            Contrato contrato = new Contrato().Read(numContrato);
            DataContrato(contrato);

            lblRespaldo.Content = f["horaRespaldo"];

        }

        #region respaldo
        public void Backup()
        {
            Dispatcher.Invoke(() =>
            {
                Contrato contrato = new Contrato();
                Cocktail cocktail = new Cocktail();
                Cenas cena = new Cenas();

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

                if(cboAmbientacion.IsEnabled == true)
                {
                    if (cboTipoEvento.SelectedValue.ToString() == "20")
                    {
                        cocktail.TipoAmbientacion = new TipoAmbientacion()
                        {
                            Id = int.Parse(cboAmbientacion.SelectedValue.ToString())
                        };

                        f["cocktail"] = cocktail;
                    }
                    else if (cboTipoEvento.SelectedValue.ToString() == "30")
                    {
                        cena.TipoAmbientacion = new TipoAmbientacion()
                        {
                            Id = int.Parse(cboAmbientacion.SelectedValue.ToString())
                        };
                        f["cenas"] = cena;
                    }
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
                Contrato c = (Contrato)f["contrato"];

                lblRespaldo.Content = f["horaRespaldo"];

                lblNumContrato.Content = c.Numero;
                txtRut.Text = c.Cliente.RutCliente;

                if (c.FechaHoraInicio.Year != 1)
                {
                    dpFechaInicio.SelectedDateTime = c.FechaHoraInicio;
                }
                if (c.FechaHoraTermino.Year != 1)
                {
                    dpFechaTermino.SelectedDateTime = c.FechaHoraTermino;
                }

                cboTipoEvento.SelectedValue = c.ModalidadServicio.TipoEvento.IdTipoEvento;
                cboModalidad.SelectedValue = c.ModalidadServicio.IdModalidad;
                txtCantAsist.Text = c.Asistentes.ToString();
                txtCantPersonal.Text = c.PersonalAdicional.ToString();
                txtObservaciones.Text = c.Observaciones;
                chkRealizado.IsChecked = c.Realizado;


                CalcularMonto();
            }
            if(f["cocktail"] != null)
            {
                Cocktail c = (Cocktail)f["cocktail"];
                cboAmbientacion.SelectedValue = c.TipoAmbientacion.Id;
            }
            else if(f["cenas"] != null)
            {
                Cenas c = (Cenas)f["cenas"];
                cboAmbientacion.SelectedValue = c.TipoAmbientacion.Id;
            }
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
            else if (InvalidDate())
            {
                await MetroDialogue("Registrar contrato",
                  "La fecha de término no puede ser anterior a la de inicio del evento");
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
                await MetroDialogue("Modificar contrato",
                    "Cantidad de asistentes y personal sólo acepta números");
                return;
            }
            else if (InvalidDate())
            {
                await MetroDialogue("Modificar contrato",
                  "La fecha de término no puede ser anterior a la de inicio del evento");
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

        private bool InvalidDate()
        {
            if (dpFechaInicio.SelectedDateTime > dpFechaTermino.SelectedDateTime)
            {
                return true;
            }
            return false;
        }
        #endregion

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
            AditionalOptions();
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

        private void AditionalOptions()
        {
            if (cboTipoEvento.SelectedValue.ToString() == "10")
            {
                cboAmbientacion.IsEnabled = false;
                cboAmbientacion.SelectedIndex = -1;
                cboAmbientacion.Opacity = 0.5;
            }
            else if(cboTipoEvento.SelectedValue.ToString() == "20")
            {
                cboAmbientacion.IsEnabled = true;
                cboAmbientacion.SelectedIndex = 0;
                cboAmbientacion.Opacity = 1;
                chkMusica.IsEnabled = true;
                chkMusica.Opacity = 1;
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
            }
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

        private void BtnBackup(object sender, RoutedEventArgs e)
        {
            Backup();
        }

        private void BtnRestoreBackup(object sender, RoutedEventArgs e)
        {
            RestoreBackup();
        }
    }
}