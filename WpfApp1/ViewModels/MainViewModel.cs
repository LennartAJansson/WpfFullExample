using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

using System;
using System.Threading.Tasks;

using WpfApp1.Views;

namespace WpfApp1.ViewModels
{
#pragma warning disable IDE0052 // Remove unread private members

    public class MainViewModel : ObservableObject
    {
        private readonly ILogger<MainViewModel> logger;
        private readonly IServiceProvider serviceProvider;

        public object SelectedLeftView { get => selectedLeftView; set => SetProperty(ref selectedLeftView, value); }

        private object selectedLeftView;

        public object SelectedRightView { get => selectedRightView; set => SetProperty(ref selectedRightView, value); }

        private object selectedRightView;

        public string Status { get => status; set => SetProperty(ref status, value); }

        private string status;

        public AsyncRelayCommand PeopleViewCommand { get; }

        public AsyncRelayCommand PersonViewCommand { get; }
        public AsyncRelayCommand GraphViewCommand { get; }

        public MainViewModel(ILogger<MainViewModel> logger, IServiceProvider serviceProvider)
        {
            this.logger = logger;
            this.serviceProvider = serviceProvider;
            PeopleViewCommand = new AsyncRelayCommand(PeopleViewShow);
            PersonViewCommand = new AsyncRelayCommand(PersonViewShow);
            GraphViewCommand = new AsyncRelayCommand(GraphViewShow);
        }

        private Task PeopleViewShow()
        {
            SelectedLeftView = serviceProvider.GetRequiredService<PeopleView>();
            Status = $"Opened {nameof(SelectedLeftView)}";

            return Task.CompletedTask;
        }

        private Task PersonViewShow()
        {
            SelectedRightView = serviceProvider.GetRequiredService<PersonView>();
            Status = $"Opened {nameof(SelectedRightView)}";

            return Task.CompletedTask;
        }
        private Task GraphViewShow()
        {
            SelectedRightView = serviceProvider.GetRequiredService<GraphView>();
            Status = $"Opened {nameof(SelectedRightView)}";

            return Task.CompletedTask;
        }
    }
#pragma warning restore IDE0052 // Remove unread private members
}