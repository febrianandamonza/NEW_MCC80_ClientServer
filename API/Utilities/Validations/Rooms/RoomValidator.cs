using API.DTOs.Rooms;
using FluentValidation;

namespace API.Utilities.Validations.Rooms;

public class RoomValidator : AbstractValidator<RoomDto>
{
    public RoomValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty().WithMessage("Name is required");
        RuleFor(r => r.Floor)
            .NotEmpty().WithMessage("Floor is required");
        RuleFor(r => r.Capacity)
            .NotEmpty().WithMessage("Capacity is required");
    }
}