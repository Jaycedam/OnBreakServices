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
    /// Interaction logic for PageAdminClientes.xaml
    /// </summary>
    public partial class PageAdminClientes : Page
    {
        public PageAdminClientes()
        {
            InitializeComponent();
            PopCbo();
        }

        // Init con constructor para usarse como módulo desde listados
        public PageAdminClientes(string rut)
        {
            InitializeComponent();
            PopCbo();
            Cliente cliente = new Cliente().Read(rut);
            DataCliente(cliente);
        }

        #region botones CRUD
        private async void BtnRegistrarCliente_Click(object sender, RoutedEventArgs e)
        {
            if (FaltanCamposObligatorios())
            {
                await MetroDialogue("Registrar cliente",
                    "Debes ingresar todos los datos obligatorios");
                return;
            }
            else if (InvalidEntry())
            {
                await MetroDialogue("Registrar cliente",
                    "Ingresa sólo números en Teléfono");
                return;
            }

            Cliente cliente = new Cliente()
            {
                RutCliente = txtRut.Text.ToUpper().Trim(),
                RazonSocial = txtRazonSocial.Text.ToUpper(),
                NombreContacto = txtNombre.Text.ToUpper(),
                MailContacto = txtMailContacto.Text.ToUpper().Trim(),
                Direccion = txtDireccion.Text.ToUpper(),
                Telefono = txtTelefono.Text,
                ActividadEmpresa = new ActividadEmpresa()
                {
                    IdActividadEmpresa = int.Parse(cboActividadEmpresa.SelectedValue.ToString()),
                },
                TipoEmpresa = new TipoEmpresa()
                {
                    IdTipoEmpresa = int.Parse(cboTipoEmpresa.SelectedValue.ToString())
                }
            };
            if (cliente.Create(cliente))
            {
                await MetroDialogue("Registrar cliente",
                "Cliente registrado correctamente");
                return;
            }
            else
            {
                await MetroDialogue("Registrar cliente",
                                "Este cliente ya existe");
            }
        }

        private async void BtnBuscarCliente_Click(object sender, RoutedEventArgs e)
        {
            // missing: codigo que busca cliente desde txtrutin
            if (txtBuscarRut.Text == String.Empty)
            {
                await MetroDialogue("Buscar cliente",
                    "Debes ingresar el rut del cliente");
            }
            else
            {
                string rut = txtBuscarRut.Text.ToUpper().Trim();
                Cliente cliente = new Cliente().Read(rut);
                DataCliente(cliente);
            }
        }

        private async void BtnModificarCliente_Click(object sender, RoutedEventArgs e)
        {
            if (FaltanCamposObligatorios())
            {
                await MetroDialogue("Modificar cliente",
                    "Debes ingresar todos los campos obligatorios");
                return;
            }
            else if (InvalidEntry())
            {
                await MetroDialogue("Modificar cliente",
                    "Ingresa sólo números en Teléfono");
                return;
            }

            Cliente cliente = new Cliente()
            {
                RutCliente = txtRut.Text.ToUpper().Trim(),
                RazonSocial = txtRazonSocial.Text.ToUpper(),
                NombreContacto = txtNombre.Text.ToUpper(),
                MailContacto = txtMailContacto.Text.ToUpper().Trim(),
                Direccion = txtDireccion.Text.ToUpper(),
                Telefono = txtTelefono.Text,
                ActividadEmpresa = new ActividadEmpresa()
                {
                    IdActividadEmpresa = int.Parse(cboActividadEmpresa.SelectedValue.ToString())
                },
                TipoEmpresa = new TipoEmpresa()
                {
                    IdTipoEmpresa = int.Parse(cboTipoEmpresa.SelectedValue.ToString())
                }
            };

            if (cliente.Update(cliente))
            {
                await MetroDialogue("Modificar cliente",
                    "Cliente modificado correctamente");
            }
            else
            {
                await MetroDialogue("Modificar cliente",
                    "No se ha encontrado el rut ingresado");
            }


        }

        private async void BtnEliminarCliente_Click(object sender, RoutedEventArgs e)
        {
            //missing: codigo eliminar cliente lista
            if (FaltaRut())
            {
                await MetroDialogue("Eliminar cliente",
                    "Debes ingresar el rut del cliente");
                return;
            }

            var result = await this.TryFindParent<MetroWindow>()
                                .ShowMessageAsync("Eliminar cliente",
                                "¿Estás seguro que deseas eliminar este cliente? Esta acción es permanente",
                                MessageDialogStyle.AffirmativeAndNegative);

            if (result == MessageDialogResult.Affirmative)
            {
                Cliente cliente = new Cliente();
                Contrato contrato = new Contrato();

                if (contrato.ContratosAsociados(txtRut.Text.ToUpper().Trim()))
                {
                    await MetroDialogue("Eliminar cliente",
                        "No se puede eliminar un cliente con contratos asociados");
                    return;
                }

                else if (cliente.Delete(txtRut.Text.ToUpper().Trim()))
                {
                    await MetroDialogue("Eliminar cliente",
                        "Cliente eliminado correctamente");
                    LimpiarCampos();
                }
                else
                {
                    await MetroDialogue("Eliminar cliente",
                        "No se ha encontrado el rut ingresado");
                }
            }
        }
        #endregion

        #region popular datos
        //Metodo que se encarga de popular datos del cliente al buscar
        //entrega notificación si no es encontrado
        private async void DataCliente(Cliente cliente)
        {
            if (cliente == null)
            {
                await MetroDialogue("Buscar cliente",
                "Cliente no encontrado");
            }
            else
            {
                txtRut.Text = cliente.RutCliente;
                txtRazonSocial.Text = cliente.RazonSocial;
                txtNombre.Text = cliente.NombreContacto;
                txtMailContacto.Text = cliente.MailContacto;
                txtDireccion.Text = cliente.Direccion;
                txtTelefono.Text = cliente.Telefono;
                cboTipoEmpresa.SelectedValue = cliente.TipoEmpresa.IdTipoEmpresa;
                cboActividadEmpresa.SelectedValue = cliente.ActividadEmpresa.IdActividadEmpresa;
                // bloquear edición de rut al buscar cliente
                EnableButtons(true);
                EnableRut(false);
            }
        }

        // Llena los datos de los combobox
        public void PopCbo()
        {
            TipoEmpresa tipoEmpresa = new TipoEmpresa();
            ActividadEmpresa actividadEmpresa = new ActividadEmpresa();
            cboTipoEmpresa.ItemsSource = tipoEmpresa.ReadAll();
            cboTipoEmpresa.DisplayMemberPath = "Descripcion";
            cboTipoEmpresa.SelectedValuePath = "IdTipoEmpresa";
            cboTipoEmpresa.SelectedIndex = 0;
            cboActividadEmpresa.ItemsSource = actividadEmpresa.ReadAll();
            cboActividadEmpresa.DisplayMemberPath = "Descripcion";
            cboActividadEmpresa.SelectedValuePath = "IdActividadEmpresa";
            cboActividadEmpresa.SelectedIndex = 0;
        }
        #endregion

        #region validaciones
        // metodo que entrega true cuando faltan datos obligatorios
        public bool FaltanCamposObligatorios()
        {
            if (txtRut.Text == string.Empty ||
                txtRazonSocial.Text == string.Empty ||
                txtNombre.Text == string.Empty ||
                txtMailContacto.Text == string.Empty ||
                txtDireccion.Text == string.Empty ||
                txtTelefono.Text == string.Empty)
            {
                return true;
            }
            return false;
        }

        private bool InvalidEntry()
        {
            if (int.TryParse(txtTelefono.Text, out int fono) == false)
            {
                return true;
            }
            return false;
        }

        public bool FaltaRut()
        {
            if (txtRut.Text == string.Empty)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region metodos que performan una accion
        // limpiar todos los campos
        private void LimpiarCampos()
        {
            txtRut.Text = string.Empty;
            txtRazonSocial.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtMailContacto.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            cboTipoEmpresa.SelectedIndex = 0;
            cboActividadEmpresa.SelectedIndex = 0;
            // desbloquear edición de rut
            EnableRut(true);
            EnableButtons(false);
        }

        // metodo que habilita/deshabilita los botones de modificar/finalizar 
        private void EnableButtons(bool enable)
        {
            btnModificarCliente.IsEnabled = enable;
            btnEliminarCliente.IsEnabled = enable;
            if (btnModificarCliente.IsEnabled == false)
            {
                btnModificarCliente.Opacity = 0.5;
                btnEliminarCliente.Opacity = 0.5;
            }
            else
            {
                btnModificarCliente.Opacity = 1;
                btnEliminarCliente.Opacity = 1;
            }
        }

        public void EnableRut(bool enable)
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

        // metodo que trae el parentWindow del currentPage para mostrar metro dialogue
        private async Task MetroDialogue(string title, string message)
        {
            await this.TryFindParent<MetroWindow>()
                                .ShowMessageAsync(title, message);
        }
        #endregion

        #region otros botones
        private void LimpiarDatos_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();
        }
        #endregion


    }
}
