using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StreetFitness.Model;
using StreetFitness.View;
using System.Collections.ObjectModel;


namespace StreetFitness.ViewModel
{
    public class ExercisesViewModel : ItemsViewModelBase<Exercise>
    {
        public ExercisesViewModel(ObjectDataContext objectDB) : base(objectDB)
        {

        }

        public override void LoadData()
        {
            base.LoadData();

            var exercisesInDB = (from Exercise exercise in _objectDB.Exercises
                                 select exercise).ToList();

            Items = new ObservableCollection<Exercise>(exercisesInDB);
        }

        public ObservableCollection<Exercise> LoadWorkoutExercises(Workout workout)
        {
            var exercisesInWorkout = (from Exercise exercise in Items
                                      where exercise._workoutId == workout.Id
                                      select exercise).ToList();
            ObservableCollection<Exercise> exercises = new ObservableCollection<Exercise>(exercisesInWorkout);

            return exercises;
        }

        public override void AddItem(Exercise item)
        {
            _objectDB.Exercises.InsertOnSubmit(item);
            _objectDB.SubmitChanges();

            Items.Add(item);
        }


        public override void RemoveItem(int id)
        {
            var exercise = from e in Items
                           where e.Id == id
                           select e;

            var item = exercise.FirstOrDefault();

            if (item != null)
            {
                Items.Remove(item);

                _objectDB.Exercises.DeleteOnSubmit(item);
                _objectDB.SubmitChanges();
            }
        }
    }
}
