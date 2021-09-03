using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;

using System.Security;

using WpfApp1.Models;
using WpfApp1.Services;

namespace WpfApp1.ViewModels
{
#pragma warning disable IDE0052 // Remove unread private members

    public class PersonViewModel : ObservableObject
    {
        public Person Person { get => person; set => SetProperty(ref person, value); }
        private Person person;

        public string Password { get; set; }
        public SecureString SecurePassword { get; set; }

        private readonly ILogger<MainViewModel> logger;
        private readonly ICurrentPerson currentPerson;

        public PersonViewModel(ILogger<MainViewModel> logger, ICurrentPerson currentPerson)
        {
            this.logger = logger;
            this.currentPerson = currentPerson;
            Person = currentPerson.Person;
            currentPerson.PersonChanged += CurrentPerson_PersonChanged;
        }

        private void CurrentPerson_PersonChanged(Person person)
        {
            Person = person;
        }
    }
#pragma warning restore IDE0052 // Remove unread private members
}