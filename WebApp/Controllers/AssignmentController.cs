using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NewApiapp.Models;

namespace NewApiapp.Controllers;

[ApiController]
[Route("[controller]")]
public class AssignmentController : ControllerBase
{
    private readonly ILogger<AssignmentController> _logger;

    public AssignmentController(ILogger<AssignmentController> logger)
    {
        _logger = logger;
    }
    private static string Check(int num)
    {
        if (num % 3 == 0)
        {
            if (num % 5 == 0)
            {
                return "Walkkers Assessment";
            }
            else
            {
                return "Walkers";
            }
        }
        else if (num % 5 == 0)
        {
            return "Assessment";
        }
        return "Condition not met";
    }
    [HttpGet("api/{id}")]
    public IActionResult Index(int id)
    {
        if(id <= 20)
        {
            var result = new Assignment();
            result.Title = Check(id);
            result.Number = id;
            result.Date = DateTime.Now;
            return Ok(result);
        }
        return Ok("Given number is greater than 20");
    }
}
