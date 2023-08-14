using API.DTOs.Bookings;
using FluentValidation;

namespace API.Utilities.Validations.Bookings;

public class BookinValidator : AbstractValidator<BookingDto>
{
    public BookinValidator()
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