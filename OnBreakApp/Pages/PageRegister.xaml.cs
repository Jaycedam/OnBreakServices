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
    /// Interaction logic for PageRegister.xaml
    /// </summary>
    public partial class PageRegister : Page
    {
        public PageRegister()
        {
            InitializeComponent();
        }

        private async void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario()
                {
                    User = txtRegisterUser.Text,
                    Password = passRegister.Password
                };
                if (usuario.Register(usuario))
                {
                    await MetroDialogue("Registrar usuario",
                        "Usuario registrado correctamente");
                }
                else
                {
                    await MetroDialogue("Registrar usuario",
                        "Este nombre de usuario ya existe");
                }
            }
            catch (Exception x)
            {
                await MetroDialogue("Registrar usuario", x.Message);
            }
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Recuperar Parentwindow
            Window parentWindow = Window.GetWindow(this);
            // Abrir nuevo LoginPage en ParentWindow
            parentWindow.Content = new PageLogin();
        }

        // Dejar vacio textbox de usuario al hacer click
        private void TxtRegisterUser_Focus(object sender, RoutedEventArgs e)
        {
            txtRegisterUser.Text = String.Empty;
        }

        // Dejar vacio password al hacer click
        private void PassRegister_Focus(object sender, RoutedEventArgs e)
        {
            passRegister.Password = String.Empty;
        }

        private async Task MetroDialogue(string title, string message)
        {
            await this.TryFindParent<MetroWindow>()
                                .ShowMessageAsync(title, message);
        }

        private void closeWindow_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
