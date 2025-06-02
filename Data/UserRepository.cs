using System.Data.SqlClient;
using EmpSkills.Models;
using Microsoft.Extensions.Configuration;

namespace EmpSkills.Data
{
    public class UserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public User ValidateUser(string username, string password)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("SELECT * FROM Users WHERE Username = @Username AND Password = @Password", conn);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);

            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new User
                {
                    Id = (int)reader["Id"],
                    Username = reader["Username"].ToString(),
                    DisplayName = reader["DisplayName"].ToString()
                };
            }

            return null;
        }
    }
}
