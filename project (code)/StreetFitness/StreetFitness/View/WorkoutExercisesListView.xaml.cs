using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Collections.ObjectModel;
using StreetFitness.Model;
using StreetFitness.Utils;

namespace StreetFitness.View
{
    public partial class ExercisesListView : PhoneApplicationPage
    {
        private Workout entity;
        public ObservableCollection<Exercise> Exercises;
        public ExercisesListView()
        {
            InitializeComponent();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var id = NavigationContext.GetIntParam("id");

            if (id.HasValue)
            {
                entity = App.WorkoutsViewModel.GetItem(id.Value);
            }

            Exercises = App.ExercisesViewModel.LoadWorkoutExercises(entity);

            exerciseList.ItemsSource = Exercises;
            /*if (Exercises == null)
            {
                NavigationService.Navigate(UriHelper.HomeUri);
            }

            DataContext = App.ExercisesViewModel;*/


            base.OnNavigatedTo(e);
        }

        private void exerciseList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (exerciseList.SelectedItems.Count > 0)
            {
                NavigationService.Navigate(UriHelper.GetExerciseViewUri(e.AddedItems[0] as Exercise));
                exerciseList.SelectedItem = null;
            }
        }

        private void AddNewExercise(object sender, EventArgs e)
        {
            NavigationService.Navigate(UriHelper.ExerciseEditViewUri);
        }
    }
}