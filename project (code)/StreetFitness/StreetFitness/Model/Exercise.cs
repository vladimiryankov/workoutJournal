using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace StreetFitness.Model
{
    [Table(Name = "Exercises")]
    public class Exercise : PropertyChangedBase, ITable
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
                    NotifyPropertyChanging("Id");
                    _name = value;
                    NotifyPropertyChanged("Id");
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

        private int _repeats;

        [Column(DbType = "Int")]
        public int Repeats
        {
            get
            {
                return _repeats;
            }
            set
            {
                if (_repeats != value)
                {
                    NotifyPropertyChanging("Repeats");
                    _repeats = value;
                    NotifyPropertyChanged("Repeats");
                }
            }
        }

        [Column(IsVersion = true)]
        private Binary _version;

        //Internal column for the associated Workout ID value
        [Column]
        internal int _workoutId;

        public int WorkoutId
        {
            get { return _workoutId; }
        }

        //Entity reference to identify the Workout "storage" table
        private EntityRef<Workout> _workout;

        //Association to describe the relationship between this key and that "storage" table 
        [Association(Storage = "_workout", ThisKey = "_workoutId", OtherKey = "Id", IsForeignKey = true)]
        public Workout Workout
        {
            get
            {
                return _workout.Entity;
            }
            set
            {
                Workout previousValue = _workout.Entity;
                if (previousValue != value)
                {
                    NotifyPropertyChanging("Workout");

                    //remove previous exercise if existing
                    if (previousValue != null)
                    {
                        _workout.Entity = null;
                        previousValue.Exercises.Remove(this);
                    }

                    _workout.Entity = value;

                    if (value != null)
                    {
                        value.Exercises.Add(this);
                        _workoutId = value.Id;
                    }

                    NotifyPropertyChanged("Workout");
                }
            }
        }

        public Exercise()
        {
            _workout = default(EntityRef<Workout>);
        }
    }
}
