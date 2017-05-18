using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO;
using System.Windows.Resources;

namespace StreetFitness.View
{
    public partial class AboutPage : PhoneApplicationPage
    {
        string text;
        public AboutPage()
        {
            InitializeComponent();

            Stream info = Application.GetResourceStream(new Uri("Resources/about.txt", UriKind.Relative)).Stream;
            StreamReader reader = new StreamReader(info);
            using (reader)
            {
                text = reader.ReadToEnd();
            }

            AboutTextBlock.Text = text;
        }
    }
}