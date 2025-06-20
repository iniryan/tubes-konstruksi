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
    public class UserCreationServicePerformanceTests
    {
        private UserCreationService _userCreationService = null!;
        private AuthService _authService = null!;
        private List<User> _createdUsers = null!;

        [GlobalSetup]
        public async Task Setup()
        {
            _authService = new AuthService();
            _userCreationService = new UserCreationService(_authService);
            _createdUsers = new List<User>(100);

            // Pre-create some users to test collision handling
            for (int i = 0; i < 50; i++)
            {
                try
                {
                    string namaPelapor = "Setup User " + i;
                    var user = await _userCreationService.CreateNewUserAsync(namaPelapor);
                    _createdUsers.Add(user);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in setup for user {i}: {ex.Message}");
                }
            }

            Console.WriteLine("User Creation Service Setup completed. Total Users: " + _createdUsers.Count);
        }

        [Benchmark]
        public async Task CreateNewUser_Performance()
        {
            for (int i = 0; i < 20; i++)
            {
                try
                {
                    string namaPelapor = "Benchmark User " + DateTime.Now.Ticks + i;
                    await _userCreationService.CreateNewUserAsync(namaPelapor);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating new user {i}: {ex.Message}");
                }
            }
        }

        [Benchmark]
        public async Task CreateUserWithSpecialCharacters_Performance()
        {
            var specialNames = new[]
            {
                "José María",
                "François O'Connor",
                "李明华",
                "محمد العربي",
                "Müller-Schmidt",
                "Van der Berg",
                "D'Angelo Giuseppe",
                "Pérez-Rodríguez",
                "O'Brien McDonald",
                "Jean-Baptiste"
            };

            foreach (var name in specialNames)
            {
                try
                {
                    string uniqueName = name + " " + DateTime.Now.Ticks;
                    await _userCreationService.CreateNewUserAsync(uniqueName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating user with special chars {name}: {ex.Message}");
                }
            }
        }

        [Benchmark]
        public async Task CreateDuplicateUsernames_Performance()
        {
            // Test username collision handling
            string baseName = "Duplicate User Test";

            for (int i = 0; i < 15; i++)
            {
                try
                {
                    // This should trigger username collision and auto-increment
                    await _userCreationService.CreateNewUserAsync(baseName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating duplicate user {i}: {ex.Message}");
                }
            }
        }

        [Benchmark]
        public async Task GetAllUsers_Performance()
        {
            for (int i = 0; i < 10; i++)
            {
                var users = await _userCreationService.GetAllUsersAsync();
            }
        }

        [Benchmark]
        public async Task GetTotalUsersCount_Performance()
        {
            for (int i = 0; i < 20; i++)
            {
                var count = await _userCreationService.GetTotalUsersCountAsync();
            }
        }

        [Benchmark]
        public async Task MixedUserCreationOperations_Performance()
        {
            var tasks = new List<Task>();

            // Create some users
            for (int i = 0; i < 5; i++)
            {
                string namaPelapor = "Mixed Operation User " + DateTime.Now.Ticks + i;
                tasks.Add(_userCreationService.CreateNewUserAsync(namaPelapor));
            }

            // Get user counts
            for (int i = 0; i < 3; i++)
            {
                tasks.Add(_userCreationService.GetTotalUsersCountAsync().ContinueWith(t => (object)t.Result));
            }

            // Get all users
            tasks.Add(_userCreationService.GetAllUsersAsync().ContinueWith(t => (object)t.Result));

            try
            {
                await Task.WhenAll(tasks);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in MixedUserCreationOperations_Performance: {ex.Message}");
            }
        }
    }
}
