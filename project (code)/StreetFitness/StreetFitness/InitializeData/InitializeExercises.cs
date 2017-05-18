using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StreetFitness.Model;

namespace StreetFitness.InitializeData
{
    public static class InitializeExercises
    {
        public static List<Exercise> loadExercises()
        {
            List<Exercise> exercises = new List<Exercise>();
            Exercise item = new Exercise();

            //Abdominal workout
            #region abdominal workout
            item.Name = "Crunches";
            item.Description = "Opposed to the sit-up, during the crunches you should go only 1/3 or 1/2 of the way up " +
                "(as illustrated on the picture) and then go back down again. This is going to focus the intensity on your upper abs." +
                " Actually this is one of the greatest exercises for upper abs in the beginning tutorials.";
            item._workoutId = 1;
            item.Repeats = 8;
            exercises.Add(item);

            item = new Exercise();
            item.Name = "Reversed Crunches";
            item.Description = "";
            item._workoutId = 1;
            item.Repeats = 8;
            exercises.Add(item);

            item = new Exercise();
            item.Name = "Leg Raises";
            item.Description = "This is the reverse of the sit up. Your torso will remain on the ground and you will only lift your legs up to a 90 degrees angle with your upper body and then go back down and repeat. With this one you will be exercising your lower abs.";
            item._workoutId = 1;
            item.Repeats = 8;
            exercises.Add(item);

            item = new Exercise();
            item.Name = "Knee Hugs";
            item.Description = "Hug your legs with your hands and release. This exercise will work both your upper and lower abdominal muscles.";
            item._workoutId = 1;
            item.Repeats = 8;
            exercises.Add(item);

            item = new Exercise();
            item.Name = "Bicycle";
            item.Description = "Like the name suggests you should move your legs pretending that you are riding a bicycle. Once this variation gets easy you can make it harder by keeping your upper body slightly above the ground(in a crunching position) whilst performing the move.";
            item._workoutId = 1;
            item.Repeats = 8;
            exercises.Add(item);

            item = new Exercise();
            item.Name = "Knee To Elbow";
            item.Description = "Despite the 2 aforementioned hand positions I want you to place your hands behind your head. Then every time you go up touch one of your elbows to the knee that is opposing it. For example if you start with your right elbow you will attempt touching it to your left knee and vice versa – your left elbow will go with your right knee.";
            item._workoutId = 1;
            item.Repeats = 8;
            exercises.Add(item);

            item = new Exercise();
            item.Name = "Side Leans";
            item.Description = "Begin by lying on the ground with your arms straight next to your body and knees bent(look at the photo above). From there lean to your left side and touch your left heel with the fingers of your left hand(look at the photo above). Alternatively on your next repetition you will want to touch your right heel with your right hand. At the beginning of each repetition you have to lift your torso slightly(refer to the crunches) above the ground, then lean to the side, then go back down and repeat.";
            item._workoutId = 1;
            item.Repeats = 8;
            exercises.Add(item);

            item = new Exercise();
            item.Name = "Plank";
            item.Description = "The plank is a nice exercise for a finisher of your abdominal exercises workout. Once that you have gone through a various number of the exercises above. The position is similar to a push-up position only that you are resting your torso on your elbows instead of your palms. Hold it for an amount of 30 seconds to a minute and 30 seconds.";
            item._workoutId = 1;
            item.Repeats = 30;
            exercises.Add(item);

            #endregion

            //Pull-up workout
            #region Pull-up/Chin-up workout
            item = new Exercise();
            item.Name = "Regular Chin-up";
            item.Description = "The regular Chin-up is called the variation where your arms are shoulder width apart.";
            item.Repeats = 10;
            item._workoutId = 2;
            exercises.Add(item);

            item = new Exercise();
            item.Name = "Wide grip Pull-up";
            item.Description = "In this variation the distance inbetween your hands is doubled compared to the regular pull-up/chin-up variation." +
                " You should keep in mind that the wide grip chin-ups will hurt your wrists most likely, so it is adviseable to avoid them.";
            item.Repeats = 10;
            item._workoutId = 2;
            exercises.Add(item);

            item = new Exercise();
            item.Name = "Narrow grip Pull-up";
            item.Description = "In this variation your hands should touch each other(or be as close as possible to one another) on the bar." +
                " It’s a very nice variation for both pull-ups and chin-ups. If you do your chin-ups like that it will focus more on your biceps" + 
            "and if you do your pull-ups like that it will focus more on your forearms.";
            item.Repeats = 10;
            item._workoutId = 2;
            exercises.Add(item);

            item = new Exercise();
            item.Name = "L-seat Pull-up";
            item.Description = "Here you have to keep your legs straight in front of you forming a 90 degrees angle with your upper body." +
                "It helps developing your abs and also creating a serious control over all pull-up/chin-up variation on the pull-up bar.";
            item.Repeats = 8;
            item._workoutId = 2;
            exercises.Add(item);
            #endregion

            //Push-up workout
            #region Push-up workout

            item = new Exercise();
            item.Name = "Standard Stance Push-Up";
            item.Description = "The standard stance is just the regular push-up I demonstrated in the push-up tutorial. Within this variation your hands should go just about shoulder-width apart. Also, your elbows should point towards your feet and not out! It will target mainly your triceps and chest.";
            item.Repeats = 10;
            item._workoutId = 3;
            exercises.Add(item);

            item = new Exercise();
            item.Name = "Wide Stance Push-Ups";
            item.Description = "In this variation your hands should go wider than the standard stance and your elbows should point to the sides. The wide stance is typically easier for most people. That’s so because it involves much more shoulders and less triceps.";
            item.Repeats = 10;
            item._workoutId = 3;
            exercises.Add(item);

            item = new Exercise();
            item.Name = "Diamond Push-ups";
            item.Description = "In this variation your thumb and forefinger of one of your hands should touch the thumb and forefinger of the opposite hand(as illustrated on the photo above). These push-ups are also referred to as diamond push-ups because the space that’s formed in between your thumbs and forefingers resembles a diamond. If you want to increase the intensity in this push-up variation just get the fingers of your right hand to go over the fingers of your left hand(in other words – decrease the size of the diamond in between the thumbs and the forefingers). This will put even more stress on your triceps!";
            item.Repeats = 8;
            item._workoutId = 3;
            exercises.Add(item);

            item = new Exercise();
            item.Name = "Declined Push-Ups";
            item.Description = "In this variation you need to get your feet on a chair and thus elevate your lower body. This will immediately increase the stress in your upper body during the exercise. Once this gets easy just replace the chair with something taller.";
            item.Repeats = 10;
            item._workoutId = 3;
            exercises.Add(item);

            item = new Exercise();
            item.Name = "Fist Push-Ups";
            item.Description = "The push-ups on the fists will strengthen your fists(perfect for fighters). Another important thing about them is that they take away all of the tension in the wrists.";
            item.Repeats = 10;
            item._workoutId = 3;
            exercises.Add(item);

            item = new Exercise();
            item.Name = "Fingertip Push-Ups";
            item.Description = "Another variation of the push-up that will strengthen your fists by strengthening your fingers is the fingertip push-up. Another profit of this variation is that once the person gets on his fingertips, the push-ups immediately become “deeper”. The range of motion increases and you can reap more out of it.";
            item.Repeats = 8;
            item._workoutId = 3;
            exercises.Add(item);

            item = new Exercise();
            item.Name = "Clapping Push-Ups";
            item.Description = "This variation is all about explosive speed and coordination. Once you go down, push up as powerful and strong as you can. Your goal is to accumulate enough momentum so that you can gain some air-time for yourself to perform a clap. To make it more challenging, once the one clap push-up gets easy you can attempt a two claps push-up.";
            item.Repeats = 5;
            item._workoutId = 3;
            exercises.Add(item);

            #endregion


            return exercises;
        }
    }
}
