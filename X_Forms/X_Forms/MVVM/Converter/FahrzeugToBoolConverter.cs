using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace X_Forms.MVVM.Converter
{
    //Konverter zur Überprüfung, ob in dem ListView ein Objekt ausgewählt wurde (vgl. View/FahrzeugView.xaml und DoubleToColorConverter.cs)
    internal class FahrzeugToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Model.Fahrzeug;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
