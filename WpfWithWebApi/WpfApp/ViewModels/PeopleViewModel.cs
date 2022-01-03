using System.Collections.ObjectModel;

using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;

using WpfWithWebApi.Wpf.Models;
using WpfWithWebApi.Wpf.Services;

namespace WpfWithWebApi.Wpf.ViewModels
{
#pragma warning disable IDE0052 // Remove unread private members
    //#pragma warning disable CS0414 // Remove unread private members

    public class PeopleViewModel : ObservableObject
    {
        public ObservableCollection<Person> People
        {
            get => people;
            set => SetProperty(ref people, value);
        }

        private ObservableCollection<Person> people;

        public Person SelectedPerson
        {
            get => selectedPerson;
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
            People = new ObservableCollection<Person>(service.GetPeople().Result);
        }
    }
#pragma warning restore IDE0052 // Remove unread private members
    //#pragma warning restore CS0414 // Remove unread private members
}