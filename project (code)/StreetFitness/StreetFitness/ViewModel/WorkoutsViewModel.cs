using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StreetFitness.Model;
using System.Collections.ObjectModel;

namespace StreetFitness.ViewModel
{
    public class WorkoutsViewModel : ItemsViewModelBase<Workout>
    {
        public WorkoutsViewModel(ObjectDataContext objectDB) : base(objectDB)
        {

        }

        public override void LoadData()
        {
            base.LoadData();

            var workoutsInDB = _objectDB.Workouts.ToList(); 
            /*(from Workout workout in _objectDB.Workouts
                                select workout).ToList();*/

            Items = new ObservableCollection<Workout>(workoutsInDB);
        }

        public override void AddItem(Workout item)
        {
            _objectDB.Workouts.InsertOnSubmit(item);
            _objectDB.SubmitChanges();

            Items.Add(item);
        }

        public override void RemoveItem(int id)
        {
            var workout = from w in Items
                           where w.Id == id
                           select w;

            var item = workout.FirstOrDefault();

            if (item != null)
            {
                //remove existing exercises when removing the corresponding workout
                var exercises = (from ex in App.ExercisesViewModel.Items
                                 where ex._workoutId == item.Id
                                 select ex).ToList();

                foreach (var exercise in exercises)
                {
                    App.ExercisesViewModel.RemoveItem(exercise.Id);
                }

                Items.Remove(item);

                _objectDB.Workouts.DeleteOnSubmit(item);
                _objectDB.SubmitChanges();
            }
        }

    }
}
