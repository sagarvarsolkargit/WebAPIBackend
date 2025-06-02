using EmpSkills.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace EmpSkills.Data
{
    public class SearchRepository
    {
        private readonly string _connectionString;

        public SearchRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<Employee>> SearchEmployeesAsync(EmployeeSearchRequest request)
        {
            var employees = new List<Employee>();
            var query = @"
            SELECT DISTINCT e.id, e.name, e.designation, e.email,e.dateOfJoining
            FROM employees e
            LEFT JOIN employeeSkills es ON e.id = es.employeeid
            WHERE 1=1";

            var parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(request.Name))
            {
                query += " AND e.name LIKE @name";
                parameters.Add(new SqlParameter("@name", "%" + request.Name + "%"));
            }

            if (!string.IsNullOrWhiteSpace( request.ExpertLevel ))
            {
                query += " AND es.expertlevel = @expertLevel";
                parameters.Add(new SqlParameter("@expertLevel", request.ExpertLevel));
            }

            if (request.SkillIds != null && request.SkillIds.Any())
            {
                var skillParams = new List<string>();
                for (int i = 0; i < request.SkillIds.Count; i++)
                {
                    string paramName = "@skillId" + i;
                    skillParams.Add(paramName);
                    parameters.Add(new SqlParameter(paramName, request.SkillIds[i]));
                }

                query += $" AND es.skillid IN ({string.Join(",", skillParams)})";
            }

            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            employees.Add(new Employee
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Designation = reader.GetString(2),
                                Email = reader.GetString(3),
                                DateOfJoining= reader.GetDateTime(4)
                            });
                        }
                    }
                }
            }

            return employees;
        }
    }

}
