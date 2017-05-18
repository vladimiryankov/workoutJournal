using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Phone.Tasks;
using StreetFitness.Utils;
using StreetFitness.Model;

namespace StreetFitness.View
{
    public partial class AddExerciseView : EntityEditPage
    {
        private Exercise entity;
        private bool isNew;
        private bool pageInitialized;
        private bool sourcesSet;

        private PhotoChooserTask _photoChooserTask;
        private CameraCaptureTask _cameraCaptureTask;
        public AddExerciseView()
        {
            InitializeComponent();
            SetSources();

            _photoChooserTask = new PhotoChooserTask();
            _photoChooserTask.Completed += new EventHandler<PhotoResult>(_photoChooserTask_Completed);

            _cameraCaptureTask = new CameraCaptureTask();
            _cameraCaptureTask.Completed += new EventHandler<PhotoResult>(_cameraCaptureTask_Completed);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!pageInitialized)
            {
                if (NavigationContext.QueryString.ContainsKey("id"))
                {
                    isNew = false;
                    var id = NavigationContext.GetIntParam("id");

                    if (id.HasValue)
                    {
                        entity = App.ExercisesViewModel.GetItem(id.Value);
                    }

                    PageTitle.Text = "Edit exercise";
                }
                else
                {
                    isNew = true;
                    entity = new Exercise();
                    listWorkouts.SelectedItem = App.WorkoutsViewModel.Items.FirstOrDefault();
                    PageTitle.Text = "New exercise";
                }

                DataContext = entity;
                pageInitialized = true;
            }
            base.OnNavigatedTo(e);
        }

        private void SetSources()
        {
            if (!sourcesSet)
            {
                sourcesSet = true;
                listWorkouts.ItemsSource = App.WorkoutsViewModel.Items.ToList();
            }
        }

        protected override void StoreState()
        {
            State["Name"] = exerciseName.Text;
            State["Repeats"] = exerciseRepeats.Text;
            State["Description"] = exerciseDescription.Text;
        }

        protected override void RestoreState()
        {
            Dispatcher.BeginInvoke(() =>
            {
                entity.Name = State["Name"].ToString();
                entity.Repeats = int.Parse(State["Repeats"].ToString());
                entity.Description = State["Description"].ToString();
            });
        }

        private void OnTakePhoto(object sender, EventArgs e)
        {
            _cameraCaptureTask.Show();
        }

        private void OnChoosePhoto(object sender, EventArgs e)
        {
            _photoChooserTask.Show();
        }

        private void _photoChooserTask_Completed(object sender, PhotoResult e)
        {
            ProcessPhotoResult(e);
        }

        private void _cameraCaptureTask_Completed(object sender, PhotoResult e)
        {
            ProcessPhotoResult(e);
        }
        private void ProcessPhotoResult(PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK && e.ChosenPhoto != null)
            {
                var bytes = new byte[e.ChosenPhoto.Length];
                e.ChosenPhoto.Position = 0;
                e.ChosenPhoto.Read(bytes, 0, (int)e.ChosenPhoto.Length);
                entity.Photo = bytes;
            }
        }

        private void OnSaveExercise(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(entity.Name))
            {
                MessageBox.Show("Exercise Name cannot be empty.");
                return;
            }

            entity.Workout = (Workout)listWorkouts.SelectedItem;

            if (isNew)
            {
                App.ExercisesViewModel.AddItem(entity);
            }
            else
            {
                App.ExercisesViewModel.SaveChangesToDB();
            }

            NavigationService.GoBack();
        }

        private void OnCancel(object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }
    }    
}