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
    public partial class AllExercisesView : PhoneApplicationPage
    {
        public AllExercisesView()
        {
            InitializeComponent();

            DataContext = App.ExercisesViewModel;
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