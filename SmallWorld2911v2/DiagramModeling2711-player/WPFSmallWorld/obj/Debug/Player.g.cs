﻿#pragma checksum "..\..\Player.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "70BF6A3FEDA51E5FECFF02B6A39BA171"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.34014
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace WPFSmallWorld {
    
    
    /// <summary>
    /// Player
    /// </summary>
    public partial class Player : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\Player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Textplayer1;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Textplayer2;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton SMALL;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton DEMO;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton NORMAL;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton ELF;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton NAIN;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton ORC;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton ELF2;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\Player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton NAIN2;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton ORC2;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\Player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox Ok1;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\Player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox Ok2;
        
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
            System.Uri resourceLocater = new System.Uri("/WPFSmallWorld;component/player.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Player.xaml"
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
            
            #line 9 "..\..\Player.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.startGame);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Textplayer1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Textplayer2 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.SMALL = ((System.Windows.Controls.RadioButton)(target));
            
            #line 18 "..\..\Player.xaml"
            this.SMALL.Checked += new System.Windows.RoutedEventHandler(this.selectMapStrategy);
            
            #line default
            #line hidden
            return;
            case 5:
            this.DEMO = ((System.Windows.Controls.RadioButton)(target));
            
            #line 19 "..\..\Player.xaml"
            this.DEMO.Checked += new System.Windows.RoutedEventHandler(this.selectMapStrategy);
            
            #line default
            #line hidden
            return;
            case 6:
            this.NORMAL = ((System.Windows.Controls.RadioButton)(target));
            
            #line 20 "..\..\Player.xaml"
            this.NORMAL.Checked += new System.Windows.RoutedEventHandler(this.selectMapStrategy);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ELF = ((System.Windows.Controls.RadioButton)(target));
            
            #line 23 "..\..\Player.xaml"
            this.ELF.Checked += new System.Windows.RoutedEventHandler(this.initPeoplePlayer1);
            
            #line default
            #line hidden
            return;
            case 8:
            this.NAIN = ((System.Windows.Controls.RadioButton)(target));
            
            #line 24 "..\..\Player.xaml"
            this.NAIN.Checked += new System.Windows.RoutedEventHandler(this.initPeoplePlayer1);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ORC = ((System.Windows.Controls.RadioButton)(target));
            
            #line 25 "..\..\Player.xaml"
            this.ORC.Checked += new System.Windows.RoutedEventHandler(this.initPeoplePlayer1);
            
            #line default
            #line hidden
            return;
            case 10:
            this.ELF2 = ((System.Windows.Controls.RadioButton)(target));
            
            #line 26 "..\..\Player.xaml"
            this.ELF2.Checked += new System.Windows.RoutedEventHandler(this.initPeoplePlayer2);
            
            #line default
            #line hidden
            return;
            case 11:
            this.NAIN2 = ((System.Windows.Controls.RadioButton)(target));
            
            #line 27 "..\..\Player.xaml"
            this.NAIN2.Checked += new System.Windows.RoutedEventHandler(this.initPeoplePlayer2);
            
            #line default
            #line hidden
            return;
            case 12:
            this.ORC2 = ((System.Windows.Controls.RadioButton)(target));
            
            #line 28 "..\..\Player.xaml"
            this.ORC2.Checked += new System.Windows.RoutedEventHandler(this.initPeoplePlayer2);
            
            #line default
            #line hidden
            return;
            case 13:
            this.Ok1 = ((System.Windows.Controls.CheckBox)(target));
            
            #line 29 "..\..\Player.xaml"
            this.Ok1.Checked += new System.Windows.RoutedEventHandler(this.copyInfo1);
            
            #line default
            #line hidden
            return;
            case 14:
            this.Ok2 = ((System.Windows.Controls.CheckBox)(target));
            
            #line 30 "..\..\Player.xaml"
            this.Ok2.Checked += new System.Windows.RoutedEventHandler(this.copyInfo2);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
