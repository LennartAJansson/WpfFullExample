using FluentValidation;

namespace WpfApp1.Validators
{
    //FluentValidation is a framework that allows you to define codebased validators 
    public class EmailValidator : AbstractValidator<string>
    {
        public EmailValidator()
        {
            RuleFor(email => email)
                .EmailAddress()
                .WithMessage("Email address must be valid");

        }

    }
}
/*
    //https://docs.fluentvalidation.net/en/latest/start.html
    Person person = new();
    //Populate person
    EmailValidator validator = new();
    ValidationResult result = validator.Validate(person.Email);

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
