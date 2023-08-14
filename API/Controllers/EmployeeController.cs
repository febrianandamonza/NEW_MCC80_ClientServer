using System.Net;
using API.Contracts;
using API.DTOs.Educations;
using API.DTOs.Employees;
using API.Models;
using API.Services;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/employees")]
/*[Authorize(Roles = "Employee")]*/
[EnableCors]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeService _employeeService;

    public EmployeeController(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet("CountDetailUniversitas")]
    public IActionResult GetEmployeeUniversitas()
    {
        var result = _employeeService.GetCountEmployeeUniversitas();
        if (!result.Any())
        {
            return NotFound(new ResponseHandler<EmployeeUniversitas>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data is not found"
            });
        }

        return Ok(new ResponseHandler<IEnumerable<EmployeeUniversitas>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success retrieve data",
            Data = result
        });
    }
    
    [HttpGet("count-gender")]
    public IActionResult GetCountGender()
    {
        var result = _employeeService.GetGender();
        if (result is null)
        {
            return NotFound(new ResponseHandler<EmployeeGender>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Cannot Count Gender!"
            });
        }

        return Ok(new ResponseHandler<EmployeeGender>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success retrieve data",
            Data = result
        });
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _employeeService.GetAll().ToList();
        if (!result.Any())
        {
            return NotFound(new ResponseHandler<EmployeeDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data is not found"
            });
        }

        return Ok(new ResponseHandler<IEnumerable<EmployeeDto>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success retrieve data",
            Data = result
        });
    }

    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        var result = _employeeService.GetByGuid(guid);
        if (result is null)
        {
            return NotFound(new ResponseHandler<EmployeeDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Guid is not found"
            });
        }

        return Ok(new ResponseHandler<EmployeeDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success retrieve data",
            Data = result
        });
    }

    [HttpPost]
    public IActionResult Insert(NewEmployeeDto newEmployeeDto)
    {
        var result = _employeeService.Create(newEmployeeDto);
        if (result is null)
        {
            return StatusCode(500,new ResponseHandler<EmployeeDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Error retrieve from database"
            });
        }

        return Ok(new ResponseHandler<EmployeeDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success retrieve data",
            Data = result
        });
    }

    [HttpPut]
    public IActionResult Update(EmployeeDto employeeDto)
    {
        var result = _employeeService.Update(employeeDto);
        if (result is -1)
        {
            return NotFound(new ResponseHandler<EmployeeDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Guid is not found"
            });
        }
        if (result is 0)
        {
            return StatusCode(500,new ResponseHandler<EmployeeDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Error retrieve from database"
            });
        }
        
        return Ok(new ResponseHandler<EmployeeDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Update success"
        });
    }

    [HttpDelete]
    public IActionResult Delete(Guid guid)
    {
        var result = _employeeService.Delete(guid);
        if (result is -1)
        {
            return NotFound(new ResponseHandler<EmployeeDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Guid is not found"
            });
        }
        if (result is 0)
        {
            return StatusCode(500,new ResponseHandler<EmployeeDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Error retrieve from database"
            });
        }
        
        return Ok(new ResponseHandler<EmployeeDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Delete success"
        });
    }

    [HttpGet("employees-detail")]
    public IActionResult GetAllEmployeeDetail()
    {
        var result = _employeeService.GetAllEmployeeDetail();
        if (!result.Any())
        {
            return NotFound(new ResponseHandler<EmployeeDetailDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data is not found"
            });
        }

        return Ok(new ResponseHandler<IEnumerable<EmployeeDetailDto>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success retrieve data",
            Data = result
        });
    }
    
    [HttpGet("employees-detail/{guid}")]
    public IActionResult GetEmployeeDetailByGuid(Guid guid)
    {
        var result = _employeeService.GetEmployeeDetailByGuid(guid);
        if (result is null)
        {
            return NotFound(new ResponseHandler<EmployeeDetailDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Guid is not found"
            });
        }

        return Ok(new ResponseHandler<EmployeeDetailDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success retrieve data",
            Data = result
        });
    }
    
}