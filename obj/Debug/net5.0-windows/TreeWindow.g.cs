﻿#pragma checksum "..\..\..\TreeWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "34226E92B0A0A8B72EC0F9DC7CFA0D0698DA5087"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using WpfApp2;


namespace WpfApp2 {
    
    
    /// <summary>
    /// TreeWindow
    /// </summary>
    public partial class TreeWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\TreeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonCreate;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\TreeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox buttonR;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\TreeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox buttonL;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.15.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfApp2;component/treewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\TreeWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.15.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\..\TreeWindow.xaml"
            ((System.Windows.Controls.ComboBox)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SelectionChanged_Deep);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 25 "..\..\..\TreeWindow.xaml"
            ((System.Windows.Controls.ComboBox)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SelectionChanged_Coef);
            
            #line default
            #line hidden
            return;
            case 3:
            this.buttonCreate = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\TreeWindow.xaml"
            this.buttonCreate.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.buttonR = ((System.Windows.Controls.TextBox)(target));
            
            #line 36 "..\..\..\TreeWindow.xaml"
            this.buttonR.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.OnPreviewTextInput);
            
            #line default
            #line hidden
            
            #line 36 "..\..\..\TreeWindow.xaml"
            this.buttonR.AddHandler(System.Windows.DataObject.PastingEvent, new System.Windows.DataObjectPastingEventHandler(this.OnPasting));
            
            #line default
            #line hidden
            return;
            case 5:
            this.buttonL = ((System.Windows.Controls.TextBox)(target));
            
            #line 37 "..\..\..\TreeWindow.xaml"
            this.buttonL.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.OnPreviewTextInput);
            
            #line default
            #line hidden
            
            #line 37 "..\..\..\TreeWindow.xaml"
            this.buttonL.AddHandler(System.Windows.DataObject.PastingEvent, new System.Windows.DataObjectPastingEventHandler(this.OnPasting));
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

