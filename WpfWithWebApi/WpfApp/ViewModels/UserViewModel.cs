using System;
using System.Threading.Tasks;

using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

using WpfWithWebApi.Wpf.Models;
using WpfWithWebApi.Wpf.Services;

namespace WpfWithWebApi.Wpf.ViewModels
{
    public class UserViewModel : ObservableObject
    {
        private readonly ICurrentUser currentUser;

        public User User { get => user; set => SetProperty(ref user, value); }
        private User user;

        public bool ShowCreate { get => showCreate; set => SetProperty(ref showCreate, value); }
        private bool showCreate;

        public bool ShowLogin { get => showLogin; set => SetProperty(ref showLogin, value); }
        private bool showLogin;

        public bool ShowChange { get => showChange; set => SetProperty(ref showChange, value); }
        private bool showChange;

        public bool ShowReset { get => showReset; set => SetProperty(ref showReset, value); }
        private bool showReset;

        public bool ShowLogout { get => showLogout; set => SetProperty(ref showLogout, value); }
        private bool showLogout;

        public AsyncRelayCommand CreateUserCommand { get; }
        public AsyncRelayCommand LoginUserCommand { get; }
        public AsyncRelayCommand ChangeUserCommand { get; }
        public AsyncRelayCommand ResetUserCommand { get; }
        public AsyncRelayCommand LogoutUserCommand { get; }

        public UserViewModel(ICurrentUser currentUser)
        {
            this.currentUser = currentUser;
            User = this.currentUser.User;
            this.currentUser.UserChanged += CurrentUser_UserChanged;
            CreateUserCommand = new AsyncRelayCommand(CreateUser, () => ShowCreate);
            LoginUserCommand = new AsyncRelayCommand(LoginUser, () => ShowLogin);
            ChangeUserCommand = new AsyncRelayCommand(ChangeUser, () => ShowChange);
            ResetUserCommand = new AsyncRelayCommand(ResetUser, () => ShowReset);
            LogoutUserCommand = new AsyncRelayCommand(LogoutUser, () => ShowLogout);
        }

        private Task CreateUser() => throw new NotImplementedException();
        private Task LoginUser() => throw new NotImplementedException();
        private Task ChangeUser() => throw new NotImplementedException();
        private Task ResetUser() => throw new NotImplementedException();
        private Task LogoutUser() => throw new NotImplementedException();
        private void CurrentUser_UserChanged(User user) => User = user;
    }
}
