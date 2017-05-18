using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace StreetFitness.Model
{
    public class PropertyChangedBase : IPropertyChangedNotifier, INotifyPropertyChanging
    {
        // Used to notify that a property changed
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        // Used to notify that a property is about to change
        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        public void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        #endregion
    }
}
