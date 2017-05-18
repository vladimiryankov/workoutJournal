using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StreetFitness.Model;

namespace StreetFitness.InitializeData
{
    /*db.Workouts.InsertOnSubmit(new Workout() {Name = "First Workout", Cycles = 3, Description = "This is the first workout", RestBetweenCycles = 3, RestBetweenExercises = 0.5 });
      db.Workouts.InsertOnSubmit(new Workout() {Name = "Second Workout", Cycles = 2, Description = "This is the second workout" });*/
    public static class InitializeWorkouts
    {
        public static List<Workout> loadWorkouts()
        {
            List<Workout> workouts = new List<Workout>();
            Workout item = new Workout();

            item.Name = "Abdominal workout";
            item.Cycles = 2;
            item.RestBetweenCycles = 4;
            item.RestBetweenExercises = 0.5;
            item.Description = "This workout consists of several very important body weight abdominal exercises. " +
                " These simple exercises build the foundation of your abdominal and core strength." + 
                " Since abs are included in most advanced gymnastics exercises, you need to need" + 
                " to build enough strength in order to proceed further.";
            workouts.Add(item);

            item = new Workout();
            item.Name = "Pull-ups workout";
            item.Cycles = 1;
            item.RestBetweenCycles = 0;
            item.RestBetweenExercises = 1;
            item.Description = "This workout encompasses the different fundamental pull-up/chin-up variations";
            workouts.Add(item);

            item = new Workout();
            item.Name = "Push-ups workout";
            item.Cycles = 3;
            item.RestBetweenExercises = 0.25;
            item.RestBetweenCycles = 2;
            item.Description = "This workout consists of different push-up variations. Push-ups are very important in order" + 
                " to proceed further with more complex and deep workout routines. They also help you to develop a very strong, " + 
                "well shaped and defined upper body muscles";
            workouts.Add(item);

            return workouts;
        }
    }
}
