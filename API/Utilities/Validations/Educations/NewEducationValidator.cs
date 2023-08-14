using API.DTOs.Educations;
using FluentValidation;

namespace API.Utilities.Validations.Educations;

public class NewEducationValidator : AbstractValidator<NewEducationDto>
{
    public NewEducationValidator()
    {
        RuleFor(ed => ed.Major)
            .NotEmpty().WithMessage("Major is required");
        RuleFor(ed => ed.Degree)
            .NotEmpty().WithMessage("Degree is required");
        RuleFor(ed => ed.Gpa)
            .NotEmpty().WithMessage("Gpa is required");
        RuleFor(ed => ed.UniversityGuid)
            .NotEmpty().WithMessage("University Guid is required");
    }
}