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
    public partial class AvoidableFoodEditView : EntityEditPage
    {
        private AvoidableFood entity;
        private bool isNew;
        private bool pageInitialized;
        int ident;

        private PhotoChooserTask _photoChooserTask;
        private CameraCaptureTask _cameraCaptureTask;
        public AvoidableFoodEditView()
        {
            InitializeComponent();

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
                        entity = App.AvoidableFoodViewModel.GetItem(id.Value);
                        ident = id.Value;
                    }
                    PageTitle.Text = "Edit avoidable food";
                }
                else
                {
                    isNew = true;
                    entity = new AvoidableFood();
                    PageTitle.Text = "New avoidable food";
                }

                DataContext = entity;
                pageInitialized = true;
            }
            base.OnNavigatedTo(e);
        }

        protected override void StoreState()
        {
            State["Name"] = foodName.Text;
            State["Description"] = foodDescription.Text;
        }

        protected override void RestoreState()
        {
            Dispatcher.BeginInvoke(() =>
            {
                entity.Name = State["Name"].ToString();
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

        private void OnSave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(entity.Name))
            {
                MessageBox.Show("Food Name cannot be empty.");
                return;
            }

            if (isNew)
            {
                App.AvoidableFoodViewModel.AddItem(entity);
            }
            else
            {
                App.AvoidableFoodViewModel.SaveChangesToDB();
            }

            NavigationService.GoBack();
        }

        private void OnCancel(object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}