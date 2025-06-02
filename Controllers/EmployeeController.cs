using EmpSkills.Data;
using EmpSkills.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmpSkills.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository _repository;

        public EmployeeController(EmployeeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = _repository.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = _repository.GetEmployeeById(id);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest();

            _repository.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] Employee employee)
        {
            if (employee == null || employee.Id != id)
                return BadRequest();

            var existingEmployee = _repository.GetEmployeeById(id);
            if (existingEmployee == null)
                return NotFound();

            _repository.UpdateEmployee(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var existingEmployee = _repository.GetEmployeeById(id);
            if (existingEmployee == null)
                return NotFound();

            _repository.DeleteEmployee(id);
            return NoContent();
        }
    }
}
