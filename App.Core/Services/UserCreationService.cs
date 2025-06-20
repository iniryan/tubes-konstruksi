using App.Core.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace App.Core.Services
{
    public class UserCreationService
    {
        private readonly IAuthService _authService;

        public UserCreationService(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<User> CreateNewUserAsync(string namaPelapor)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(namaPelapor))
                {
                    throw new ArgumentException("Nama pelapor tidak boleh kosong.");
                }
                if (namaPelapor.Length < 3)
                {
                    throw new ArgumentException("Nama pelapor harus minimal 3 karakter.");
                }

                string username = string.Join("", namaPelapor.ToLower()
                    .Where(c => char.IsLetterOrDigit(c) || c == ' ')
                    .ToArray())
                    .Replace(" ", "");

                var existingUsers = await _authService.GetAllUsersAsync();

                string originalUsername = username;
                int counter = 0;
                while (existingUsers.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
                {
                    counter++;
                    username = $"{originalUsername}{counter}";

                    if (counter > 1000)
                    {
                        username = $"{originalUsername}{DateTime.Now.Ticks}";
                        break;
                    }
                }

                string password = username + "123";

                string role = "civilian";
                string alamat = "-";
                string notelp = "-";
                int maxRetries = 3;
                int retryCount = 0;
                User? newUser = null;

                while (retryCount < maxRetries)
                {
                    try
                    {
                        newUser = await _authService.RegisterAsync(username, password, role, alamat, notelp, namaPelapor);
                        break;
                    }
                    catch (InvalidOperationException ex) when (ex.Message.Contains("Username already exists"))
                    {
                        retryCount++;
                        if (retryCount < maxRetries)
                        {
                            counter++;
                            username = $"{originalUsername}{counter}";
                            password = username + "123";
                        }
                        else
                        {
                            throw new Exception($"Gagal membuat user baru setelah {maxRetries} percobaan. Username terus bertabrakan.");
                        }
                    }
                }

                if (newUser == null)
                {
                    throw new Exception("Gagal membuat user baru karena alasan yang tidak diketahui.");
                }

                return newUser;
            }
            catch (Exception ex)
            {
                throw new Exception($"Gagal membuat user baru: {ex.Message}");
            }
        }

        // READ - ambil semua pengguna
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _authService.GetAllUsersAsync();
        }

        public async Task<int> GetTotalUsersCountAsync()
        {
            var users = await _authService.GetAllUsersAsync();
            return users.Count;
        }
    }
}
