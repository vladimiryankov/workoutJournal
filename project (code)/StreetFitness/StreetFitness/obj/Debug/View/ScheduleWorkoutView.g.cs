﻿#pragma checksum "C:\Users\Vladimir\Documents\Visual Studio 2013\Projects\StreetFitness\StreetFitness\View\ScheduleWorkoutView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2734BDA398236C5974208AAF35C3CA4D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace StreetFitness.View {
    
    
    public partial class ScheduleWorkoutView : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal Microsoft.Phone.Controls.TimePicker startTimePicker;
        
        internal Microsoft.Phone.Controls.TimePicker endTimePicker;
        
        internal Microsoft.Phone.Controls.ListPicker listWorkouts;
        
        internal System.Windows.Controls.TextBox locationBox;
        
        internal System.Windows.Controls.TextBox detailsBox;
        
        internal System.Windows.Controls.Button scheduleWorkout;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/StreetFitness;component/View/ScheduleWorkoutView.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.startTimePicker = ((Microsoft.Phone.Controls.TimePicker)(this.FindName("startTimePicker")));
            this.endTimePicker = ((Microsoft.Phone.Controls.TimePicker)(this.FindName("endTimePicker")));
            this.listWorkouts = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("listWorkouts")));
            this.locationBox = ((System.Windows.Controls.TextBox)(this.FindName("locationBox")));
            this.detailsBox = ((System.Windows.Controls.TextBox)(this.FindName("detailsBox")));
            this.scheduleWorkout = ((System.Windows.Controls.Button)(this.FindName("scheduleWorkout")));
        }
    }
}
