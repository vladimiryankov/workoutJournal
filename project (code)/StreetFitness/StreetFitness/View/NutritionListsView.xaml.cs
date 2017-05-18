using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using StreetFitness.Utils;
using StreetFitness.Model;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace StreetFitness.View
{
    public partial class NutritionListsView : PhoneApplicationPage
    {
        public NutritionListsView()
        {
            InitializeComponent();

            healthyFoodList.DataContext = App.HealthyFoodViewModel;
            avoidableFoodList.DataContext = App.AvoidableFoodViewModel;
        }

        private void healthyFoodList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (healthyFoodList.SelectedItems.Count > 0)
            {
                NavigationService.Navigate(UriHelper.GetHealthyFoodView(e.AddedItems[0] as HealthyFood));
                healthyFoodList.SelectedItem = null;
            }
        }

        private void avoidableFoodList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (avoidableFoodList.SelectedItems.Count > 0)
            {
                NavigationService.Navigate(UriHelper.GetAvoidableFoodView(e.AddedItems[0] as AvoidableFood));
                avoidableFoodList.SelectedItem = null;
            }
        }

        private void healthyFood_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(UriHelper.HealthyFoodEditView);
        }

        private void avoidableFood_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(UriHelper.AvoidableFoodEditView);
        }
    }
}