using Xunit;
using PengaduanKeamananCLI.Services;
using PengaduanKeamananCLI.Database;

namespace PengaduanKeamananCLI.Tests
{
    public class AuthServiceTests
    {
        public AuthServiceTests()
        {
            // Pastikan database diinisialisasi sebelum test
            DatabaseHelper.InitDatabase();
        }

        [Fact]
        public void Register_NewUser_ReturnsTrue()
        {
            string username = "testuser1";
            string password = "testpass1";
            // Hapus user jika sudah ada
            using (var conn = new Microsoft.Data.Sqlite.SqliteConnection(PengaduanKeamananCLI.Database.DatabaseHelper.ConnString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM users WHERE username = @u";
                cmd.Parameters.AddWithValue("@u", username);
                cmd.ExecuteNonQuery();
            }
            var result = AuthService.Register(username, password);
            Assert.True(result);
        }

        [Fact]
        public void Register_DuplicateUser_ReturnsFalse()
        {
            string username = "testuser2";
            string password = "testpass2";
            AuthService.Register(username, password); // register pertama
            var result = AuthService.Register(username, password); // register kedua (duplikat)
            Assert.False(result);
        }

        [Fact]
        public void Login_ValidUser_ReturnsUser()
        {
            string username = "testuser3";
            string password = "testpass3";
            AuthService.Register(username, password);
            var user = AuthService.Login(username, password);
            Assert.NotNull(user);
            Assert.Equal(username, user!.Username);
        }

        [Fact]
        public void Login_InvalidUser_ReturnsNull()
        {
            var user = AuthService.Login("notexist", "wrongpass");
            Assert.Null(user);
        }

        [Fact]
        public void Login_AdminUser_ReturnsAdmin()
        {
            var user = AuthService.Login("admin", "admin123");
            Assert.NotNull(user);
            Assert.Equal("admin", user!.Role);
        }
    }
} 