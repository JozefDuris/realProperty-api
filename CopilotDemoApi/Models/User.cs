namespace CopilotDemoApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; } // e.g., "Admin", "User"
    }
}
