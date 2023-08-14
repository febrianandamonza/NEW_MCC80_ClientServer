using API.Contracts;
using API.DTOs.Accounts;
using FluentValidation;

namespace API.Utilities.Validations.Accounts;

public class RegisterValidator : AbstractValidator<RegisterDto>
{
    private readonly IAccountRepository _accountRepository;
    public RegisterValidator(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
        RuleFor(e => e.FirstName)
            .NotEmpty().WithMessage("First Name is required");
         
        RuleFor(e => e.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is mot valid")
            .Must(IsDuplicateValue).WithMessage("Email already exist");
        
        RuleFor(e => e.BirthDate)
            .NotEmpty().WithMessage("Birth Date is required")
            .LessThanOrEqualTo(DateTime.Now.AddYears(-10));
        RuleFor(e => e.PhoneNumber)
            .NotEmpty().WithMessage("Phone Number is required")
            .MaximumLength(20)
            .Matches(@"^\+[0-9]")
            .Must(IsDuplicateValue).WithMessage("Phone Number already exist");
        
        RuleFor(e => e.Gender)
            .NotNull()
            .IsInEnum();
        
        RuleFor(e => e.HiringDate)
            .NotEmpty().WithMessage("Hiring Date is required");
        
        RuleFor(ed => ed.Major)
            .NotEmpty().WithMessage("Major is required");
        
        RuleFor(ed => ed.Degree)
            .NotEmpty().WithMessage("Degree is required");
        
        RuleFor(ed => ed.Gpa)
            .NotEmpty().WithMessage("Gpa is required");
        
        RuleFor(ed => ed.UniversityCode)
            .NotEmpty().WithMessage("University Code is required");
        
        RuleFor(u => u.UniversityName)
            .NotEmpty().WithMessage("Name is required");
        
        RuleFor(a => a.Password)
            .NotEmpty().WithMessage("Password is required")
            .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^a-zA-Z\\d]).{8,}$");
        
        RuleFor(a => a.ConfirmPassword)
            .Equal(ab => ab.Password)
            .WithMessage("Passwords do not match");
    }

    private bool IsDuplicateValue(string arg)
    {
        return _accountRepository.isNotExist(arg);
    }
}
