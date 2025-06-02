using Microsoft.AspNetCore.Mvc;
using EmpSkills.Models;
using EmpSkills.Data;
using Microsoft.AspNetCore.Authorization;

namespace EmpSkills.Controllers
{
    [ApiController]

    [Route("api/[controller]")]
    public class EmployeeSkillController : ControllerBase
    {
        private readonly EmployeeSkillRepository _repository;

        public EmployeeSkillController(EmployeeSkillRepository repository)
        {
            _repository = repository;
        }


        [HttpGet("{id}")]
        public IActionResult GetSkillsdByEmpId(int id)
        {
            var employeeSkills = _repository.GetEmployeeSkills(id);
            return Ok(employeeSkills);
        }

        [HttpPost]
        public IActionResult AddEmployeeSkill([FromBody] EmployeeSkill skill)
        {
            if (skill == null || skill.EmployeeId <= 0 || skill.SkillId <= 0)
                return BadRequest("Invalid data");

            _repository.AddEmployeeSkill(skill);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteEmployeeSkill([FromQuery] int employeeId, [FromQuery] int skillId)
        {
            if (employeeId <= 0 || skillId <= 0)
                return BadRequest("Invalid IDs");

            _repository.DeleteEmployeeSkill(employeeId, skillId);
            return NoContent();
        }
    }
}
