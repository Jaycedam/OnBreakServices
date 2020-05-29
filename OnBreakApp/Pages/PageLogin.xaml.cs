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
    /// Interaction logic for PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            // Recuperar Parentwindow
            Window parentWindow = Window.GetWindow(this);
            // Abrir nuevo RegisterPage en ParentWindow
            parentWindow.Content = new PageRegister();
        }

        private void TxtLoginUser_Focus(object sender, RoutedEventArgs e)
        {
            txtLoginUser.Text = String.Empty;
        }

        private void PassLogin_Focus(object sender, RoutedEventArgs e)
        {
            passLogin.Password = String.Empty;
        }

        private async Task MetroDialogue(string title, string message)
        {
            await this.TryFindParent<MetroWindow>()
                                .ShowMessageAsync(title, message);
        }

        private async void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Validacion de entrada de usuario
            if (txtLoginUser.Text == "Usuario" ||
                txtLoginUser.Text == String.Empty ||
                passLogin.Password == String.Empty ||
                passLogin.Password == "Password")
            {
                await MetroDialogue("Iniciar sesión",
                    "Debes ingresar un usuario y contraseña");
                return;
            }
            else
            {
                Usuario usuario = new Usuario()
                {
                    User = txtLoginUser.Text,
                    Password = passLogin.Password
                };
                if (usuario.Login(usuario))
                {
                    await MetroDialogue("Iniciar sesión",
                        "Inicio de sesión exitoso");
                    string user = txtLoginUser.Text;
                    MainWindow mw = new MainWindow(user);
                    // Recuperar Window desde ParentWindow
                    Window parentWindow = Window.GetWindow(this);
                    // Cerrar ParentWindow
                    parentWindow.Close();
                    // Mostrar nueva ventana principal
                    mw.Show();
                }
                else
                {
                    await MetroDialogue("Iniciar sesión",
                        "Usuario o contraseña incorrectos");
                }
            }
        }
    }
}
