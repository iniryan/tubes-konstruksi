using App.Core.Models;
using System.Threading.Tasks;

namespace App.Core.Services
{
    public interface IAuthService
    {
        Task<User> RegisterAsync(string username, string password, string role, string alamat, string notelp, string name);
        Task<User> LoginAsync(string username, string password);
    }
}