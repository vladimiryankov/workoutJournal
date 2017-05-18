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
    public partial class WorkoutView : PhoneApplicationPage
    {
        private bool pageInitialized;
        public WorkoutView()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!pageInitialized)
            {
                int? entityID = NavigationContext.GetIntParam("id");
                DataContext = App.WorkoutsViewModel.GetItem(entityID.Value);

                pageInitialized = true;
            }
            base.OnNavigatedTo(e);
        }

        private void OnDelete(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Delete Item", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                App.WorkoutsViewModel.RemoveItem((this.DataContext as Workout).Id);
                NavigationService.GoBack();
            }
        }

        private void OnEdit(object sender, EventArgs e)
        {
            NavigationService.Navigate(UriHelper.GetWorkoutEditViewUri(this.DataContext as Workout));
        }
        
        private void OnPlay(object sender, EventArgs e)
        {
            NavigationService.Navigate(UriHelper.GetPlayWorkoutView(this.DataContext as Workout));
        }

        private void workoutExercises_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(UriHelper.GetWorkoutExercisesListViewUri(this.DataContext as Workout));
        }
    }
}