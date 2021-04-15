using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfApp1.Converters
{
    public class AdultConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //TODO Handle if null
            return value.ToString().ToUpper() == "ADULT" ? true : (object)false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //TODO Handle if null
            bool adult = System.Convert.ToBoolean(value);

            return adult ? "Adult" : "Child";
        }
    }

    public class YesNoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //TODO Handle if null
            return value.ToString().ToUpper() == "YES" ? true : (object)false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //TODO Handle if null
            bool yesNo = System.Convert.ToBoolean(value);

            return yesNo ? "Yes" : "No";
        }
    }

    public class TrueFalseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //TODO Handle if null
            return value.ToString().ToUpper() == "TRUE" ? true : (object)false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //TODO Handle if null
            bool trueFalse = System.Convert.ToBoolean(value);

            return trueFalse ? "True" : "False";
        }
    }
}

/*
<Window.Resources>
    <converters:AdultConverter x:Key="adultConverter" />
    <converters:TrueFalseConverter x:Key="trueFalseConverter" />
    <converters:YesNoConverter x:Key="yesNoConverter" />
</Window.Resources>

<CheckBox Content="Adult" IsChecked="{Binding IsAdult, Converter={StaticResource adultConverter}}"/>
<CheckBox Content="YesNo" IsChecked="{Binding IsYes, Converter={StaticResource yesNoConverter}}"/>
<CheckBox Content="TrueFalse" IsChecked="{Binding IsTrue, Converter={StaticResource trueFalseConverter}}"/>
*/