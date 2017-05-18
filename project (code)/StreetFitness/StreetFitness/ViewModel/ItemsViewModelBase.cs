using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using StreetFitness.Model;
using System.Windows; 

namespace StreetFitness.ViewModel
{
    public abstract class ItemsViewModelBase<T> : ViewModelBase where T : ITable
    {
        public ItemsViewModelBase(ObjectDataContext objectDB)
            : base(objectDB)
        {
            Items = new ObservableCollection<T>();
        }

        private ObservableCollection<T> _items;
        public ObservableCollection<T> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }

        public virtual void AddItem(T item)
        {

        }

        public virtual void RemoveItem(int id)
        {

        }

        public virtual T GetItem(int id)
        {
            T found = Items.FirstOrDefault<T>(item => item.Id == id);
            return found;
        }
    }
}
