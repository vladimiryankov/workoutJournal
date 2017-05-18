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
    public class AvoidableFoodViewModel : ItemsViewModelBase<AvoidableFood>
    {
        public AvoidableFoodViewModel(ObjectDataContext objectDB) : base(objectDB)
        {

        }

        public override void LoadData()
        {
            base.LoadData();

            var avoidableFoodsInDB = _objectDB.AvoidableFoods;

            Items = new ObservableCollection<AvoidableFood>(avoidableFoodsInDB);
        }

        public override void AddItem(AvoidableFood item)
        {
            _objectDB.AvoidableFoods.InsertOnSubmit(item);
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

                _objectDB.AvoidableFoods.DeleteOnSubmit(item);
                _objectDB.SubmitChanges();
            }
        }
    }
}
