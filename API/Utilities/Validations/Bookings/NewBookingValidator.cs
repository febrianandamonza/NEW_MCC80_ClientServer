using API.DTOs.Bookings;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Routing;

namespace API.Utilities.Validations.Bookings;

public class NewBookingValidator : AbstractValidator<NewBookingDto>
{
    public NewBookingValidator()
    {
        RuleFor(b => b.StartDate)
            .NotEmpty().WithMessage("Start Date is required");
        RuleFor(b => b.EndDate)
            .NotEmpty().WithMessage("End Date is required");
        RuleFor(b => b.Status)
            .NotNull()
            .IsInEnum();
        RuleFor(b => b.Remarks)
            .NotEmpty().WithMessage("Remarks is required");;
        RuleFor(b => b.EmployeeGuid)
            .NotEmpty().WithMessage("Employee Guid is required");
        RuleFor(b => b.RoomGuid)
            .NotEmpty().WithMessage("Room Guid is required");
    }
}