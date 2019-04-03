﻿#pragma checksum "..\..\AddTransaction.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2D7DABF096D2276003DC487AED8843AEC10E3CD4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
using OOP_Project;
using OOP_Project.BindingProxy_Class;
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


namespace OOP_Project {
    
    
    /// <summary>
    /// AddTransaction
    /// </summary>
    public partial class AddTransaction : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 105 "..\..\AddTransaction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbCustomer;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\AddTransaction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbJewelryType;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\AddTransaction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtWeight;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\AddTransaction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtQuantityBlock;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\AddTransaction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpPromisedDate;
        
        #line default
        #line hidden
        
        
        #line 148 "..\..\AddTransaction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtJewelryCondition;
        
        #line default
        #line hidden
        
        
        #line 154 "..\..\AddTransaction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbJewelryQuality;
        
        #line default
        #line hidden
        
        
        #line 162 "..\..\AddTransaction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbDiscount;
        
        #line default
        #line hidden
        
        
        #line 172 "..\..\AddTransaction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbInterest;
        
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
            System.Uri resourceLocater = new System.Uri("/OOP_Project;component/addtransaction.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddTransaction.xaml"
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
            
            #line 16 "..\..\AddTransaction.xaml"
            ((OOP_Project.AddTransaction)(target)).Activated += new System.EventHandler(this.AddTransactionWindow_Activated);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cmbCustomer = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            
            #line 111 "..\..\AddTransaction.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnAddCustomer_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cmbJewelryType = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.txtWeight = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtQuantityBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.dpPromisedDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 8:
            
            #line 142 "..\..\AddTransaction.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnAddTransaction_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.txtJewelryCondition = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.cmbJewelryQuality = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.cmbDiscount = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 12:
            this.cmbInterest = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

