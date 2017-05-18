using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using StreetFitness.Model;
using StreetFitness.Utils;

namespace StreetFitness.View
{
    public partial class ScheduleWorkoutView : PhoneApplicationPage
    {
        private Workout selectedWorkout = new Workout();
        public ScheduleWorkoutView()
        {
            InitializeComponent();
            listWorkouts.ItemsSource = App.WorkoutsViewModel.Items.ToList();
        }

        private void sheduleWorkout_Click(object sender, RoutedEventArgs e)
        {
            //define a task element
            SaveAppointmentTask workoutSchedule = new SaveAppointmentTask();

            //populate appointment's fields
            workoutSchedule.StartTime = startTimePicker.Value;

            workoutSchedule.EndTime = endTimePicker.Value;

            selectedWorkout = (Workout)listWorkouts.SelectedItem;

            workoutSchedule.Subject = selectedWorkout.Name.ToString();

            workoutSchedule.Location = locationBox.Text;

            workoutSchedule.Details = detailsBox.Text;

            //call the built-in calendar to proceed saving the appointment
            workoutSchedule.Show();
        }
    }
}