using System.Threading.Tasks;

using WpfWithWebApi.Wpf.Models;

namespace WpfWithWebApi.Wpf.Services
{
    public delegate void UserChangedDelegate(User user);
    public interface ICurrentUser
    {
        event UserChangedDelegate UserChanged;
        User User { get; set; }
        Task<bool> LoginAsync();
        Task<bool> LogoutAsync();
        Task<bool> ChangePasswordAsync(string newPassword);
    }
}

