using System.Globalization;
using System.Windows.Controls;

namespace WpfApp1.Validators
{
    public class EmailValidatorRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var ev = new EmailValidator();
            FluentValidation.Results.ValidationResult result = ev.Validate(value as string);

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
<TextBox Validation.ErrorTemplate="{StaticResource ValidationTemplate}" Style="{StaticResource TextBoxInError}">
  <TextBox.Text>
    <Binding Path="Person.Email" UpdateSourceTrigger="PropertyChanged">
      <Binding.ValidationRules>
        <validators:EmailValidatorRule />
      </Binding.ValidationRules>
    </Binding>
  </TextBox.Text>
</TextBox>

<UserControl.Resources>
    <ControlTemplate x:Key="ValidationTemplate">
        <DockPanel>
            <TextBlock Foreground="Red" FontWeight="ExtraBold">!</TextBlock>
            <AdornedElementPlaceholder/>
        </DockPanel>
    </ControlTemplate>

    <Style x:Key="TextBoxInError" TargetType="{x:Type TextBox}">
        <Style.Triggers>
            <Trigger Property="Validation.HasError" Value="true">
                <Setter Property="ToolTip" Value="{Binding RelativeSource={x:Static RelativeSource.Self}, Path=(Validation.Errors)[0].ErrorContent}"/>
            </Trigger>
        </Style.Triggers>
    </Style>
</UserControl.Resources>
*/
