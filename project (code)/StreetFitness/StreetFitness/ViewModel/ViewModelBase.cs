using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using StreetFitness.Model;
using StreetFitness.Utils;

namespace StreetFitness.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        protected ObjectDataContext _objectDB;

        public ViewModelBase(ObjectDataContext objectDB)
        {
            _objectDB = objectDB;
        }

        public virtual void LoadData()
        {

        }

        public void SaveChangesToDB()
        {
            _objectDB.SubmitChanges();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            Utils.Utils.RaisePropertyChanged(propertyName, this, PropertyChanged);
        }
    }
}
