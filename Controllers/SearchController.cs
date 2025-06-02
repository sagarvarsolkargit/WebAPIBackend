using EmpSkills.Data;
using EmpSkills.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc; 
 
[ApiController]
[Route("api/[controller]")]

public class SearchController : ControllerBase
{
      private readonly SearchRepository _repository;

        public SearchController(SearchRepository repository)
        {
            _repository = repository;
        }

     [HttpPost("")]
    public async Task<IActionResult> SearchEmployees([FromBody] EmployeeSearchRequest request)
    {
        var employees = await _repository.SearchEmployeesAsync(request);
        return Ok(employees);
    }
}
