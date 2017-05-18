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
    public partial class ExerciseView : PhoneApplicationPage
    {
        private bool pageInitialized;
        public ExerciseView()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!pageInitialized)
            {
                int? entityID = NavigationContext.GetIntParam("id");
                Exercise entity = App.ExercisesViewModel.GetItem(entityID.Value);
                DataContext = App.ExercisesViewModel.GetItem(entityID.Value);
                workout_Title.Text = App.WorkoutsViewModel.GetItem(entity._workoutId).Name;

                pageInitialized = true;
            }
            base.OnNavigatedTo(e);
        }

        private void OnEdit(object sender, EventArgs e)
        {
            NavigationService.Navigate(UriHelper.GetExerciseEditViewUri(this.DataContext as Exercise));
        }

        private void OnDelete(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Delete Item", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                App.ExercisesViewModel.RemoveItem((this.DataContext as Exercise).Id);
                NavigationService.GoBack();
            }
        }
    }
}