namespace EmpSkills.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } // Store as plaintext for demo only
        public string DisplayName { get; set; }
    }
}
