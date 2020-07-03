using ControlzEx.Theming;
using MahApps.Metro.Controls;
using OnBreakApp.Pages;
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

namespace OnBreakApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            // Metodo colapsar menus al inicio
            HideSubmenu();
            // Iniciar pagina bienvenido
            MainFrame.Navigate(new PageInicio());
        }

        public MainWindow(string user)
        {
            InitializeComponent();
            lblCurrentUser.Content = user;
            // Metodo colapsar menus al inicio
            HideSubmenu();
            // Iniciar pagina bienvenido
            MainFrame.Navigate(new PageInicio());
        }

        #region submenu
        // metodo para esconder menu
        private void HideSubmenu()
        {
            panelClienteSubmenu.Visibility = Visibility.Collapsed;
            panelContratosSubmenu.Visibility = Visibility.Collapsed;
        }

        // Metodo para mostrar/colapsar menu al presionar botones de menu
        private void ShowSubmenu(StackPanel subMenu)
        {
            // si el menu está colapsado, expandir
            if (subMenu.Visibility == Visibility.Collapsed)
            {
                subMenu.Visibility = Visibility.Visible;
            }
            // si el menu no está colapsado, colapsar
            else
            {
                subMenu.Visibility = Visibility.Collapsed;
            }
        }
        #endregion

        #region botones
        // Iniciar para mostrar/colapsar menu al presionar "Clientes"
        private void BtnClientes_Click(object sender, RoutedEventArgs e)
        {
            ShowSubmenu(panelClienteSubmenu);
        }

        // Iniciar para mostrar/colapsar menu al presionar "Contratos"
        private void BtnContratos_Click(object sender, RoutedEventArgs e)
        {
            ShowSubmenu(panelContratosSubmenu);
        }

        // Asignar content page bienvenido al presionar boton del menu
        private void BtnPaginaPrincipal_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PageInicio());
        }

        // Asignar content page buscarcliente al presionar boton del menu
        private void BtnAdministrarClientes(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PageAdminClientes());
        }

        // Asignar content page listadoclientes al presionar boton del menu
        private void BtnListadoClientes_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PageListadoClientes());
        }

        // Asignar content page registrarcontrato al presionar boton del menu
        private void BtnAdministrarContratos(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PageAdminContratos());
        }

        // Asignar content page listadocontratos al presionar boton del menu
        private void BtnListadoContratos_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PageListadoContratos());
        }

        private void BtnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow lw = new LoginWindow();
            this.Close();
            lw.Show();
        }
        #endregion

        //Permitir arrastrado en barra superior
        private void BorderTop_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
