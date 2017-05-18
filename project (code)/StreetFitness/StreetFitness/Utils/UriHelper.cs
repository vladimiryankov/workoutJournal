using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StreetFitness.Model;

namespace StreetFitness.Utils
{
    public static class UriHelper
    {
        //home
        public readonly static Uri HomeUri = new Uri("/View/MainPage.xaml", UriKind.Relative);

        //about
        public readonly static Uri AboutUri = new Uri("/View/AboutPage.xaml", UriKind.Relative);

        //settings
        public readonly static Uri SettingsUri = new Uri("/View/SettingsView.xaml", UriKind.Relative);

        //workout
        public readonly static Uri WorkoutListViewUri = new Uri("/View/WorkoutsListView.xaml", UriKind.Relative);
        public readonly static Uri WorkoutEditViewUri = new Uri("/View/WorkoutEditView.xaml", UriKind.Relative);

        public static Uri GetWorkoutViewUri(Workout workout)
        {
            Console.WriteLine("uri helper id : {0}", workout.Id);
            return new Uri(string.Format("/View/WorkoutView.xaml?id={0}", workout.Id), UriKind.Relative);
        }

        public static Uri GetWorkoutEditViewUri(Workout workout)
        {
            return new Uri(string.Format("/View/WorkoutEditView.xaml?id={0}", workout.Id), UriKind.Relative);
        }

        public static Uri GetPlayWorkoutView(Workout workout)
        {
            return new Uri(string.Format("/View/PlayWorkoutView.xaml?id={0}", workout.Id), UriKind.Relative);
        }

        //exercise
        public readonly static Uri ExerciseEditViewUri = new Uri("/View/ExerciseEditView.xaml", UriKind.Relative);
        public readonly static Uri AllExercisesViewUri = new Uri("/View/AllExercisesView.xaml", UriKind.Relative);
        public readonly static Uri AddExerciseViewUri = new Uri("/View/AddExerciseView.xaml", UriKind.Relative);

        public static Uri GetAddExerciseViewUri(Exercise exercise)
        {
            return new Uri(string.Format("/View/AddExerciseView.xaml?id={0}", exercise.Id), UriKind.Relative);
        }
        public static Uri GetWorkoutExercisesListViewUri(Workout workout)
        {
            return new Uri(string.Format("/View/WorkoutExercisesListView.xaml?id={0}", workout.Id), UriKind.Relative);
        }
        public static Uri GetExerciseViewUri(Exercise exercise)
        {
            return new Uri(string.Format("/View/ExerciseView.xaml?id={0}", exercise.Id), UriKind.Relative);
        }

        public static Uri GetExerciseEditViewUri(Exercise exercise)
        {
            return new Uri(string.Format("/View/ExerciseEditView.xaml?id={0}", exercise.Id), UriKind.Relative);
        }

        //schedule
        public readonly static Uri ScheduleWorkoutView = new Uri("/View/ScheduleWorkoutView.xaml", UriKind.Relative);

        //nutrition
        public readonly static Uri NutritionListsView = new Uri("/View/NutritionListsView.xaml", UriKind.Relative);
        
        //healthy foods
        public readonly static Uri HealthyFoodView = new Uri("/View/HealthyFoodView.xaml", UriKind.Relative);
        public readonly static Uri HealthyFoodEditView = new Uri("/View/HealthyFoodEditView.xaml", UriKind.Relative);

        public static Uri GetHealthyFoodView(HealthyFood food)
        {
            return new Uri(string.Format("/View/HealthyFoodView.xaml?id={0}", food.Id), UriKind.Relative);
        }

        public static Uri GetHealthyFoodEditView(HealthyFood food)
        {
            return new Uri(string.Format("/View/HealthyFoodEditView.xaml?id={0}", food.Id), UriKind.Relative);
        }

        //avoidable foods
        public readonly static Uri AvoidableFoodView = new Uri("/View/AvoidableFoodView.xaml", UriKind.Relative);
        public readonly static Uri AvoidableFoodEditView = new Uri("/View/AvoidableFoodEditView.xaml", UriKind.Relative);

        public static Uri GetAvoidableFoodView(AvoidableFood food)
        {
            return new Uri(string.Format("/View/AvoidableFoodView.xaml?id={0}", food.Id), UriKind.Relative);
        }

        public static Uri GetAvoidableFoodEditView(AvoidableFood food)
        {
            return new Uri(string.Format("/View/AvoidableFoodEditView.xaml?id={0}", food.Id), UriKind.Relative);
        }
    }
}
