using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using StreetFitness.Model;
using StreetFitness.Utils;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;


namespace StreetFitness.View
{
    public partial class PlayWorkoutView : PhoneApplicationPage
    {
        Workout workout = new Workout();
        ObservableCollection<Exercise> exercises = new ObservableCollection<Exercise>();
        Exercise currentExercise = new Exercise();
        Exercise restEntityAsExercise = new Exercise();
        private bool pageInitialized;
        private int counter = 0;
        private int cycles = 0;
        private int cyclesCounter = 1;
        private int cyclesVisualizer = 1;
        private bool workoutOver = false;
        private bool exerciseRest = false;
        private bool cycleRest = false;

        //timer
        private DispatcherTimer _timer;
        private int _exerciseRestDuration;
        private int _cycleRestDuration;
        private int _countDown;

        public PlayWorkoutView()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!pageInitialized)
            {
                //get workout id
                int? workoutID = NavigationContext.GetIntParam("id");
                
                //load the workout
                workout = App.WorkoutsViewModel.GetItem(workoutID.Value);

                //set the context
                Title.DataContext = workout;
                ExerciseImage.DataContext = workout;

                //set the rest durations
                _exerciseRestDuration = (int) (workout.RestBetweenExercises * 60); //seconds
                _cycleRestDuration = (int) (workout.RestBetweenCycles * 60);    //seconds

                //load the workout exercises
                exercises = App.ExercisesViewModel.LoadWorkoutExercises(workout);

                //load first exercise
                currentExercise = exercises.FirstOrDefault();

                //Initialize the exercise data context and start training
                exerciseName.DataContext = currentExercise;
                exerciseRepeats.DataContext = currentExercise;
                ExerciseImage.DataContext = currentExercise;

                //define a rest exercise
                Image img = new Image();
                img.Source = new BitmapImage(new Uri("/Assets/images/rest.jpg", UriKind.Relative));
                byte[] bytes = Utils.Utils.ConvertToBytes(img);
                restEntityAsExercise.Photo = bytes;
                restEntityAsExercise.Name = "Rest Time";

                action.Content = "Hit when ready";
                exerciseRest = true;

                //define cyclesNumber context
                cycles = workout.Cycles;
                cyclesNumber.Text = cyclesVisualizer.ToString();
            }

            pageInitialized = true;

            base.OnNavigatedTo(e);

        }

        private void action_Click(object sender, EventArgs e)
        {
            if (workoutOver)
            {
                NavigationService.GoBack();
            }


            if (exerciseRest)
            {
                activateExerciseRest();
            }
            else
            {
                if (_timer.IsEnabled)
                {
                    _timer.Stop();
                }
                loadNextExercise();
            }
        }

        private void activateExerciseRest()
        {
            exerciseRest = false;
            //timer
            _countDown = _exerciseRestDuration;
            _timer = new DispatcherTimer();
            _timer.Tick += new EventHandler(exerciseTimer_Tick);
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Start();
            //text
            ExerciseImage.DataContext = restEntityAsExercise;
            exerciseName.DataContext = restEntityAsExercise;
            exerciseRepeats.DataContext = restEntityAsExercise.Repeats;
            //button
            action.Content = "Exercise Rest " + workout.RestBetweenExercises + "min";
        }

        private void activateCycleRest()
        {
            cycleRest = false;
            _countDown = _cycleRestDuration;
            _timer = new DispatcherTimer();
            _timer.Tick += new EventHandler(cycleTimer_Tick);
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Start();
            action.Content = "Cycle Rest " + workout.RestBetweenCycles + "min";
        }

        private void exerciseTimer_Tick(object sender, EventArgs e)
        {
            _countDown--;
            action.Content = "Exercise Rest " + _countDown.ToString() + "s";
            if (_countDown < 1)
            {
                _timer.Stop();
                action.Content = "Rest over! Click for next exercise.";
            }
        }

        private void cycleTimer_Tick(object sender, EventArgs e)
        {
            _countDown--;
            action.Content = "Cycle Rest " + _countDown.ToString() + "s";
            if (_countDown < 1)
            {
                _timer.Stop();
                action.Content = "Rest over! Click for next exercise.";
            }
        }

        private void loadNextExercise()
        {
            counter++;
            if (counter < exercises.Count)
            {
                //Load next exercise and update datacontext
                currentExercise = exercises[counter];
                exerciseName.DataContext = currentExercise;
                exerciseRepeats.DataContext = currentExercise;
                ExerciseImage.DataContext = currentExercise;

                action.Content = "Hit when ready";

                //indicate time to rest
                exerciseRest = true;

                if (counter == exercises.Count - 1)
                {
                    cycleRest = true;
                }
            }
            else
            {
                if (cycleRest)
                {
                    activateCycleRest();
                }
                else
                {
                    loadNextCycle();
                }
            }
        }

        private void loadNextCycle()
        {
            //go to next cycle
            cyclesCounter++;
            if (!(cyclesCounter > cycles))
            {
                cyclesVisualizer++;
                cyclesNumber.Text = cyclesVisualizer.ToString();
            }

            if (cyclesCounter <= cycles)
            {
                //restart exercise counter
                counter = 0;

                //Load first exercise again and update datacontext
                if (exercises.Count != 0)
                {
                    currentExercise = exercises[counter];
                    exerciseName.DataContext = currentExercise;
                    exerciseRepeats.DataContext = currentExercise;
                    ExerciseImage.DataContext = currentExercise;  
                }
                else
                {
                    workoutOver = true;
                }
                

                action.Content = "Hit when ready";

                //indicate time to rest
                exerciseRest = true;
                cycleRest = true;
            }
            else //the cycles are over
            {
                endWorkout();
            }
        }

        private void endWorkout()
        {
            action.Content = "Congatulations! This is the end.";
            workoutOver = true;
        }
    }
}