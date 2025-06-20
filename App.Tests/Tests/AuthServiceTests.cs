using System;
using System.IO;
using Xunit;
using App.Core.Services;
using App.Core.Models;
using System.Threading.Tasks;

namespace App.Tests.Tests
{
    public class AuthServiceTests
    {
        private readonly AuthService _authService;

        public AuthServiceTests()
        {
            _authService = new AuthService();
        }

        [Fact]
        public async Task Should_Register_New_User_Successfully()
        {
            var username = $"testuser_{Guid.NewGuid():N}";
            var password = "testpass123";
            var role = "Admin";
            var alamat = "Jl. Test No. 1";
            var notelp = "08123456789";
            var name = "Test User";

            var user = await _authService.RegisterAsync(username, password, role, alamat, notelp, name);

            Assert.NotNull(user);
            Assert.Equal(username, user.Username);
            Assert.Equal(role, user.Role);
            Assert.Equal(alamat, user.Alamat);
            Assert.Equal(notelp, user.NoTelepon);
            Assert.Equal(name, user.Name);
            Assert.True(user.Id > 0);
            Assert.NotEqual(password, user.Password); // Password should be hashed
        }

        [Fact]
        public async Task Should_Throw_Exception_When_Username_Is_Empty()
        {
            var ex = await Assert.ThrowsAsync<ArgumentException>(async () =>
                await _authService.RegisterAsync("", "password", "User", "Alamat", "123", "Name"));

            Assert.Equal("Username, password, and role cannot be empty.", ex.Message);
        }

        [Fact]
        public async Task Should_Throw_Exception_When_Password_Is_Empty()
        {
            var ex = await Assert.ThrowsAsync<ArgumentException>(async () =>
                await _authService.RegisterAsync("username", "", "User", "Alamat", "123", "Name"));

            Assert.Equal("Username, password, and role cannot be empty.", ex.Message);
        }

        [Fact]
        public async Task Should_Throw_Exception_When_Role_Is_Empty()
        {
            var ex = await Assert.ThrowsAsync<ArgumentException>(async () =>
                await _authService.RegisterAsync("username", "password", "", "Alamat", "123", "Name"));

            Assert.Equal("Username, password, and role cannot be empty.", ex.Message);
        }

        [Fact]
        public async Task Should_Throw_Exception_When_Username_Already_Exists()
        {
            var username = $"duplicateuser_{Guid.NewGuid():N}";

            // Register first user
            await _authService.RegisterAsync(username, "password1", "User", "Alamat1", "123", "Name1");

            // Try to register with same username
            var ex = await Assert.ThrowsAsync<Exception>(async () =>
                await _authService.RegisterAsync(username, "password2", "Admin", "Alamat2", "456", "Name2"));

            Assert.Contains("Username already exists", ex.Message);
        }

        [Fact]
        public async Task Should_Login_With_Valid_Credentials()
        {
            var username = $"loginuser_{Guid.NewGuid():N}";
            var password = "loginpass";

            // Register user first
            await _authService.RegisterAsync(username, password, "User", "Alamat", "123", "Login User");

            // Login with correct credentials
            var loggedInUser = await _authService.LoginAsync(username, password);

            Assert.NotNull(loggedInUser);
            Assert.Equal(username, loggedInUser.Username);
            Assert.Equal("User", loggedInUser.Role);
        }

        [Fact]
        public async Task Should_Throw_Exception_When_Login_With_Invalid_Username()
        {
            var ex = await Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
                await _authService.LoginAsync($"nonexistentuser_{Guid.NewGuid():N}", "password"));

            Assert.Equal("Invalid username or password.", ex.Message);
        }

        [Fact]
        public async Task Should_Throw_Exception_When_Login_With_Invalid_Password()
        {
            var username = $"testuser_{Guid.NewGuid():N}";

            // Register user first
            await _authService.RegisterAsync(username, "correctpassword", "User", "Alamat", "123", "Test User");

            // Try login with wrong password
            var ex = await Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
                await _authService.LoginAsync(username, "wrongpassword"));

            Assert.Equal("Invalid username or password.", ex.Message);
        }

        [Fact]
        public async Task Should_Throw_Exception_When_Login_With_Empty_Username()
        {
            var ex = await Assert.ThrowsAsync<ArgumentException>(async () =>
                await _authService.LoginAsync("", "password"));

            Assert.Equal("Username and password cannot be empty.", ex.Message);
        }

        [Fact]
        public async Task Should_Throw_Exception_When_Login_With_Empty_Password()
        {
            var ex = await Assert.ThrowsAsync<ArgumentException>(async () =>
                await _authService.LoginAsync("username", ""));

            Assert.Equal("Username and password cannot be empty.", ex.Message);
        }

        [Fact]
        public async Task Should_Return_All_Registered_Users()
        {
            var username1 = $"user1_{Guid.NewGuid():N}";
            var username2 = $"user2_{Guid.NewGuid():N}";

            // Register some users
            await _authService.RegisterAsync(username1, "pass1", "User", "Alamat1", "111", "User One");
            await _authService.RegisterAsync(username2, "pass2", "Admin", "Alamat2", "222", "User Two");

            var users = await _authService.GetAllUsersAsync();

            Assert.NotNull(users);
            Assert.True(users.Count >= 2);
            Assert.Contains(users, u => u.Username == username1);
            Assert.Contains(users, u => u.Username == username2);
        }

        [Fact]
        public async Task Should_Generate_Unique_Ids_For_Users()
        {
            var username1 = $"user1_{Guid.NewGuid():N}";
            var username2 = $"user2_{Guid.NewGuid():N}";

            var user1 = await _authService.RegisterAsync(username1, "pass1", "User", "Alamat1", "111", "User One");
            var user2 = await _authService.RegisterAsync(username2, "pass2", "User", "Alamat2", "222", "User Two");

            Assert.NotEqual(user1.Id, user2.Id);
            Assert.True(user2.Id > user1.Id);
        }

        [Fact]
        public async Task Should_Be_Case_Insensitive_For_Username_Check()
        {
            var username = $"TestUser_{Guid.NewGuid():N}";
            await _authService.RegisterAsync(username, "password", "User", "Alamat", "123", "Test User");

            // Try to register with different case
            var ex = await Assert.ThrowsAsync<Exception>(async () =>
                await _authService.RegisterAsync(username.ToLower(), "password", "User", "Alamat", "123", "Test User"));

            Assert.Contains("Username already exists", ex.Message);
        }

        [Fact]
        public async Task Should_Login_Case_Insensitive_Username()
        {
            var username = $"TestUser_{Guid.NewGuid():N}";
            await _authService.RegisterAsync(username, "password", "User", "Alamat", "123", "Test User");

            // Login with different case
            var user = await _authService.LoginAsync(username.ToLower(), "password");

            Assert.NotNull(user);
            Assert.Equal(username, user.Username);
        }
    }
}
