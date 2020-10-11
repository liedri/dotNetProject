﻿#pragma checksum "..\..\Host.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "10813FF0468F5D065EAD9D4C113CE1BCBC54AECC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PLWPF;
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


namespace PLWPF {
    
    
    /// <summary>
    /// Host
    /// </summary>
    public partial class Host : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\Host.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid HostGrid;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Host.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView HostingUnitsList;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\Host.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ShowHostingUnit;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\Host.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Update;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\Host.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button HostingUnit;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\Host.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox HostKey;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\Host.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Name;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\Host.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LastName;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\Host.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PhoneNumber;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\Host.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Email;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\Host.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BankBrachBox;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\Host.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BankNunberBox;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\Host.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CollectionclearanceBox;
        
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
            System.Uri resourceLocater = new System.Uri("/PLWPF;component/host.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Host.xaml"
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
            this.HostGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.HostingUnitsList = ((System.Windows.Controls.ListView)(target));
            
            #line 25 "..\..\Host.xaml"
            this.HostingUnitsList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.HostingUnitsList_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ShowHostingUnit = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\Host.xaml"
            this.ShowHostingUnit.Click += new System.Windows.RoutedEventHandler(this.ShowHostingUnit_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Update = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\Host.xaml"
            this.Update.Click += new System.Windows.RoutedEventHandler(this.UpdateHost_Button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.HostingUnit = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\Host.xaml"
            this.HostingUnit.Click += new System.Windows.RoutedEventHandler(this.HostingUnit_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.HostKey = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.LastName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.PhoneNumber = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.Email = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.BankBrachBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.BankNunberBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.CollectionclearanceBox = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

