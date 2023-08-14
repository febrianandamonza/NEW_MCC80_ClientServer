using API.DTOs.Universities;
using FluentValidation;

namespace API.Utilities.Validations.Universities;

public class UniversityValidator : AbstractValidator<UniversityDto>
{
    public UniversityValidator()
    {
        RuleFor(u => u.Name)
            .NotEmpty();
        RuleFor(u => u.Code)
            .NotEmpty();
    }
}