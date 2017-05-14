using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;
using VitaChildApp.Models;

namespace VitaChildApp.Converters
{
    public class FoodItemToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var itemList = new ObservableCollection<string>();
            foreach (var item in (ObservableCollection<FoodItem>)value)
            {
                itemList.Add(item.ItemName);
            }
            return itemList;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
