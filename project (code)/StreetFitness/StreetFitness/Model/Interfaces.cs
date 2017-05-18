using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace StreetFitness.Model
{
    public interface ITable
    {
        int Id
        {
            get;
            set;
        }
    }
    public interface IPropertyChangedNotifier : INotifyPropertyChanged
    {
        void NotifyPropertyChanged(string propertyName);
    }
}
