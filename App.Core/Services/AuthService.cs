using App.Core.Models;
using App.Core.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly string _filePath;
        private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        private const int MaxRetries = 3;
        private const int RetryDelayMs = 100;

        public AuthService()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\.."));
            _filePath = Path.GetFullPath(Path.Combine(projectDirectory, "App.Core", "Database", "User.json"));

            InitializeUserFile().Wait();
        }

        private async Task InitializeUserFile()
        {
            try
            {
                string? directoryPath = Path.GetDirectoryName(_filePath);
                if (directoryPath != null)
                {
                    Directory.CreateDirectory(directoryPath);

                    if (!File.Exists(_filePath))
                    {
                        await JsonUtils.WriteDataAsync(_filePath, new List<User>());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to initialize user file: {ex.Message}");
            }
        }

        public async Task<User> RegisterAsync(string username, string password, string role, string alamat, string notelp, string name)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(role))
            {
                throw new ArgumentException("Username, password, and role cannot be empty.");
            }

            int retryCount = 0;
            while (retryCount < MaxRetries)
            {
                try
                {
                    await _semaphore.WaitAsync();
                    var users = await JsonUtils.ReadDataAsync<User>(_filePath);

                    if (users.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
                    {
                        throw new InvalidOperationException("Username already exists.");
                    }

                    var user = new User
                    {
                        Id = users.Count > 0 ? users.Max(u => u.Id) + 1 : 1,
                        Username = username,
                        Password = HashPassword(password),
                        Role = role,
                        Alamat = alamat,
                        NoTelepon = notelp,
                        Name = name,
                    };

                    users.Add(user);
                    await JsonUtils.WriteDataAsync(_filePath, users);
                    return user;
                }
                catch (IOException) when (retryCount < MaxRetries - 1)
                {
                    retryCount++;
                    await Task.Delay(RetryDelayMs * retryCount);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed to register user: {ex.Message}");
                }
                finally
                {
                    _semaphore.Release();
                }
            }
            throw new Exception("Failed to register user after multiple attempts");
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Username and password cannot be empty.");
            }

            try
            {
                await _semaphore.WaitAsync();
                var users = await JsonUtils.ReadDataAsync<User>(_filePath);
                var user = users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

                if (user == null || !VerifyPassword(password, user.Password))
                {
                    throw new UnauthorizedAccessException("Invalid username or password.");
                }

                return user;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            try
            {
                await _semaphore.WaitAsync();
                return await JsonUtils.ReadDataAsync<User>(_filePath);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            return HashPassword(password) == hashedPassword;
        }
    }
}