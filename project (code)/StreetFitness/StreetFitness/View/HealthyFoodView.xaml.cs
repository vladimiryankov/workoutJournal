using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using StreetFitness.Model;
using StreetFitness.Utils;

namespace StreetFitness.View
{
    public partial class HealthyFoodView : PhoneApplicationPage
    {
        private bool pageInitialized;
        public HealthyFoodView()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!pageInitialized)
            {
                int? entityID = NavigationContext.GetIntParam("id");
                HealthyFood entity = App.HealthyFoodViewModel.GetItem(entityID.Value);
                DataContext = App.HealthyFoodViewModel.GetItem(entityID.Value);
                pageInitialized = true;
            }

            base.OnNavigatedTo(e);
        }

        private void OnEdit(object sender, EventArgs e)
        {
            NavigationService.Navigate(UriHelper.GetHealthyFoodEditView(this.DataContext as HealthyFood));
        }

        private void OnDelete(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Delete Item", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                App.HealthyFoodViewModel.RemoveItem((this.DataContext as HealthyFood).Id);
                NavigationService.GoBack();
            }
        }
    }
}