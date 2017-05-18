using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace StreetFitness.Model
{
    [Table(Name = "Workouts")]
    public class Workout : PropertyChangedBase, ITable
    {
        private int _id;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "Int NOT NULL IDENTITY", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    NotifyPropertyChanging("Id");
                    _id = value;
                    NotifyPropertyChanged("Id");
                }
            }
        }

        private string _name;

        [Column(DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    NotifyPropertyChanging("Name");
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        private int _cycles;

        [Column(DbType = "Int", CanBeNull = false)]
        public int Cycles
        {
            get
            {
                return _cycles;
            }
            set
            {
                if (_cycles != value)
                {
                    NotifyPropertyChanging("Cycles");
                    _cycles = value;
                    NotifyPropertyChanged("Cycles");
                }
            }
        }

        private double _restBetweenCycles;

        [Column]
        public double RestBetweenCycles
        {
            get
            {
                return _restBetweenCycles;
            }
            set
            {
                if ((_restBetweenCycles != value))
                {
                    NotifyPropertyChanging("RestBetweenCycles");
                    _restBetweenCycles = value;
                    NotifyPropertyChanged("RestBetweenCycles");
                }
            }
        }

        private double _restBetweenExercises;

        [Column]
        public double RestBetweenExercises
        {
            get
            {
                return _restBetweenExercises;
            }
            set
            {
                if (_restBetweenExercises != value)
                {
                    NotifyPropertyChanging("RestBetweenExercises");
                    _restBetweenExercises = value;
                    NotifyPropertyChanged("RestBetweenExercises");
                }
            }
        }

        private string _description;

        [Column(DbType = "NVarChar(1024)")]
        public string Description
        {
            get
            {
                return this._description;
            }
            set
            {
                if (_description != value)
                {
                    NotifyPropertyChanging("Description");
                    this._description = value;
                    NotifyPropertyChanged("Description");
                }
            }
        }

        private Binary _photo;

        [Column(DbType = "Image", CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public Binary Photo
        {
            get
            {
                return _photo;
            }
            set
            {
                if (_photo != value)
                {
                    NotifyPropertyChanging("Photo");
                    _photo = value;
                    NotifyPropertyChanged("Photo");
                }
            }
        }


        [Column(IsVersion = true)]
        private Binary _version;
        
        //Define the entity set for the collection side of the relationship
        private EntitySet<Exercise> _exercises;

        //Define the association
        [Association(Storage = "_exercises", OtherKey = "_workoutId", ThisKey = "Id")]
        public EntitySet<Exercise> Exercises
        {
            get
            {
                return this._exercises;
            }
            set
            {
                this._exercises.Assign(value);
            }
        }

        //Assign handlers for the add and remove operations 
        public Workout()
        {
            _exercises = new EntitySet<Exercise>(
                new Action<Exercise>(this.attach_Exercise),
                new Action<Exercise>(this.detach_Exercise)
                );
        }

        //Add operation
        private void attach_Exercise(Exercise exc)
        {
            NotifyPropertyChanging("Exercise");
            exc.Workout = this;
        }

        //Remove operation
        private void detach_Exercise(Exercise exc)
        {
            NotifyPropertyChanging("Exercise");
            exc.Workout = this;
        }
    }
}
