using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfWithWebApi.Wpf.Converters
{
    public class AdultConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool adultOrChild = false;

            if (value != null)
            {
                adultOrChild = value.ToString().ToUpper() == "ADULT";
            }

            return adultOrChild ? true : (object)false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool adultOrChild = false;

            if (value != null)
            {
                adultOrChild = System.Convert.ToBoolean(value);
            }

            return adultOrChild ? "Adult" : "Child";
        }
    }

    public class YesNoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool yesOrNo = false;

            if (value != null)
            {
                yesOrNo = value.ToString().ToUpper() == "YES";
            }

            return yesOrNo ? true : (object)false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool yesOrNo = false;

            if (value != null)
            {
                yesOrNo = System.Convert.ToBoolean(value);
            }

            return yesOrNo ? "Yes" : "No";
        }
    }

    public class TrueFalseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool trueOrFalse = false;

            if (value != null)
            {
                trueOrFalse = value.ToString().ToUpper() == "TRUE";
            }

            return trueOrFalse ? true : (object)false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool trueOrFalse = false;

            if (value != null)
            {
                trueOrFalse = System.Convert.ToBoolean(value);
            }

            return trueOrFalse ? "True" : "False";
        }
    }
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return "Visible";
            }
            else
            {
                return "Hidden";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value.ToString().ToUpper() == "VISIBLE";
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