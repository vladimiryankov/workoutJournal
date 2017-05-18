using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using StreetFitness.Model;
using StreetFitness.Utils;



namespace StreetFitness.InitializeData
{
    public static class InitializeHealthyFoodData
    {
        public static List<HealthyFood> loadHealthyFoods()
        {
            List<HealthyFood> food = new List<HealthyFood>();
            /*Image img = new Image();
            byte[] bytes;*/
            HealthyFood item = new HealthyFood();

            item.Name = "Lemon";
            item.Description = "1. Aids in Detoxing and Digestion \n2. Burns fat and accelorates weight loss \n3. High in Vitamin C \n4. Relieves constipation \n5.Alkalizes the body";
            /*img.Source = new BitmapImage(new Uri("/Assets/images/Nutrition/lemon.jpg", UriKind.Relative));
            bytes = Utils.Utils.ConvertToBytes(img);
            item.Photo = bytes;*/
            food.Add(item);

            item = new HealthyFood();
            item.Name = "Avocado";
            item.Description = "1. Good Healthy fats that aid in weight loss and burn fat! \n2. Prevents & assits arthritis \n3. Reduces and reverses aging \n4. High in Vitamins A,C,K & B6 \n5. High in Fiber, Potassium & Folic Acid";
            /*img.Source = new BitmapImage(new Uri("/Assets/images/Nutrition/avocado.jpg", UriKind.Relative));
            bytes = Utils.Utils.ConvertToBytes(img);
            item.Photo = bytes;*/
            food.Add(item);

            item = new HealthyFood();
            item.Name = "Ginger";
            item.Description = "1. Rids colds and flus. \n2. Aids in weight loss and detoxification \n3. High in Magnesium and relieves muscle pain \n4. Reduces inflammation \n5. Relieves migraines & headaches";
            food.Add(item);

            item = new HealthyFood();
            item.Name = "Coconut";
            item.Description = "1. Accelorates weight loss \n2. Lowers Cholesterol \n3. Improves diabetes \n4. Aids digestion \n5. A great natural skin moisturizer \n6. High in protein and calcium";
            food.Add(item);

            item = new HealthyFood();
            item.Name = "Pichuberries";
            item.Description = "Pichuberries are small orange fruits, about the size of a cherry tomato. They come from the Andes of Peru and boast a tart, sweet flavor. In addition to vitamin D, pichuberries also contain vitamins C and B12, iron, protein, and cancer-fighting compounds called withanolides.";
            food.Add(item);

            item = new HealthyFood();
            item.Name = "Bee pollen";
            item.Description = " It's got a little bit of everything, from vitamin B12 and all 22 amino acids, to protein and antioxidants. Bee pollen is incredibly high in protein—about 40%, and is a great energy booster, too. Drop a spoonful into your smoothies or mix into oatmeal or yogurt. ";
            food.Add(item);

            item = new HealthyFood();
            item.Name = "Egg whites";
            item.Description = "Egg whites are rich in branched-chain amino acids, which keep your metabolism stoked, says Chicago nutritionist David Grotto, RDN. Eggs are also loaded with protein and vitamin D.";
            food.Add(item);

            item = new HealthyFood();
            item.Name = "Lean meat";
            item.Description = "Lean meat is full of iron; deficiencies in the mineral can slow metabolism. Eat three to four daily servings of iron-rich foods, such as chicken or fortified cereal.";
            food.Add(item);

            item = new HealthyFood();
            item.Name = "Water";
            item.Description = "If you're even mildly dehydrated, your metabolism may slow down, says Scott Isaacs, MD, clinical instructor of medicine at the Emory University School of Medicine. Tip: Drink water cold, which forces your body to use more calories to warm it up.";
            food.Add(item);

            item = new HealthyFood();
            item.Name = "Green Tea";
            item.Description = "The brew contains a plant compound called EGCG, which promotes fat-burning, research suggests.";
            food.Add(item);

            item = new HealthyFood();
            item.Name = "Milk";
            item.Description = "Studies conducted by Michael Zemel, PhD, former director of The Nutrition Institute at the University of Tennessee, suggest that consuming calcium may help your body metabolize fat more efficiently.";
            food.Add(item);

            item = new HealthyFood();
            item.Name = "Whole grains";
            item.Description = "Whole grains help your body burn more fat because they take extra effort to break down than processed grains, like white bread and pasta. Whole foods that are rich in fiber, like brown rice and oatmeal, are your best bets.";
            food.Add(item);

            item = new HealthyFood();
            item.Name = "Lentils";
            item.Description = "About 20 percent of women are iron deficient, which is bad news for your waistline—your body can't work as efficiently to burn calories when it's missing what it needs to work properly. One cup of lentils provides 35 percent of your daily iron needs. ";
            food.Add(item);

            return food;
        }
    }
}
