using System;
using System.Globalization;
using System.Windows.Controls;

namespace WpfWithWebApi.Wpf.Validators.Samples
{
    public class NumericValidationRule : ValidationRule
    {
        public Type ValidationType { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string strValue = Convert.ToString(value);

            if (string.IsNullOrEmpty(strValue))
                return new ValidationResult(false, $"Value cannot be coverted to string.");
            bool canConvert = false;
            switch (ValidationType.Name)
            {
                case "Boolean":
                    bool boolVal = false;
                    canConvert = bool.TryParse(strValue, out boolVal);
                    return canConvert ? new ValidationResult(true, null) : new ValidationResult(false, $"Input should be type of boolean");

                case "Int32":
                    int intVal = 0;
                    canConvert = int.TryParse(strValue, out intVal);
                    return canConvert ? new ValidationResult(true, null) : new ValidationResult(false, $"Input should be type of Int32");

                case "Double":
                    double doubleVal = 0;
                    canConvert = double.TryParse(strValue, out doubleVal);
                    return canConvert ? new ValidationResult(true, null) : new ValidationResult(false, $"Input should be type of Double");

                case "Int64":
                    long longVal = 0;
                    canConvert = long.TryParse(strValue, out longVal);
                    return canConvert ? new ValidationResult(true, null) : new ValidationResult(false, $"Input should be type of Int64");

                default:
                    throw new InvalidCastException($"{ValidationType.Name} is not supported");
            }
        }
    }
}

/*
 <TextBox Style="{StaticResource ValidationAwareTextBoxStyle}" VerticalAlignment="Center">
    <TextBox.Text>
        <Binding Path="Number" Mode="TwoWay" UpdateSourceTrigger="PropertyChanged"
            Converter="{cnv:TypeConverter}" ConverterParameter="Int32"
            ValidatesOnNotifyDataErrors="True" ValidatesOnDataErrors="True" NotifyOnValidationError="True">
            <Binding.ValidationRules>
                <validationRules:NumericValidationRule ValidationType="{x:Type system:Int32}" 
                    ValidatesOnTargetUpdated="True" />
            </Binding.ValidationRules>
        </Binding>
    </TextBox.Text>
</TextBox>
*/