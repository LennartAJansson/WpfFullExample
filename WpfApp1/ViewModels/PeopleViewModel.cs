using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;

using System.Collections.Generic;

using WpfApp1.Models;
using WpfApp1.Services;

namespace WpfApp1.ViewModels
{
#pragma warning disable IDE0052 // Remove unread private members
    //#pragma warning disable CS0414 // Remove unread private members

    public class PeopleViewModel : ObservableObject
    {
        public IEnumerable<Person> People
        {
            get { return people; }
            set { SetProperty(ref people, value); }
        }

        private IEnumerable<Person> people;

        public Person SelectedPerson
        {
            get { return selectedPerson; }
            set { SetProperty(ref selectedPerson, value); currentPerson.Person = value; }
        }

        private Person selectedPerson;

        private readonly ILogger<MainViewModel> logger;
        private readonly IPeopleService service;
        private readonly ICurrentPerson currentPerson;

        public PeopleViewModel(ILogger<MainViewModel> logger, IPeopleService service, ICurrentPerson currentPerson)
        {
            this.logger = logger;
            this.service = service;
            this.currentPerson = currentPerson;
            this.currentPerson.PersonChanged += CurrentPerson_PersonChanged;
            People = service.GetPeople().Result;
        }

        private void CurrentPerson_PersonChanged(Person person) => SelectedPerson = person;
    }

#pragma warning restore IDE0052 // Remove unread private members
    //#pragma warning restore CS0414 // Remove unread private members
}