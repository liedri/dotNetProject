﻿#pragma checksum "..\..\DeleteHostingUnit.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7D92EB7E8035B8511D1A578C76269557F6F7BF1E"
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
    /// DeleteHostingUnit
    /// </summary>
    public partial class DeleteHostingUnit : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\DeleteHostingUnit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid DeleteHostingUnitGrid;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\DeleteHostingUnit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox HostingUnitKey;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\DeleteHostingUnit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox HostId;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\DeleteHostingUnit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Name;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\DeleteHostingUnit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Area;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\DeleteHostingUnit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Type;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\DeleteHostingUnit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Pool;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\DeleteHostingUnit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Jacuzzi;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\DeleteHostingUnit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Porch;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\DeleteHostingUnit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Food;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\DeleteHostingUnit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ChildrenAttractions;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\DeleteHostingUnit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Beds;
        
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
            System.Uri resourceLocater = new System.Uri("/PLWPF;component/deletehostingunit.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\DeleteHostingUnit.xaml"
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
            this.DeleteHostingUnitGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.HostingUnitKey = ((System.Windows.Controls.ComboBox)(target));
            
            #line 28 "..\..\DeleteHostingUnit.xaml"
            this.HostingUnitKey.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 29 "..\..\DeleteHostingUnit.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.HostId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Area = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Type = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.Pool = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.Jacuzzi = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.Porch = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.Food = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.ChildrenAttractions = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.Beds = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
