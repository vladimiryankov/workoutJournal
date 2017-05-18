using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StreetFitness.Model;

namespace StreetFitness.InitializeData
{
    public static class InitializeAvoidableFood
    {
        public static List<AvoidableFood> loadAvoidableFood()
        {
            List<AvoidableFood> food = new List<AvoidableFood>();
            AvoidableFood item = new AvoidableFood();

            item.Name = "White or “multi-grain” bread";
            item.Description = "As tempting as it is to go old-school and pick up soft white bread, nutritionally you’ll be better off leaving it on the shelf. White bread contains zero whole grains, which help stave off heart disease and diabetes. Stock this instead: 100% whole-grain wheat or rye bread.";
            food.Add(item);

            item = new AvoidableFood();
            item.Name = "Doughnuts";
            item.Description = "The amazing taste of donuts don't come without an enormous cost to the body. These sticky and sweet treats are high in calories, fats, and carbs. Plus, because of added preservatives, they can sit on store shelves for extended periods of time without losing its taste or spoiling. The result? Rapid weight gain and poor digestive function.";
            food.Add(item);

            item = new AvoidableFood();
            item.Name = "Bagels";
            item.Description = "Bagels have a massively high glycemic index which increases insulin and inflammation in the body, as a result, the possibility of accelerating aging, worsening acne, and rosacea. One bagel alone often contains 2-3 servings of carbohydrates, so the added pounds will come on quick.";
            food.Add(item);

            item = new AvoidableFood();
            item.Name = "Sugary Cereal";
            item.Description = "Want a surefire way to ruin your body inside and out? With the the high amount of inflammation-causing sugar and gluten content, most cereals will do the trick. Gluten alone can increase skin breakouts and inflammation of the stomach lining. Skip out on the sugary cereals if you'd rather spare yourself the gut-aches and crummy skin.";
            food.Add(item);

            item = new AvoidableFood();
            item.Name = "Chips";
            item.Description = "Most chips are deep fried with trans fats that can increase cholesterol levels and increase the risk of coronary heart disease. Trans fats are made by adding hydrogen to vegetable oil through a process called hydrogenation, which makes the oil less likely to spoil. Using trans fats in the manufacturing of foods helps foods stay fresh longer, have a longer shelf life and have a less greasy feel.";
            food.Add(item);

            item = new AvoidableFood();
            item.Name = "French Fries";
            item.Description = "Just like chips, french fries are often, if not always fried in oils and trans fats. The potatoes themselves are high on the glycemic index leading to an increase in insulin levels which are both harmful to our health, and our waistlines. French fries, along with chips, contain acrylamide, a known carcinogen that is formed when foods are baked or fried at high temperatures which is known to cause cancers.";
            food.Add(item);

            item = new AvoidableFood();
            item.Name = "Fast Food Burgers";
            item.Description = "It's approximated that the meat used to make burgers is 2% or less actual meat. The other 98% of the burger are industrial chemicals that our bodies are highly unlikely to use at all. These chain-made burgers are also high in saturated fats, and may even contain trans fats.";
            food.Add(item);

            item = new AvoidableFood();
            item.Name = "Microwave popcorn";
            item.Description = "Microwave popcorn contains carcinogens, cancer-causing free radicals in the bags that holds the kernels. Perfluorochemicals, or PFC’s, are added to the bags to make them more greaseproof even though they've have been linked to thyroid disease and ADHD, among other illnesses. Another cancer-causing chemical, diacetyl is hidden in the artificial fats.";
            food.Add(item);

            item = new AvoidableFood();
            item.Name = "Margarine";
            item.Description = "Margarine is marketed as a cholesterol-free, healthy alternative to butter, but it's the ultimate source of trans fats, which actually elevate cholesterol and damage blood vessel walls. To play it safe, read food labels to make sure the foods you're eating use omega-3 fats or butter over margarine.";
            food.Add(item);

            return food;
        }
    }
}
