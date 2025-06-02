using EmpSkills.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace EmpSkills.Data
{
    public class SkillRepository
    {
        private readonly string _connectionString;

        public SkillRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

         public IEnumerable<Skill> GetAllSkills()
        {
            var skills = new List<Skill>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("SELECT * FROM Skills", connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            skills.Add(new Skill
                            {
                                Id = (int)reader["Id"],
                                Name = reader["Name"].ToString(),
                            });
                        }
                    }
                }
            }

            return skills;
        }

        public void AddSkill(Skill skill)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("INSERT INTO Skills (Name) VALUES (@Name)", connection);
            command.Parameters.AddWithValue("@Name", skill.Name);

            connection.Open();
            command.ExecuteNonQuery();
        }

        public void DeleteSkill(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("DELETE FROM EmployeeSkills WHERE skillId = @Id ; DELETE FROM Skills WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}
