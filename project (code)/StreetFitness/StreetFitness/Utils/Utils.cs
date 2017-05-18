using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Windows.Navigation;
using StreetFitness.Model;
using System.Data.Linq;
using System.Reflection;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

namespace StreetFitness.Utils
{
    public static class Utils
    {
        public static void RaisePropertyChanged(string propertyName, object sender, PropertyChangedEventHandler PropertyChanged)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (null != handler)
                    handler(sender, new PropertyChangedEventArgs(propertyName));
            });
        }

        public static int? GetIntParam(this NavigationContext context, string paramKey)
        {
            if (context.QueryString != null && context.QueryString.Keys.Contains(paramKey))
            {
                return int.Parse(context.QueryString[paramKey]);
            }
            return null;
        }

        public static bool HasPendingChanges(this DataContext dataContext)
        {
            ChangeSet pendingChanges = dataContext.GetChangeSet();

            if (pendingChanges.Deletes.Count > 0 || pendingChanges.Inserts.Count > 0 ||
                pendingChanges.Updates.Count > 0)
            {
                return true;
            }

            return false;
        }

        public static void RollBack(this DataContext dataContext)
        {
            ChangeSet pendingChanges = dataContext.GetChangeSet();

            foreach (var insertion in pendingChanges.Inserts)
            {
                dataContext.GetTable(insertion.GetType()).InsertOnSubmit(insertion);
            }

            foreach (var deletion in pendingChanges.Deletes)
            {
                dataContext.GetTable(deletion.GetType()).DeleteOnSubmit(deletion);
            }

            foreach (var update in pendingChanges.Updates)
            {
                dataContext.Refresh(RefreshMode.OverwriteCurrentValues, update);

                IPropertyChangedNotifier updateNotify = update as IPropertyChangedNotifier;

                foreach (PropertyInfo propertyInfo in update.GetType().GetProperties())
                {
                    updateNotify.NotifyPropertyChanged(propertyInfo.Name);
                }
            }
        }

        public static byte[] ConvertToBytes(this Image image)
        {
            byte[] data = null;
            using (MemoryStream stream = new MemoryStream())
            {
                WriteableBitmap wBitmap = new WriteableBitmap(image, null);
                wBitmap.SaveJpeg(stream, wBitmap.PixelWidth, wBitmap.PixelHeight, 0, 100);
                stream.Seek(0, SeekOrigin.Begin);
                data = stream.GetBuffer();
            }

            return data;
        }
    }
}
