﻿#pragma checksum "..\..\..\Pages\PageRegister.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "616A3272873990CD6D2D518AFA7564ECEAFECC87B221C54FAD538E4396B3ABE0"
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
    /// PageRegister
    /// </summary>
    public partial class PageRegister : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 42 "..\..\..\Pages\PageRegister.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgLogo;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\Pages\PageRegister.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRegisterUser;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\Pages\PageRegister.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox passRegister;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\Pages\PageRegister.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRegistrarse;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\Pages\PageRegister.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLogin;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\Pages\PageRegister.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button closeWindow;
        
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
            System.Uri resourceLocater = new System.Uri("/OnBreakApp;component/pages/pageregister.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\PageRegister.xaml"
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
            this.imgLogo = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.txtRegisterUser = ((System.Windows.Controls.TextBox)(target));
            
            #line 48 "..\..\..\Pages\PageRegister.xaml"
            this.txtRegisterUser.GotFocus += new System.Windows.RoutedEventHandler(this.TxtRegisterUser_Focus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.passRegister = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 57 "..\..\..\Pages\PageRegister.xaml"
            this.passRegister.GotFocus += new System.Windows.RoutedEventHandler(this.PassRegister_Focus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnRegistrarse = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\..\Pages\PageRegister.xaml"
            this.btnRegistrarse.Click += new System.Windows.RoutedEventHandler(this.BtnRegister_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnLogin = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\..\Pages\PageRegister.xaml"
            this.btnLogin.Click += new System.Windows.RoutedEventHandler(this.BtnLogin_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.closeWindow = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\..\Pages\PageRegister.xaml"
            this.closeWindow.Click += new System.Windows.RoutedEventHandler(this.closeWindow_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

