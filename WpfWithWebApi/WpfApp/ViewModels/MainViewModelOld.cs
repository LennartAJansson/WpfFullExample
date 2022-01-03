using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

using WpfWithWebApi.Model;
using WpfWithWebApi.Wpf.Services;

namespace WpfWithWebApi.Wpf.ViewModels
{
    public class MainViewModelOld : ObservableObject
    {
        private readonly ILogger<MainViewModelOld> logger;
        private readonly IPersonService personService;

        public IEnumerable<Person> People
        {
            get => people;
            set => SetProperty(ref people, value);
        }

        private IEnumerable<Person> people;

        public Person SelectedPerson
        {
            get => selectedPerson;
            set => SetProperty(ref selectedPerson, value);
        }

        private Person selectedPerson;

        public Task MyTask
        {
            get => myTask;
            private set => SetPropertyAndNotifyOnCompletion(ref myTask, value);
        }

        private TaskNotifier myTask;

        public RelayCommand GetCommand { get; }

        public MainViewModelOld(ILogger<MainViewModelOld> logger, IPersonService personService)
        {
            this.logger = logger;
            this.personService = personService;
            GetCommand = new RelayCommand(async () => await GetAllAsync());

            //TODO Maybe use messaging instead to initiate the ViewModels?
            GetCommand.Execute(null);
        }

        public async Task GetAllAsync()
        {
            logger.LogInformation("Calling personService");
            People = await personService.GetAllPeopleAsync();

            //Person person = await personService.GetPersonAsync(1);
        }

        public void ReloadTask()
        {
            logger.LogDebug("Calling ReloadTask");
            MyTask = Task.Delay(3000);
        }
    }
}