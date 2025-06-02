using System.Data.SqlClient;
using EmpSkills.Models;
using Microsoft.Extensions.Configuration;

namespace EmpSkills.Data
{
    public class EmployeeSkillRepository
    {
        private readonly string _connectionString;

        public EmployeeSkillRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }


        public IEnumerable<EmployeeSkill> GetEmployeeSkills(int id)
        {
            var employeeSKills = new List<EmployeeSkill>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("SELECT s.Name as SkillName, es.* FROM EmployeeSkills es join Skills s on es.skillId=s.Id WHERE es.EmployeeId = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employeeSKills.Add(new EmployeeSkill
                            {
                                EmployeeId = (int)reader["EmployeeId"],
                                SkillId = (int)reader["SkillId"],
                                ExpertLevel = reader["ExpertLevel"].ToString(),
                                YearsOfExperience = (int)reader["YearsOfExperience"],
                                SkillName = reader["SkillName"].ToString()

                            });
                        }
                    }
                }
            }

            return employeeSKills;
        }


        public void AddEmployeeSkill(EmployeeSkill employeeSkill)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(
                "delete from EmployeeSkills where EmployeeId=@EmployeeId and SkillId=@SkillId;" +
                "INSERT INTO EmployeeSkills (EmployeeId, SkillId, YearsOfExperience, ExpertLevel) " +
                "VALUES (@EmployeeId, @SkillId, @YearsOfExperience, @ExpertLevel)", connection);

            command.Parameters.AddWithValue("@EmployeeId", employeeSkill.EmployeeId);
            command.Parameters.AddWithValue("@SkillId", employeeSkill.SkillId);
            command.Parameters.AddWithValue("@YearsOfExperience", employeeSkill.YearsOfExperience);
            command.Parameters.AddWithValue("@ExpertLevel", employeeSkill.ExpertLevel);

            connection.Open();
            command.ExecuteNonQuery();
        }

        public void DeleteEmployeeSkill(int employeeId, int skillId)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(
                "DELETE FROM EmployeeSkills WHERE EmployeeId = @EmployeeId AND SkillId = @SkillId", connection);

            command.Parameters.AddWithValue("@EmployeeId", employeeId);
            command.Parameters.AddWithValue("@SkillId", skillId);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}
