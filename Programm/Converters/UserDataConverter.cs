using System;
using System.Globalization;
using System.Windows.Data;

namespace Programm.Views
{
    public class UserDataConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            dynamic user = value;
            dynamic client = user.Client;
            if (client != null && !string.IsNullOrEmpty(client.idClient))
            {
                return client;
            }

            return user;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}