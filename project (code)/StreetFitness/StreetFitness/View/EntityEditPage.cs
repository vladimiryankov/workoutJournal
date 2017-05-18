using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Navigation;
using StreetFitness.Utils;

namespace StreetFitness.View
{
    public class EntityEditPage : PageBase
    {
        protected bool rollbackRequired;


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            rollbackRequired = false;

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back && App.db.HasPendingChanges())
            {
                rollbackRequired = true;
            }

            base.OnNavigatingFrom(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            if (e.IsNavigationInitiator)
            {
                if (rollbackRequired)
                    App.db.RollBack();
            }
            else if (App.db.HasPendingChanges())
            {
                App.db.RollBack();
            }
        }
    }
}
