using System;
using Xunit;
using App.Core.Services;
using App.Core.Models;
using System.Threading.Tasks;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace App.Tests.Tests
{
    public class UserCreationServiceTests
    {
        private readonly Mock<IAuthService> _mockAuthService;
        private readonly UserCreationService _userCreationService;

        public UserCreationServiceTests()
        {
            _mockAuthService = new Mock<IAuthService>();
            _userCreationService = new UserCreationService(_mockAuthService.Object);
        }

        [Fact]
        public async Task Should_Create_New_User_Successfully()
        {
            var namaPelapor = "John Doe";
            var expectedUsername = "johndoe";
            var expectedPassword = "johndoe123";

            _mockAuthService.Setup(x => x.GetAllUsersAsync())
                .ReturnsAsync(new List<User>());

            _mockAuthService.Setup(x => x.RegisterAsync(
                expectedUsername, expectedPassword, "civilian", "-", "-", namaPelapor))
                .ReturnsAsync(new User
                {
                    Id = 1,
                    Username = expectedUsername,
                    Name = namaPelapor,
                    Role = "civilian",
                    Alamat = "-",
                    NoTelepon = "-"
                });

            var result = await _userCreationService.CreateNewUserAsync(namaPelapor);

            Assert.NotNull(result);
            Assert.Equal(expectedUsername, result.Username);
            Assert.Equal(namaPelapor, result.Name);
            Assert.Equal("civilian", result.Role);
        }

        [Fact]
        public async Task Should_Handle_Username_With_Spaces()
        {
            var namaPelapor = "Jane Mary Smith";
            var expectedUsername = "janemarysmith";

            _mockAuthService.Setup(x => x.GetAllUsersAsync())
                .ReturnsAsync(new List<User>());

            _mockAuthService.Setup(x => x.RegisterAsync(
                expectedUsername, "janemarysmith123", "civilian", "-", "-", namaPelapor))
                .ReturnsAsync(new User
                {
                    Id = 1,
                    Username = expectedUsername,
                    Name = namaPelapor,
                    Role = "civilian"
                });

            var result = await _userCreationService.CreateNewUserAsync(namaPelapor);

            Assert.Equal(expectedUsername, result.Username);
        }
        [Fact]
        public async Task Should_Handle_Username_With_Special_Characters()
        {
            var namaPelapor = "José María O'Connor-Smith 123";
            var expectedUsername = "josémaríaoconnorsmith123"; // accented characters are preserved as they are letters

            _mockAuthService.Setup(x => x.GetAllUsersAsync())
                .ReturnsAsync(new List<User>());

            _mockAuthService.Setup(x => x.RegisterAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                "civilian",
                "-",
                "-",
                namaPelapor))
                .ReturnsAsync((string username, string password, string role, string alamat, string notelp, string name) =>
                    new User
                    {
                        Id = 1,
                        Username = username,
                        Name = name,
                        Role = role
                    });

            var result = await _userCreationService.CreateNewUserAsync(namaPelapor);

            Assert.Equal(expectedUsername, result.Username);
        }

        [Fact]
        public async Task Should_Add_Counter_When_Username_Already_Exists()
        {
            var namaPelapor = "John Doe";
            var baseUsername = "johndoe";
            var expectedUsername = "johndoe1";

            var existingUsers = new List<User>
            {
                new User { Id = 1, Username = baseUsername, Name = "Existing John" }
            };

            _mockAuthService.Setup(x => x.GetAllUsersAsync())
                .ReturnsAsync(existingUsers);

            _mockAuthService.Setup(x => x.RegisterAsync(
                expectedUsername, expectedUsername + "123", "civilian", "-", "-", namaPelapor))
                .ReturnsAsync(new User
                {
                    Id = 2,
                    Username = expectedUsername,
                    Name = namaPelapor,
                    Role = "civilian"
                });

            var result = await _userCreationService.CreateNewUserAsync(namaPelapor);

            Assert.Equal(expectedUsername, result.Username);
        }
        [Fact]
        public async Task Should_Increment_Counter_Until_Unique_Username_Found()
        {
            var namaPelapor = "John Doe";
            var expectedUsername = "johndoe3";

            var existingUsers = new List<User>
            {
                new User { Id = 1, Username = "johndoe", Name = "John 1" },
                new User { Id = 2, Username = "johndoe1", Name = "John 2" },
                new User { Id = 3, Username = "johndoe2", Name = "John 3" }
            };

            _mockAuthService.Setup(x => x.GetAllUsersAsync())
                .ReturnsAsync(existingUsers);

            _mockAuthService.Setup(x => x.RegisterAsync(
                expectedUsername, expectedUsername + "123", "civilian", "-", "-", namaPelapor))
                .ReturnsAsync(new User
                {
                    Id = 4,
                    Username = expectedUsername,
                    Name = namaPelapor,
                    Role = "civilian"
                });

            var result = await _userCreationService.CreateNewUserAsync(namaPelapor);

            Assert.Equal(expectedUsername, result.Username);
        }

        [Fact]
        public async Task Should_Use_Timestamp_When_Counter_Exceeds_1000()
        {
            var namaPelapor = "John Doe";
            var baseUsername = "johndoe";

            // Create a large list of users to simulate counter > 1000
            var existingUsers = new List<User>();
            for (int i = 0; i <= 1001; i++)
            {
                existingUsers.Add(new User { Id = i, Username = $"{baseUsername}{(i == 0 ? "" : i.ToString())}", Name = $"John {i}" });
            }

            _mockAuthService.Setup(x => x.GetAllUsersAsync())
                .ReturnsAsync(existingUsers);

            _mockAuthService.Setup(x => x.RegisterAsync(
                It.Is<string>(u => u.StartsWith(baseUsername) && u.Length > baseUsername.Length + 4),
                It.IsAny<string>(), "civilian", "-", "-", namaPelapor))
                .ReturnsAsync(new User
                {
                    Id = 1002,
                    Username = $"{baseUsername}{DateTime.Now.Ticks}",
                    Name = namaPelapor,
                    Role = "civilian"
                });

            var result = await _userCreationService.CreateNewUserAsync(namaPelapor);

            Assert.NotNull(result);
            Assert.StartsWith(baseUsername, result.Username);
            Assert.True(result.Username.Length > baseUsername.Length + 4); // Should have timestamp
        }

        [Fact]
        public async Task Should_Retry_When_Username_Collision_Occurs_During_Registration()
        {
            var namaPelapor = "John Doe";
            var baseUsername = "johndoe";
            var retryUsername = "johndoe1";

            _mockAuthService.Setup(x => x.GetAllUsersAsync())
                .ReturnsAsync(new List<User>());

            // First call fails with username collision
            _mockAuthService.SetupSequence(x => x.RegisterAsync(
                baseUsername, baseUsername + "123", "civilian", "-", "-", namaPelapor))
                .ThrowsAsync(new InvalidOperationException("Username already exists"));

            // Second call succeeds
            _mockAuthService.Setup(x => x.RegisterAsync(
                retryUsername, retryUsername + "123", "civilian", "-", "-", namaPelapor))
                .ReturnsAsync(new User
                {
                    Id = 1,
                    Username = retryUsername,
                    Name = namaPelapor,
                    Role = "civilian"
                });

            var result = await _userCreationService.CreateNewUserAsync(namaPelapor);

            Assert.Equal(retryUsername, result.Username);
        }

        [Fact]
        public async Task Should_Throw_Exception_After_Max_Retries()
        {
            var namaPelapor = "John Doe";

            _mockAuthService.Setup(x => x.GetAllUsersAsync())
                .ReturnsAsync(new List<User>());

            // All registration attempts fail
            _mockAuthService.Setup(x => x.RegisterAsync(
                It.IsAny<string>(), It.IsAny<string>(), "civilian", "-", "-", namaPelapor))
                .ThrowsAsync(new InvalidOperationException("Username already exists"));

            var ex = await Assert.ThrowsAsync<Exception>(async () =>
                await _userCreationService.CreateNewUserAsync(namaPelapor));

            Assert.Contains("Gagal membuat user baru setelah 3 percobaan", ex.Message);
        }
        [Fact]
        public async Task Should_Throw_Exception_When_NamaPelapor_Is_Empty()
        {
            var ex = await Assert.ThrowsAsync<Exception>(async () =>
                await _userCreationService.CreateNewUserAsync(""));

            Assert.Contains("Nama pelapor tidak boleh kosong", ex.Message);
        }
        [Fact]
        public async Task Should_Throw_Exception_When_NamaPelapor_Is_Whitespace()
        {
            var ex = await Assert.ThrowsAsync<Exception>(async () =>
                await _userCreationService.CreateNewUserAsync("   "));

            Assert.Contains("Nama pelapor tidak boleh kosong", ex.Message);
        }
        [Fact]
        public async Task Should_Throw_Exception_When_NamaPelapor_Too_Short()
        {
            var ex = await Assert.ThrowsAsync<Exception>(async () =>
                await _userCreationService.CreateNewUserAsync("Jo"));

            Assert.Contains("Nama pelapor harus minimal 3 karakter", ex.Message);
        }
        [Fact]
        public async Task Should_Handle_Case_Insensitive_Username_Check()
        {
            var namaPelapor = "John Doe";
            var expectedUsername = "johndoe1";

            var existingUsers = new List<User>
            {
                new User { Id = 1, Username = "JohnDoe", Name = "Existing John" } // Different case
            };

            _mockAuthService.Setup(x => x.GetAllUsersAsync())
                .ReturnsAsync(existingUsers);

            _mockAuthService.Setup(x => x.RegisterAsync(
                expectedUsername, expectedUsername + "123", "civilian", "-", "-", namaPelapor))
                .ReturnsAsync(new User
                {
                    Id = 2,
                    Username = expectedUsername,
                    Name = namaPelapor,
                    Role = "civilian"
                });

            var result = await _userCreationService.CreateNewUserAsync(namaPelapor);

            Assert.Equal(expectedUsername, result.Username);
        }

        [Fact]
        public async Task Should_Get_All_Users_Successfully()
        {
            var expectedUsers = new List<User>
            {
                new User { Id = 1, Username = "user1", Name = "User One" },
                new User { Id = 2, Username = "user2", Name = "User Two" }
            };

            _mockAuthService.Setup(x => x.GetAllUsersAsync())
                .ReturnsAsync(expectedUsers);

            var result = await _userCreationService.GetAllUsersAsync();

            Assert.Equal(expectedUsers, result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task Should_Get_Total_Users_Count_Successfully()
        {
            var users = new List<User>
            {
                new User { Id = 1, Username = "user1", Name = "User One" },
                new User { Id = 2, Username = "user2", Name = "User Two" },
                new User { Id = 3, Username = "user3", Name = "User Three" }
            };

            _mockAuthService.Setup(x => x.GetAllUsersAsync())
                .ReturnsAsync(users);

            var result = await _userCreationService.GetTotalUsersCountAsync();

            Assert.Equal(3, result);
        }

        [Fact]
        public async Task Should_Return_Zero_Count_When_No_Users()
        {
            _mockAuthService.Setup(x => x.GetAllUsersAsync())
                .ReturnsAsync(new List<User>());

            var result = await _userCreationService.GetTotalUsersCountAsync();

            Assert.Equal(0, result);
        }

        [Fact]
        public async Task Should_Throw_Exception_When_RegisterAsync_Returns_Null()
        {
            var namaPelapor = "John Doe";

            _mockAuthService.Setup(x => x.GetAllUsersAsync())
                .ReturnsAsync(new List<User>());

            _mockAuthService.Setup(x => x.RegisterAsync(
                It.IsAny<string>(), It.IsAny<string>(), "civilian", "-", "-", namaPelapor))
                .ReturnsAsync((User)null!);

            var ex = await Assert.ThrowsAsync<Exception>(async () =>
                await _userCreationService.CreateNewUserAsync(namaPelapor));

            Assert.Contains("Gagal membuat user baru karena alasan yang tidak diketahui", ex.Message);
        }

        [Fact]
        public async Task Should_Wrap_Unexpected_Exceptions()
        {
            var namaPelapor = "John Doe";

            _mockAuthService.Setup(x => x.GetAllUsersAsync())
                .ThrowsAsync(new Exception("Unexpected database error"));

            var ex = await Assert.ThrowsAsync<Exception>(async () =>
                await _userCreationService.CreateNewUserAsync(namaPelapor));

            Assert.Contains("Gagal membuat user baru: Unexpected database error", ex.Message);
        }
    }
}
