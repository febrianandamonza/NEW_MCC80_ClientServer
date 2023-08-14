using API.DTOs.Rooms;
using FluentValidation;

namespace API.Utilities.Validations.Rooms;

public class NewRoomValidator : AbstractValidator<NewRoomDto>
{
    public NewRoomValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty();
        RuleFor(r => r.Floor)
            .NotEmpty();
        RuleFor(r => r.Capacity)
            .NotEmpty();
    }
}