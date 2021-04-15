using FluentValidation;

using WpfApp1.Models;

namespace WpfApp1.Validators
{
    //FluentValidation is a framework that allows you to define codebased validators 
    public class SSNValidator : AbstractValidator<string>
    {
        public SSNValidator()
        {
            RuleFor(ssn => new SocialSecurityNumber(ssn))
                .Must(socialSecurityNumber => socialSecurityNumber.IsValid)
                .WithMessage("Social security number must be valid");
        }

    }
}
/*
    //https://docs.fluentvalidation.net/en/latest/start.html
    Person person = new();
    //Populate person
    SSNValidator validator = new();
    ValidationResult result = validator.Validate(person.SSN.SSN);

    //Or validator.Validate(person, options => options.ThrowOnFailures());
    //Or validator.ValidateAndThrow(person);
    if (!result.IsValid)
    {
        foreach (var failure in result.Errors)
        {
            Console.WriteLine($"Property {failure.PropertyName} invalid. Error: {failure.ErrorMessage}");
        }
        //string allMessages = result.ToString("~");     
        //In this case, each message will be separated with a `~`
    }
*/
