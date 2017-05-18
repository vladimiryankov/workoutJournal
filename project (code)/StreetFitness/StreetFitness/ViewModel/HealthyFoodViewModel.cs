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
    public class HealthyFoodViewModel : ItemsViewModelBase<HealthyFood>
    {
        public HealthyFoodViewModel(ObjectDataContext objectDB) : base(objectDB)
        {

        }

        public override void LoadData()
        {
            base.LoadData();

            var healthyFoodsInDB = _objectDB.HealthyFoods;

            Items = new ObservableCollection<HealthyFood>(healthyFoodsInDB);
        }

        public override void AddItem(HealthyFood item)
        {
            _objectDB.HealthyFoods.InsertOnSubmit(item);
            _objectDB.SubmitChanges();

            Items.Add(item);
        }

        public override void RemoveItem(int id)
        {
            var food = (from foods in Items
                        where foods.Id == id
                        select foods).ToList();

            var item = food.FirstOrDefault();

            if (item != null)
            {
                Items.Remove(item);

                _objectDB.HealthyFoods.DeleteOnSubmit(item);
                _objectDB.SubmitChanges();
            }
            
        }
    }
}
