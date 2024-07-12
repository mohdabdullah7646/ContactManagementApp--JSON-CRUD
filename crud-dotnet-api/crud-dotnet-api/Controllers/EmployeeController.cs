using crud_dotnet_api.Data;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeRepository _employeeRepository;

    public EmployeeController(EmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    [HttpGet]
    public async Task<ActionResult> GetAllEmployees()
    {
        var employees = await _employeeRepository.GetAllEmployeesAsync();
        return Ok(employees);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetEmployeeById(int id)
    {
        var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
        if (employee == null)
        {
            return NotFound();
        }
        return Ok(employee);
    }

    [HttpPost]
    public async Task<ActionResult> AddEmployee([FromBody] Employee employee)
    {
        if (employee == null)
        {
            return BadRequest("Employee is null");
        }

        await _employeeRepository.AddEmployeeAsync(employee);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateEmployee(int id, [FromBody] Employee employee)
    {
        await _employeeRepository.UpdateEmployeeAsync(id, employee);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteEmployee(int id)
    {
        await _employeeRepository.DeleteEmployeeAsync(id);
        return Ok();
    }

    [HttpGet("test-exception")]
    public IActionResult TestException()
    {
        // Simulate an exception
        throw new Exception("Test exception to verify global exception handling.");
    }
}
