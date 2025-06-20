using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using App.Core.Models;
using App.Core.Services;

namespace App.Benchmark.PerformanceTests
{
    [MemoryDiagnoser]
    [SimpleJob(warmupCount: 2, iterationCount: 5)]
    public class AuthServicePerformanceTests
    {
        private AuthService _authService = null!;
        private List<User> _users = null!;

        [GlobalSetup]
        public async Task Setup()
        {
            _authService = new AuthService();
            _users = new List<User>(200);

            for (int i = 0; i < 200; i++)
            {
                try
                {
                    string username = "benchuser" + i;
                    string password = "password" + i;
                    string name = "Benchmark User " + i;
                    string role = (i % 3 == 0) ? "admin" : (i % 3 == 1) ? "staff" : "civilian";

                    var user = await _authService.RegisterAsync(username, password, role, "Alamat " + i, "08123456789" + i, name);
                    _users.Add(user);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating user {i}: {ex.Message}");
                }
            }

            Console.WriteLine("Auth Service Setup completed. Total Users: " + _users.Count);
        }

        [Benchmark]
        public async Task RegisterUser_Performance()
        {
            for (int i = 0; i < 20; i++)
            {
                try
                {
                    string username = "newbenchuser" + DateTime.Now.Ticks + i;
                    string password = "newpassword" + i;
                    string name = "New Benchmark User " + i;
                    string role = (i % 2 == 0) ? "staff" : "civilian";

                    await _authService.RegisterAsync(username, password, role, "New Alamat " + i, "08987654321" + i, name);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in RegisterUser_Performance {i}: {ex.Message}");
                }
            }
        }

        [Benchmark]
        public async Task LoginUser_Performance()
        {
            // Test login for first 50 users
            foreach (var user in _users.Take(50))
            {
                try
                {
                    string expectedPassword = user.Username.Replace("benchuser", "password");
                    var loggedInUser = await _authService.LoginAsync(user.Username, expectedPassword);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error logging in user {user.Username}: {ex.Message}");
                }
            }
        }

        [Benchmark]
        public async Task GetAllUsers_Performance()
        {
            for (int i = 0; i < 10; i++)
            {
                var allUsers = await _authService.GetAllUsersAsync();
            }
        }

        [Benchmark]
        public async Task MixedAuthOperations_Performance()
        {
            // Simulate mixed auth operations
            var tasks = new List<Task>();

            // Get all users
            tasks.Add(_authService.GetAllUsersAsync());

            // Try login with some users
            foreach (var user in _users.Take(10))
            {
                string expectedPassword = user.Username.Replace("benchuser", "password");
                tasks.Add(_authService.LoginAsync(user.Username, expectedPassword));
            }

            // Register a few new users
            for (int i = 0; i < 5; i++)
            {
                string username = "mixeduser" + DateTime.Now.Ticks + i;
                tasks.Add(_authService.RegisterAsync(username, "mixedpass" + i, "civilian", "Mixed Alamat", "081234567890", "Mixed User " + i));
            }

            try
            {
                await Task.WhenAll(tasks);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in MixedAuthOperations_Performance: {ex.Message}");
            }
        }
    }
}
