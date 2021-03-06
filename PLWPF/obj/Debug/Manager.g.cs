﻿#pragma checksum "..\..\Manager.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "55699BA9C8DCBCEA536B7CC17EEBCF353744AB65"
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
    /// Manager
    /// </summary>
    public partial class Manager : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\Manager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView GuestRequests;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\Manager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView Hosts;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\Manager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView HostingUnits;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\Manager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView Orders;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\Manager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Commissions;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\Manager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GuestRequestByArea;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\Manager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GuestRequestByNumOfGuests;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\Manager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button HostsByNumOfHostingUnits;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\Manager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button HostingUnitsByArea;
        
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
            System.Uri resourceLocater = new System.Uri("/PLWPF;component/manager.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Manager.xaml"
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
            this.GuestRequests = ((System.Windows.Controls.ListView)(target));
            return;
            case 2:
            this.Hosts = ((System.Windows.Controls.ListView)(target));
            return;
            case 3:
            this.HostingUnits = ((System.Windows.Controls.ListView)(target));
            return;
            case 4:
            this.Orders = ((System.Windows.Controls.ListView)(target));
            return;
            case 5:
            this.Commissions = ((System.Windows.Controls.Button)(target));
            
            #line 102 "..\..\Manager.xaml"
            this.Commissions.Click += new System.Windows.RoutedEventHandler(this.Commissions_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.GuestRequestByArea = ((System.Windows.Controls.Button)(target));
            
            #line 108 "..\..\Manager.xaml"
            this.GuestRequestByArea.Click += new System.Windows.RoutedEventHandler(this.GuestRequestByArea_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.GuestRequestByNumOfGuests = ((System.Windows.Controls.Button)(target));
            
            #line 109 "..\..\Manager.xaml"
            this.GuestRequestByNumOfGuests.Click += new System.Windows.RoutedEventHandler(this.GuestRequestByNumOfGuests_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.HostsByNumOfHostingUnits = ((System.Windows.Controls.Button)(target));
            
            #line 110 "..\..\Manager.xaml"
            this.HostsByNumOfHostingUnits.Click += new System.Windows.RoutedEventHandler(this.HostsByNumOfHostingUnits_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.HostingUnitsByArea = ((System.Windows.Controls.Button)(target));
            
            #line 111 "..\..\Manager.xaml"
            this.HostingUnitsByArea.Click += new System.Windows.RoutedEventHandler(this.HostingUnitsByArea_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

