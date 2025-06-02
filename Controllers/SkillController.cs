using Microsoft.AspNetCore.Mvc;
using EmpSkills.Models;
using EmpSkills.Data;
using Microsoft.AspNetCore.Authorization;

namespace EmpSkills.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SkillController : ControllerBase
    {
        private readonly SkillRepository _repository;

        public SkillController(SkillRepository repository)
        {
            _repository = repository;
        }

        
        [HttpGet]
        public IActionResult GetAllSkills()
        {
            var skills = _repository.GetAllSkills();
            return Ok(skills);
        }

        [HttpPost]
        public IActionResult AddSkill([FromBody] Skill skill)
        {
            if (skill == null || string.IsNullOrWhiteSpace(skill.Name))
                return BadRequest("Invalid skill.");

            _repository.AddSkill(skill);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSkill(int id)
        {
            _repository.DeleteSkill(id);
            return NoContent();
        }
    }
}
