using API.Contracts;
using API.DTOs.Employees;
using FluentValidation;

namespace API.Utilities.Validations.Employees;

public class NewEmployeeValidator : AbstractValidator<NewEmployeeDto>
{
    private readonly IEmployeeRepository _employeeRepository;
    public NewEmployeeValidator(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;

        RuleFor(e => e.FirstName)
            .NotEmpty().WithMessage("First Name is required");
        
        RuleFor(e => e.BirthDate)
            .NotEmpty().WithMessage("Birth Date is required")
            .LessThanOrEqualTo(DateTime.Now.AddYears(-10));
        
        RuleFor(e => e.Gender)
            .NotNull()
            .IsInEnum();

        RuleFor(e => e.HiringDate)
            .NotEmpty().WithMessage("Hiring Date is required");
        
        RuleFor(e => e.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is mot valid")
            .Must(IsDuplicateValue).WithMessage("Email already exist");

        RuleFor(e => e.PhoneNumber)
            .NotEmpty().WithMessage("Phone Number is required")
            .MaximumLength(20)
            .Matches(@"^\+[0-9]")
            .Must(IsDuplicateValue).WithMessage("Phone Number alreadt exist");
    }

    private bool IsDuplicateValue(string arg)
    {
        return _employeeRepository.isNotExist(arg);
    }
}