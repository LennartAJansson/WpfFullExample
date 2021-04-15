using System.Globalization;
using System.Windows.Controls;

namespace WpfApp1.Validators
{
    public class SSNValidatorRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var pv = new SSNValidator();
            FluentValidation.Results.ValidationResult result = pv.Validate(value as string);

            if (!result.IsValid)
            {
                string allMessages = result.ToString("#");

                return new ValidationResult(false, allMessages);
            }

            return ValidationResult.ValidResult;
        }
    }
}
/*
 * https://docs.microsoft.com/en-us/dotnet/desktop/wpf/data/how-to-implement-binding-validation?view=netframeworkdesktop-4.8&viewFallbackFrom=netdesktop-5.0
 * 
<TextBox Style="{StaticResource CustomErrorControlOnErrorStyle}">
  <TextBox.Text>
    <Binding Path="Person.SSN.SSN" UpdateSourceTrigger="PropertyChanged">
      <Binding.ValidationRules>
        <validators:SSNValidatorRule />
      </Binding.ValidationRules>
    </Binding>
  </TextBox.Text>
</TextBox>

<UserControl.Resources>
        
        <Style x:Key="DefaultTextBoxStyle" TargetType="TextBox">
            <!--<Setter Property="Margin" Value="5" />-->
            <!--<Setter Property="VerticalAlignment" Value="Center" />-->
        </Style>
        
        <Style x:Key="CustomErrorControlOnErrorStyle" TargetType="TextBox" BasedOn="{StaticResource DefaultTextBoxStyle}">
            <Setter Property="Validation.ErrorTemplate">
                <Setter.Value>
                    <ControlTemplate>
                        <StackPanel>
                            <AdornedElementPlaceholder x:Name="placeholder" />
                            <TextBlock FontSize="11" FontStyle="Italic" Foreground="Red"
                                       Text="{Binding ElementName=placeholder, Path=AdornedElement.(Validation.Errors)/ErrorContent}" />
                        </StackPanel>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
</UserControl.Resources>
*/
