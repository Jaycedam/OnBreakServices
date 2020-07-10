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
using OnBreak.Library.Decorator;

namespace OnBreakApp.Pages
{
    /// <summary>
    /// Interaction logic for PageAdminContratos.xaml
    /// </summary>
    public partial class PageAdminContratos : Page
    {
        FileCache f = new FileCache(new ObjectBinder());
        private bool invalidDate;

        #region constructores
        public PageAdminContratos()
        {
            InitializeComponent();
            PopCbo();
            lblRespaldo.Content = f["horaRespaldo"];
        }

        public PageAdminContratos(string numContrato)
        {
            InitializeComponent();
            PopCbo();
            Contrato contrato = new Contrato().Read(numContrato);
            DataContrato(contrato);
            lblRespaldo.Content = f["horaRespaldo"];
        }

        public PageAdminContratos(string rut, string name)
        {
            InitializeComponent();
            PopCbo();
            txtRut.Text = rut;
            lblRespaldo.Content = f["horaRespaldo"];
        }
        #endregion

        #region respaldo y restaurar
        public void Backup()
        {
            Dispatcher.Invoke(() =>
            {
                Contrato contrato = new Contrato();

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

                if(cboModalidad.SelectedValue != null)
                {
                    contrato.ModalidadServicio = new ModalidadServicio()
                    {
                        IdModalidad = cboModalidad.SelectedValue.ToString(),
                        TipoEvento = new TipoEvento()
                        {
                            IdTipoEvento = int.Parse(cboTipoEvento.SelectedValue.ToString())
                        }
                    };
                }
             

                if (int.TryParse(txtCantAsist.Text, out int a))
                {
                    contrato.Asistentes = a;
                }
                if (int.TryParse(txtCantPersonal.Text, out int p))
                {
                    contrato.PersonalAdicional = p;
                }
                contrato.Observaciones = txtObservaciones.Text;
                contrato.Realizado = chkRealizado.IsChecked.Value;

                f["contrato"] = contrato;


                // SE VALIDA TIPO EVENTO PARA CREAR EL CACHE CORRESPONDIENTE
                if (cboTipoEvento.SelectedValue.ToString() == "10")
                {
                    CoffeeBreak coffeeBreak = new CoffeeBreak();
                    coffeeBreak.Vegetariana = chkVegetariana.IsChecked.Value;
                    f["adicional"] = coffeeBreak;
                }

                else if (cboTipoEvento.SelectedValue.ToString() == "20")
                {
                    Cocktail cocktail = new Cocktail();

                    if(cboAmbientacion.SelectedValue != null)
                    {
                        cocktail.TipoAmbientacion = new TipoAmbientacion()
                        {
                            Id = int.Parse(cboAmbientacion.SelectedValue.ToString())
                        };
                    }
                   
                    cocktail.MusicaAmbiental = chkMusica.IsChecked.Value;

                    f["adicional"] = cocktail;
                }

                else if (cboTipoEvento.SelectedValue.ToString() == "30")
                {
                    Cenas cenas = new Cenas();

                    cenas.TipoAmbientacion = new TipoAmbientacion()
                    {
                        Id = int.Parse(cboAmbientacion.SelectedValue.ToString())
                    };

                    cenas.MusicaAmbiental = chkMusica.IsChecked.Value;
                    cenas.LocalOnBreak = LocalOnBreak();
                    cenas.OtroLocalOnBreak = ArrendarLocal();
                    if (double.TryParse(txtMontoArriendo.Text, out double m))
                    {
                        cenas.ValorArriendo = m;
                    }

                    cenas.LocalOnBreak = LocalOnBreak();
                    cenas.OtroLocalOnBreak = ArrendarLocal();

                    f["adicional"] = cenas;
                }

                string horaRespaldo = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
             
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
            if (f["adicional"].GetType() == typeof(CoffeeBreak))
            {
                CoffeeBreak cofeeBreak = (CoffeeBreak)f["adicional"];
                chkVegetariana.IsChecked = cofeeBreak.Vegetariana;
            }
            else if (f["adicional"].GetType() == typeof(Cocktail))
            {
                Cocktail cocktail = (Cocktail)f["adicional"];
                if(cocktail.TipoAmbientacion != null)
                {
                    cboAmbientacion.SelectedValue = cocktail.TipoAmbientacion.Id;
                }
                chkMusica.IsChecked = cocktail.MusicaAmbiental;
            }
            else if (f["adicional"].GetType() == typeof(Cenas))
            {
                Cenas cenas = (Cenas)f["adicional"];
                cboAmbientacion.SelectedValue = cenas.TipoAmbientacion.Id;
                chkMusica.IsChecked = cenas.MusicaAmbiental;

                if (cenas.LocalOnBreak)
                {
                    cboLocal.SelectedIndex = 1;
                }
                else if (cenas.OtroLocalOnBreak)
                {
                    cboLocal.SelectedIndex = 2;
                    txtMontoArriendo.Text = cenas.ValorArriendo.ToString();
                }
                else
                {
                    cboLocal.SelectedIndex = 0;
                }
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
            else if (InvalidRut(txtRut.Text))
            {
                await MetroDialogue("Registrar contrato",
                    "El rut no es válido. Formato sin puntos ni guión");
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
                Observaciones = txtObservaciones.Text
            };

            
            if (contrato.Create(contrato))
            {
                lblNumContrato.Content = creationDate.ToString("yyyyMMddHHmm");

                // CREAR TABLA DE TIPO DE EVENTO CORRESPONDIENTE AL CONTRATO
                if (cboTipoEvento.SelectedValue.ToString() == "10")
                {
                    CoffeeBreak c = new CoffeeBreak()
                    {
                        Contrato = new Contrato()
                        {
                            Numero = contrato.Numero,               
                        },
                        Vegetariana = chkVegetariana.IsChecked.Value
                    };
                    c.Create(c);
                }

                else if (cboTipoEvento.SelectedValue.ToString() == "20")
                {
                    if(cboAmbientacion.SelectedValue == null)
                    {
                        Cocktail c = new Cocktail()
                        {
                            Contrato = new Contrato()
                            {
                                Numero = contrato.Numero,
                            },
                            MusicaAmbiental = chkMusica.IsChecked.Value,
                            MusicaCliente = !(chkMusica.IsChecked.Value)
                        };
                        c.Create(c);      
                    }

                    else
                    {
                        Cocktail c = new Cocktail()
                        {
                            Contrato = new Contrato()
                            {
                                Numero = contrato.Numero,
                            },
                            TipoAmbientacion = new TipoAmbientacion()
                            {
                                Id = int.Parse(cboAmbientacion.SelectedValue.ToString())
                            },
                            MusicaAmbiental = chkMusica.IsChecked.Value,
                            MusicaCliente = !(chkMusica.IsChecked.Value)
                        };
                        c.Create(c);
                    }
                
                }
                else if (cboTipoEvento.SelectedValue.ToString() == "30")
                {
                    Cenas c = new Cenas()
                    {
                        Contrato = new Contrato()
                        {
                            Numero = contrato.Numero
                        },
                        LocalOnBreak = LocalOnBreak(),
                        OtroLocalOnBreak = ArrendarLocal(),
                        MusicaAmbiental = chkMusica.IsChecked.Value,
                        ValorArriendo = double.Parse(txtMontoArriendo.Text),
                        TipoAmbientacion = new TipoAmbientacion()
                        {
                            Id = int.Parse(cboAmbientacion.SelectedValue.ToString())
                        }
                    };
                    c.Create(c);
                }

                await MetroDialogue("Registrar contrato",
                    "Contrato registrado correctamente");

                // SE HABILITA LA MODIFICACION Y SE BLOQUEA EL BOTON REGISTRAR
                EnableEditButtons(true);
                EnableRegisterButton(false);
                EnableRut(false);
                EnableChangeTipoEvento(false);
            }

            else
            {
                await MetroDialogue("Registrar contrato",
                    "No se ha encontrado el rut del cliente");
            }
        }

        private async void BtnBuscarContrato_Click(object sender, RoutedEventArgs e)
        {
            if (txtNumContrato.Text == String.Empty)
            {
                await MetroDialogue("Buscar contrato",
                    "Debes ingresar el número de contrato");
            }

            else
            {
                Contrato contrato = new Contrato().Read(txtNumContrato.Text);
                // METODO QUE POBLA LOS DATOS DEL CONTRATO ENCONTRADO
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
                // SE ACTUALIZA LA TABLA CORRESPONDIENTE AL CONTRATO
                if (contrato.ModalidadServicio.TipoEvento.IdTipoEvento == 10)
                {
                    CoffeeBreak coffeeBreak = new CoffeeBreak()
                    {
                        Contrato = new Contrato()
                        {
                            Numero = contrato.Numero
                        },
                        Vegetariana = chkVegetariana.IsChecked.Value
                    };
                    coffeeBreak.Update(coffeeBreak);
                }

                else if (contrato.ModalidadServicio.TipoEvento.IdTipoEvento == 20)
                {
                    // SI NO HAY AMBIENTACION SELECCIONADA NO SE CREA EN LA TABLA
                    if (cboAmbientacion.SelectedIndex == -1)
                    {
                        Cocktail cocktail = new Cocktail()
                        {
                            Contrato = new Contrato()
                            {
                                Numero = contrato.Numero,
                            },
                            MusicaAmbiental = chkMusica.IsChecked.Value,
                            MusicaCliente = !(chkMusica.IsChecked.Value)
                        };
                        cocktail.Update(cocktail);
                    }

                    else
                    {
                        Cocktail cocktail = new Cocktail()
                        {
                            Contrato = new Contrato()
                            {
                                Numero = contrato.Numero,
                            },
                            TipoAmbientacion = new TipoAmbientacion()
                            {
                                Id = int.Parse(cboAmbientacion.SelectedValue.ToString())
                            },
                            MusicaAmbiental = chkMusica.IsChecked.Value,
                            MusicaCliente = !(chkMusica.IsChecked.Value)
                        };
                        cocktail.Update(cocktail);
                    }
                }

                else if (contrato.ModalidadServicio.TipoEvento.IdTipoEvento == 30)
                {
                    Cenas c = new Cenas()
                    {
                        Contrato = new Contrato()
                        {
                            Numero = contrato.Numero
                        },
                        LocalOnBreak = LocalOnBreak(),
                        OtroLocalOnBreak = ArrendarLocal(),
                        MusicaAmbiental = chkMusica.IsChecked.Value,
                        ValorArriendo = double.Parse(txtMontoArriendo.Text),
                        TipoAmbientacion = new TipoAmbientacion()
                        {
                            Id = int.Parse(cboAmbientacion.SelectedValue.ToString())
                        }
                    };
                    c.Update(c);
                }

                await MetroDialogue("Modificar contrato",
                    "Contrato modificado correctamente");
                
                // SI SE FINALIZA EL CONTRATO SE BLOQUEAN LAS EDICIONES
                if(contrato.Realizado == true)
                {
                    BlockEdits(true);
                }
            }

            else
            {
                await MetroDialogue("Modificar contrato",
                    "Contrato no encontrado");
            }
        }

        private async void BtnFinalizarContrato_Click(object sender, RoutedEventArgs e)
        {
            if (FaltanCamposObligatorios())
            {
                await MetroDialogue("Finalizar contrato",
                    "Debes ingresar todos los datos obligatorios");
                return;
            }

            // SE PIDE CONFIRMACION DE LA FINALIZACION
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
                    BlockEdits(true);
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
            if (int.TryParse(txtCantAsist.Text, out _) == false ||
                int.TryParse(txtCantPersonal.Text, out _) == false ||
                int.Parse(txtCantAsist.Text) < 0 ||
                int.Parse(txtCantPersonal.Text) < 0 ||
                double.TryParse(txtMontoArriendo.Text, out _) == false)
            {
                return true;
            }
            return false;
        }

        public bool FaltanCamposObligatorios()
        {
            if (txtRut.Text == string.Empty ||
                txtCantAsist.Text == string.Empty ||
                txtCantPersonal.Text == string.Empty ||
                dpFechaInicio.SelectedDateTime == null ||
                dpFechaTermino.SelectedDateTime == null ||
                txtMontoArriendo.Text == string.Empty)
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

        private bool InvalidRut(string rut)
        {
            if (int.TryParse(rut.Substring(0,8), out _))
            {
                if(int.TryParse(rut.Substring(8, 1), out _) ||
                    rut.Substring(8, 1).ToLower() == "k")
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region enable/disable sections
        // METODO QUE BLOQUEA TODA LA VISUAL (EXPECTED = TRUE/FALSE)
        private void BlockEdits(bool expected)
        {
            if (expected)
            {
                txtRut.IsEnabled = false;
                txtRut.Opacity = 0.5;
                dpFechaInicio.IsEnabled = false;
                dpFechaInicio.Opacity = 0.5;
                dpFechaTermino.IsEnabled = false;
                dpFechaTermino.Opacity = 0.5;
                cboTipoEvento.IsEnabled = false;
                cboTipoEvento.Opacity = 0.5;
                cboModalidad.IsEnabled = false;
                cboModalidad.Opacity = 0.5;
                chkVegetariana.IsEnabled = false;
                chkVegetariana.Opacity = 0.5;
                cboAmbientacion.IsEnabled = false;
                cboAmbientacion.Opacity = 0.5;
                chkMusica.IsEnabled = false;
                chkMusica.Opacity = 0.5;
                txtCantAsist.IsEnabled = false;
                txtCantAsist.Opacity = 0.5;
                txtCantPersonal.IsEnabled = false;
                txtCantPersonal.Opacity = 0.5;
                txtObservaciones.IsEnabled = false;
                txtObservaciones.Opacity = 0.5;
                chkRealizado.IsEnabled = false;
                chkRealizado.Opacity = 0.5;
                txtMontoArriendo.IsEnabled = false;
                txtMontoArriendo.Opacity = 0.5;
                EnableEditButtons(false);
                EnableRegisterButton(false);
            }

            else
            {
                txtRut.IsEnabled = true;
                txtRut.Opacity = 1;
                dpFechaInicio.IsEnabled = true;
                dpFechaInicio.Opacity = 1;
                dpFechaTermino.IsEnabled = true;
                dpFechaTermino.Opacity = 1;
                cboTipoEvento.IsEnabled = true;
                cboTipoEvento.Opacity = 1;
                cboModalidad.IsEnabled = true;
                cboModalidad.Opacity = 1;
                chkVegetariana.IsEnabled = true;
                chkVegetariana.Opacity = 1;
                cboAmbientacion.IsEnabled = true;
                cboAmbientacion.Opacity = 1;
                chkMusica.IsEnabled = true;
                chkMusica.Opacity = 1;
                txtCantAsist.IsEnabled = true;
                txtCantAsist.Opacity = 1;
                txtCantPersonal.IsEnabled = true;
                txtCantPersonal.Opacity = 1;
                txtObservaciones.IsEnabled = true;
                txtObservaciones.Opacity = 1;
                chkRealizado.IsEnabled = true;
                chkRealizado.Opacity = 1;
                AditionalOptions();
            }
        }

        private void EnableEditButtons(bool enable)
        {
            btnModificarContrato.IsEnabled = enable;
            btnFinalizarContrato.IsEnabled = enable;

            if (enable)
            {
                btnModificarContrato.Opacity = 1;
                btnFinalizarContrato.Opacity = 1;
            }

            else
            {
                btnModificarContrato.Opacity = 0.5;
                btnFinalizarContrato.Opacity = 0.5;
            }
        }

        private void EnableRegisterButton(bool enable)
        {
            btnRegistrarContrato.IsEnabled = enable;

            if (enable)
            {
                btnRegistrarContrato.Opacity = 1;
            }
            else
            {
                btnRegistrarContrato.Opacity = 0.5;
            }
        }

        private void EnableRut(bool enable)
        {
            txtRut.IsEnabled = enable;
            if (enable)
            {
                txtRut.Opacity = 1;
            }
            else
            {
                txtRut.Opacity = 0.5;
            }
        }

        private void EnableChangeTipoEvento(bool enable)
        {
            cboTipoEvento.IsEnabled = enable;
            if (enable)
            {
                cboTipoEvento.Opacity = 1;
            }
            else
            {
                cboTipoEvento.Opacity = 0.5;
            }
        }

        // METODO ENCARGADO DE HABILITAR OPCIONES ADICIONALES POR TIPO DE EVENTO SELECCIONADO
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

                cboLocal.IsEnabled = false;
                cboLocal.Opacity = 0.5;
                cboLocal.SelectedIndex = 0;
            }

            else if (cboTipoEvento.SelectedValue.ToString() == "20")
            {
                cboAmbientacion.IsEnabled = true;
                cboAmbientacion.SelectedIndex = -1;
                cboAmbientacion.Opacity = 1;
                lblAmbientacion.Content = "Ambientación (opcional)";

                chkMusica.IsEnabled = true;
                chkMusica.Opacity = 1;

                chkVegetariana.IsEnabled = false;
                chkVegetariana.IsChecked = false;
                chkVegetariana.Opacity = 0.5;

                cboLocal.IsEnabled = false;
                cboLocal.Opacity = 0.5;
                cboLocal.SelectedIndex = 0;
                lblAmbientacion.Content = "Ambientación";
            }

            else
            {
                cboAmbientacion.IsEnabled = true;
                cboAmbientacion.SelectedIndex = 0;
                cboAmbientacion.Opacity = 1;

                chkMusica.IsEnabled = true;
                chkMusica.Opacity = 1;

                cboLocal.IsEnabled = true;
                cboLocal.Opacity = 1;

                chkVegetariana.IsEnabled = false;
                chkVegetariana.IsChecked = false;
                chkVegetariana.Opacity = 0.5;
            }
        }
        #endregion

        #region popular datos
        //Metodo que se encarga de popular datos del contrato al buscar
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
                EnableEditButtons(true);
                EnableRegisterButton(false);
                EnableRut(false);
                EnableChangeTipoEvento(false);

                if(contrato.ModalidadServicio.TipoEvento.IdTipoEvento == 10)
                {
                    CoffeeBreak coffeeBreak = new CoffeeBreak().Read(contrato.Numero);
                    chkVegetariana.IsChecked = coffeeBreak.Vegetariana;
                }

                else if (contrato.ModalidadServicio.TipoEvento.IdTipoEvento == 20)
                {
                    Cocktail cocktail = new Cocktail().Read(contrato.Numero);
                    chkMusica.IsChecked = cocktail.MusicaAmbiental;
                    if(cocktail.TipoAmbientacion != null)
                    {
                        cboAmbientacion.SelectedValue = cocktail.TipoAmbientacion.Id;
                    }
                }

                else if (contrato.ModalidadServicio.TipoEvento.IdTipoEvento == 30)
                {
                    Cenas c = new Cenas().Read(contrato.Numero);
                    chkMusica.IsChecked = c.MusicaAmbiental;
                    cboAmbientacion.SelectedValue = c.TipoAmbientacion.Id;

                    if (c.LocalOnBreak)
                    {
                        cboLocal.SelectedIndex = 1;
                    }

                    else if (c.OtroLocalOnBreak)
                    {
                        cboLocal.SelectedIndex = 2;
                        txtMontoArriendo.Text = c.ValorArriendo.ToString();
                    }

                    else
                    {
                        cboLocal.SelectedIndex = 0;
                    }
                }

                // si el contrato es finalizado se bloquean la edicion
                if (contrato.Realizado == true)
                {
                    BlockEdits(true);
                }
            }
        }

        public void PopCbo()
        {
            TipoEvento tipoEvento = new TipoEvento();
            TipoAmbientacion tipoAmbientacion = new TipoAmbientacion();

            cboTipoEvento.ItemsSource = tipoEvento.ReadAll();
            cboTipoEvento.DisplayMemberPath = "Descripcion";
            cboTipoEvento.SelectedValuePath = "IdTipoEvento";
            cboTipoEvento.SelectedIndex = 0;

            cboAmbientacion.ItemsSource = tipoAmbientacion.ReadAll();
            cboAmbientacion.DisplayMemberPath = "Desc";
            cboAmbientacion.SelectedValuePath = "Id";
            cboAmbientacion.SelectedIndex = -1;

            cboLocal.ItemsSource = Enum.GetValues(typeof(Locales));
            cboLocal.SelectedIndex = 0;
        }
        #endregion    

        #region metodos que performan una accion
        // limpiar todos los campos
        private void LimpiarCampos()
        {
            lblNumContrato.Content = string.Empty;
            txtRut.Text = string.Empty;
            dpFechaInicio.SelectedDateTime = null;
            dpFechaTermino.SelectedDateTime = null;
            cboTipoEvento.SelectedIndex = 0;
            cboModalidad.SelectedIndex = 0;
            txtCantAsist.Text = string.Empty;
            txtCantPersonal.Text = string.Empty;
            chkVegetariana.IsChecked = false;
            chkMusica.IsChecked = false;
            cboAmbientacion.SelectedIndex = -1;
            txtMontoArriendo.Text = "0";
            txtObservaciones.Text = string.Empty;
            chkRealizado.IsChecked = false;
            lblMonto.Content = "0";
            EnableRut(true);
            EnableEditButtons(false);
            BlockEdits(false);
            btnRegistrarContrato.IsEnabled = true;
            btnRegistrarContrato.Opacity = 1;
            EnableChangeTipoEvento(true);
        }

        // calcular monto en UF al escribir cantidad de asistentes/personal
        private void CalcularMonto()
        {
            double monto = 0;

            if (txtCantAsist.Text == string.Empty ||
                txtCantPersonal.Text == string.Empty ||
                cboModalidad.SelectedValue == null ||
                cboTipoEvento.SelectedValue == null ||
                InvalidEntry())
            {
                lblMonto.Content = monto;
                return;
            }

            if (cboTipoEvento.SelectedValue.ToString() == "10")
            {
                CoffeeBreak coffeeBreak = new CoffeeBreak()
                {
                    Contrato = new Contrato()
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
                    }
                };
                monto = coffeeBreak.CalcularValorEvento();
                lblMonto.Content = monto;
            }

            else if (cboTipoEvento.SelectedValue.ToString() == "20")
            {
                if(cboAmbientacion.SelectedValue == null)
                {
                    Cocktail cocktail = new Cocktail()
                    {
                        MusicaAmbiental = chkMusica.IsChecked.Value,
                        MusicaCliente = !(chkMusica.IsChecked.Value),
                        Contrato = new Contrato()
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
                        }
                    };
                    CocktailDecorator decorator = new CocktailDecorator(cocktail)
                    {
                        MusicaAmbiental = cocktail.MusicaAmbiental
                    };
                    monto = decorator.CalcularValorEvento();
                    lblMonto.Content = monto;
                }

                else
                {
                    Cocktail cocktail = new Cocktail()
                    {
                        TipoAmbientacion = new TipoAmbientacion()
                        {
                            Id = int.Parse(cboAmbientacion.SelectedValue.ToString())
                        },
                        MusicaAmbiental = chkMusica.IsChecked.Value,
                        Contrato = new Contrato()
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
                        }
                    };
                    CocktailDecorator decorator = new CocktailDecorator(cocktail)
                    {
                        Ambientacion = cocktail.TipoAmbientacion.Id,
                        MusicaAmbiental = cocktail.MusicaAmbiental
                    };
                    monto = decorator.CalcularValorEvento();
                    lblMonto.Content = monto;
                }
            }

