﻿#pragma checksum "..\..\..\Pages\PageListadoClientes.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "45C5AD9A82B503AAA69762CE5193E1F27FE1DF944251376B39C311104B873F3C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.IconPacks;
using MahApps.Metro.IconPacks.Converter;
using OnBreakApp.Pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace OnBreakApp.Pages {
    
    
    /// <summary>
    /// PageListadoClientes
    /// </summary>
    public partial class PageListadoClientes : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 52 "..\..\..\Pages\PageListadoClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLimpiarFiltros;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\Pages\PageListadoClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblFiltrarRut;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\Pages\PageListadoClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRut;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\Pages\PageListadoClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblFiltrarTipo;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\Pages\PageListadoClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboTipoEmpresa;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\Pages\PageListadoClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblFiltrarAct;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\Pages\PageListadoClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboActividadEmpresa;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\Pages\PageListadoClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgClientes;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\Pages\PageListadoClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnVerInfoCliente;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\Pages\PageListadoClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnVerContratosCliente;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/OnBreakApp;component/pages/pagelistadoclientes.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\PageListadoClientes.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btnLimpiarFiltros = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\Pages\PageListadoClientes.xaml"
            this.btnLimpiarFiltros.Click += new System.Windows.RoutedEventHandler(this.BtnLimpiarFiltros_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lblFiltrarRut = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.txtRut = ((System.Windows.Controls.TextBox)(target));
            
            #line 70 "..\..\..\Pages\PageListadoClientes.xaml"
            this.txtRut.KeyUp += new System.Windows.Input.KeyEventHandler(this.TxtRut_KeyUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lblFiltrarTipo = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.cboTipoEmpresa = ((System.Windows.Controls.ComboBox)(target));
            
            #line 78 "..\..\..\Pages\PageListadoClientes.xaml"
            this.cboTipoEmpresa.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CboTipoEmpresa_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.lblFiltrarAct = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.cboActividadEmpresa = ((System.Windows.Controls.ComboBox)(target));
            
            #line 85 "..\..\..\Pages\PageListadoClientes.xaml"
            this.cboActividadEmpresa.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CboActividadEmpresa_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.dgClientes = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 9:
            this.btnVerInfoCliente = ((System.Windows.Controls.Button)(target));
            
            #line 104 "..\..\..\Pages\PageListadoClientes.xaml"
            this.btnVerInfoCliente.Click += new System.Windows.RoutedEventHandler(this.BtnVerCliente);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnVerContratosCliente = ((System.Windows.Controls.Button)(target));
            
            #line 111 "..\..\..\Pages\PageListadoClientes.xaml"
            this.btnVerContratosCliente.Click += new System.Windows.RoutedEventHandler(this.BtnVerContratosCliente_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
