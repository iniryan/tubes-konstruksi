namespace App.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Alamat { get; set; } = string.Empty;
        public string NoTelepon { get; set; } = string.Empty;
    }
}