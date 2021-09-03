using System.Threading.Tasks;

using WpfApp1.Models;

namespace WpfApp1.Services
{
    public interface IUserService
    {
        Task<User> LoginAsync(User user);
        Task<User> LogoutAsync(User user);
        Task<User> ChangePasswordAsync(User user, string newPassword);
        Task<User> RefreshAsync(User user);
    }
}

