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
    public partial class WorkoutsListView : PhoneApplicationPage
    {
        public WorkoutsListView()
        {
            InitializeComponent();

            DataContext = App.WorkoutsViewModel;
        }

        private void workoutList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (workoutList.SelectedItems.Count > 0)
            {
                NavigationService.Navigate(UriHelper.GetWorkoutViewUri(e.AddedItems[0] as Workout));
                workoutList.SelectedItem = null;
            }
        }

        private void AddNewWorkout(object sender, EventArgs e)
        {
            NavigationService.Navigate(UriHelper.WorkoutEditViewUri);
        }

    }
}