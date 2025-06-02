using EmpSkills.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EmpSkills.Data
{
    public class EmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            var employees = new List<Employee>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("SELECT * FROM Employees", connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employees.Add(new Employee
                            {
                                Id = (int)reader["Id"],
                                Name = reader["Name"].ToString(),
                                DateOfJoining = (DateTime)reader["DateOfJoining"],
                                Email = reader["Email"].ToString(),
                                Designation = reader["Designation"].ToString()
                            });
                        }
                    }
                }
            }

            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            Employee employee = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("SELECT * FROM Employees WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            employee = new Employee
                            {
                                Id = (int)reader["Id"],
                                Name = reader["Name"].ToString(),
                                DateOfJoining = (DateTime)reader["DateOfJoining"],
                                Email = reader["Email"].ToString(),
                                Designation = reader["Designation"].ToString()
                            };
                        }
                    }
                }
            }

            return employee;
        }

        public void AddEmployee(Employee employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("INSERT INTO Employees (Name, DateOfJoining, Email, Designation) VALUES (@Name, @DateOfJoining, @Email, @Designation)", connection))
                {
                    command.Parameters.AddWithValue("@Name", employee.Name);
                    command.Parameters.AddWithValue("@DateOfJoining", employee.DateOfJoining);
                    command.Parameters.AddWithValue("@Email", employee.Email);
                    command.Parameters.AddWithValue("@Designation", employee.Designation);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("UPDATE Employees SET Name = @Name, DateOfJoining = @DateOfJoining, Email = @Email, Designation = @Designation WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", employee.Id);
                    command.Parameters.AddWithValue("@Name", employee.Name);
                    command.Parameters.AddWithValue("@DateOfJoining", employee.DateOfJoining);
                    command.Parameters.AddWithValue("@Email", employee.Email);
                    command.Parameters.AddWithValue("@Designation", employee.Designation);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteEmployee(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("delete from employeeSkills where employeeId=@Id; DELETE FROM Employees WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
