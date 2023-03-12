using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test1.DTO;
using Test1.Model;
using Test1.Services;

namespace Test1.Controllers
{
    [Route("decagon/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo _employeeRepo;

        public EmployeeController(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> AddEmployee(EmployeeDto employee)
        {
            var data = await _employeeRepo.AddEmployee(employee);

            return data? Ok("successful") : BadRequest("Unsuccessful");
        }

        [HttpGet("get-all-employees")]
        public async Task<List<EmployeeID>> GetAllEmployees()
        {
            var data = await _employeeRepo.GetAll();

            return data;
        }

        [HttpGet("get-employee")]
        public async Task<IActionResult> GetEmployee(string Id)
        {
            var data = await _employeeRepo.GetEmployee(Id);

            return data != null? Ok(data) : BadRequest("Not Found");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateEmployee(EmployeeID employee)
        {
            var data = await _employeeRepo.Update(employee);

            return data != null? Ok(data) : BadRequest("Unsuccessful");
        }

        [HttpDelete("delete-employees")]
        public async Task<IActionResult> DeleteEmployee(string Id)
        {
            var data = await _employeeRepo.Delete(Id);

            return data? Ok("Successful") : StatusCode(404);
        }
    }
}
