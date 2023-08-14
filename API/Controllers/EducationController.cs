using System.Net;
using API.Contracts;
using API.DTOs.Bookings;
using API.DTOs.Educations;
using API.Models;
using API.Services;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/educations")]
[Authorize(Roles = "Employee")]
public class EducationController : ControllerBase
{
    private readonly EducationService _educationService;

    public EducationController(EducationService educationService)
    {
        _educationService = educationService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _educationService.GetAll();
        if (!result.Any())
        {
            return NotFound(new ResponseHandler<EducationDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data is not found"
            });
        }

        return Ok(new ResponseHandler<IEnumerable<EducationDto>>
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
        var result = _educationService.GetByGuid(guid);
        if (result is null)
        {
            return NotFound(new ResponseHandler<BookingDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Guid is not found"
            });
        }

        return Ok(new ResponseHandler<EducationDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success retrieve data",
            Data = result
        });
    }

    [HttpPost]
    public IActionResult Insert(NewEducationDto newEducationDto)
    {
        var result = _educationService.Create(newEducationDto);
        if (result is null)
        {
            return StatusCode(500,new ResponseHandler<EducationDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Error retrieve from database"
            });
        }

        return Ok(new ResponseHandler<EducationDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success retrieve data",
            Data = result
        });
    }

    [HttpPut]
    public IActionResult Update(EducationDto educationDto)
    {
        var result = _educationService.Update(educationDto);
        if (result is -1)
        {
            return NotFound(new ResponseHandler<BookingDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Guid is not found"
            });
        }
        if (result is 0)
        {
            return StatusCode(500,new ResponseHandler<EducationDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Error retrieve from database"
            });
        }
        return Ok(new ResponseHandler<EducationDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Update Success"
        });
    }

    [HttpDelete]
    public IActionResult Delete(Guid guid)
    {
        var result = _educationService.Delete(guid);
        if (result is -1)
        {
            return NotFound(new ResponseHandler<BookingDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Guid is not found"
            });
        }
        if (result is 0)
        {
            return StatusCode(500,new ResponseHandler<EducationDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Error retrieve from database"
            });
        }
        return Ok(new ResponseHandler<EducationDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Delete Success"
        });
    }
}