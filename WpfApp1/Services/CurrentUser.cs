
using System;
using System.Threading;
using System.Threading.Tasks;

using WpfApp1.Models;

namespace WpfApp1.Services
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IUserService userService;
        private readonly Timer refreshTimer;

        public event UserChangedDelegate UserChanged;
        public int MyProperty { get; set; }
        public User User
        {
            get => user;
            set
            {
                user = value;
                UserChanged?.Invoke(value);
            }
        }
        private User user;

        public CurrentUser(IUserService userService)
        {
            this.userService = userService;
            refreshTimer = new Timer(DoRefresh, null, TimeSpan.Zero, TimeSpan.FromMinutes(30)); //TODO: Maybe from config?
        }

        public async Task<bool> LoginAsync()
        {
            User = await userService.LoginAsync(User);
            //Sets User.IsValid, User.Refreshed, User.Token and User.RefreshToken
            return User.IsValid;
        }

        public async Task<bool> LogoutAsync()
        {
            User = await userService.LogoutAsync(User);
            //Sets User.IsValid, User.Refreshed, User.Token and User.RefreshToken
            return User.IsValid;
        }

        public async Task<bool> ChangePasswordAsync(string newPassword)
        {
            User = await userService.ChangePasswordAsync(User, newPassword);
            //Sets User.IsValid, User.Refreshed, User.Token and User.RefreshToken
            return User.IsValid;
        }
        private void DoRefresh(object state)
        {
            User = userService.RefreshAsync(User).Result;
            //Sets User.IsValid, User.Refreshed, User.Token and User.RefreshToken
            //When User is set it will automatically trigger the event for anyone that subscribes
            //Meaning that if the Token or IsValid for any reason is invalid all of a sudden,
            //then a notification will be sent about it to all
        }
    }
}

