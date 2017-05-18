using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace StreetFitness.View
{
    public partial class SettingsView : PhoneApplicationPage
    {
        private bool? toggled = false;
        public bool? Toggled
        {
            get { return toggled; }
            set { toggled = value; }
        }
        public SettingsView()
        {
            InitializeComponent();
            toggleSwitch.DataContext = Toggled;
        }

        private void toggleSwitch_Checked(object sender, RoutedEventArgs e)
        {
            PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;
            Toggled = true;
        }

        private void toggleSwitch_Unchecked(object sender, RoutedEventArgs e)
        {
            PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Enabled;
            Toggled = false;
        }
    }
}