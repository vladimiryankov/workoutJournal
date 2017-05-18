using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace StreetFitness.Model
{
    public class ObjectDataContext : DataContext
    {
        public ObjectDataContext(string connectionString) : base(connectionString)
        {

        }

        public Table<Exercise> Exercises;
        public Table<Workout> Workouts;
        public Table<HealthyFood> HealthyFoods;
        public Table<AvoidableFood> AvoidableFoods;

    }
}