            else if (cboTipoEvento.SelectedValue.ToString() == "30" &&
                cboAmbientacion.SelectedValue != null)
            {
                Cenas cenas = new Cenas()
                {
                    LocalOnBreak = LocalOnBreak(),
                    OtroLocalOnBreak = ArrendarLocal(),
                    ValorArriendo = double.Parse(txtMontoArriendo.Text),
                    MusicaAmbiental = chkMusica.IsChecked.Value,
                    TipoAmbientacion = new TipoAmbientacion()
                    {
                        Id = int.Parse(cboAmbientacion.SelectedValue.ToString())
                    },
                    Contrato = new Contrato()
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
                    }
                };

                CenasDecorator decorator = new CenasDecorator(cenas)
                {
                    Ambientacion = cenas.TipoAmbientacion.Id,
                    MusicaAmbiental = cenas.MusicaAmbiental,
                    LocalOnBreak = cenas.LocalOnBreak,
                    ArriendoOtroLocal = cenas.ValorArriendo
                };
                monto = decorator.CalcularValorEvento();
                lblMonto.Content = monto;
            }                    
        }

        // METODOS BOOL PARA REVISAR ESTADO DEL LOCAL
        private bool LocalOnBreak()
        {
            bool localOnbreak;
            if (cboLocal.SelectedIndex == 1)
            {
                localOnbreak = true;
            }
            else
            {
                localOnbreak = false;
            }
            return localOnbreak;
        }

        private bool ArrendarLocal()
        {
            bool arrendarLocal;
            if (cboLocal.SelectedIndex == 2)
            {
                arrendarLocal = true;
            }
            else
            {
                arrendarLocal = false;
            }
            return arrendarLocal;
        }

        // metodo que trae el parentWindow del currentPage para mostrar metro dialogue
        private async Task MetroDialogue(string title, string message)
        {
            await this.TryFindParent<MetroWindow>()
                                .ShowMessageAsync(title, message);
        }
        #endregion

        #region DETECCION DE CAMBIOS
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

        private void CalcularMonto_KeyUp(object sender, KeyEventArgs e)
        {
            CalcularMonto();
        }

        private void CalcularMonto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalcularMonto();
        }

        private void ChkMusica_Checked(object sender, RoutedEventArgs e)
        {
            CalcularMonto();
        }

        private void ChkMusica_Unchecked(object sender, RoutedEventArgs e)
        {
            CalcularMonto();
        }

        private void CboLocal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboLocal.SelectedIndex == 2)
            {
                txtMontoArriendo.IsEnabled = true;
                txtMontoArriendo.Opacity = 1;
                txtMontoArriendo.Text = string.Empty;
            }
            else
            {
                txtMontoArriendo.IsEnabled = false;
                txtMontoArriendo.Opacity = 0.5;
                txtMontoArriendo.Text = "0";
            }

            CalcularMonto();
        }

        private void Backup_LostFocus(object sender, RoutedEventArgs e)
        {
            Backup();
        }

        #endregion


    }
}