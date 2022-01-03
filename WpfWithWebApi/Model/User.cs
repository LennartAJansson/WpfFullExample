
using System;

using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace WpfWithWebApi.Model
{
    public class User : ObservableObject
    {
        public int Id { get => id; set => SetProperty(ref id, value); }
        private int id;

        public string Username { get => username; set => SetProperty(ref username, value); }
        private string username;

        public string Email { get => email; set => SetProperty(ref email, value); }
        private string email;

        public string Role { get => role; set => SetProperty(ref role, value); }
        private string role;

        public string Token { get => token; set => SetProperty(ref token, value); }
        private string token;

        public string RefreshToken { get => refreshToken; set => SetProperty(ref refreshToken, value); }
        private string refreshToken;

        public bool IsValid { get => isValid; set => SetProperty(ref isValid, value); }
        private bool isValid;

        public DateTime Refreshed { get => refreshed; set => SetProperty(ref refreshed, value); }
        private DateTime refreshed;

    }
}
