using System.Security.Claims;
using System.Security.Principal;
using API.Contracts;
using API.Data;
using API.DTOs.AccountRoles;
using API.DTOs.Accounts;
using API.Models;
using API.Utilities.Handlers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Services;

public class AccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUniversityRepository _universityRepository;
    private readonly IEducationRepository _educationRepository;
    private readonly IAccountRoleRepository _accountRoleRepository;
    private readonly IEmailHandler _emailHandler;
    private readonly ITokenHandler _tokenHandler;
    private readonly BookingDbContext _dbContext;
    

    public AccountService(IAccountRepository accountRepository, IEmployeeRepository employeeRepository, IEducationRepository educationRepository, IUniversityRepository universityRepository, BookingDbContext dbContext, IEmailHandler emailHandler, ITokenHandler tokenHandler, IAccountRoleRepository accountRoleRepository)
    {
        _accountRepository = accountRepository;
        _employeeRepository = employeeRepository;
        _educationRepository = educationRepository;
        _universityRepository = universityRepository;
        _dbContext = dbContext;
        _emailHandler = emailHandler;
        _tokenHandler = tokenHandler;
        _accountRoleRepository = accountRoleRepository;
    }

    public IEnumerable<AccountDto> GetAll()
    {
        var accounts = _accountRepository.GetAll();
        if (!accounts.Any())
        {
            return Enumerable.Empty<AccountDto>();
        }

        var accountDtos = new List<AccountDto>();
        foreach (var account in accounts)
        {
            accountDtos.Add((AccountDto)account);
        }

        return accountDtos;
    }

    public AccountDto? GetByGuid(Guid guid)
    {
        var account = _accountRepository.GetByGuid(guid);
        if (account is null)
        {
            return null;
        }

        return ((AccountDto)account);
    }

    public AccountDto? Create(NewAccountDto newAccountDto)
    {
        var account = _accountRepository.Create(newAccountDto);
        if (account is null)
        {
            return null;
        }

        return ((AccountDto)account);
    }

    public int Update(AccountDto accountDto)
    {
        var account = _accountRepository.GetByGuid(accountDto.Guid);
        if (account is null)
        {
            return -1;
        }

        Account toUpdate = accountDto;
        toUpdate.CreatedDate = account.CreatedDate;
        var result = _accountRepository.Update(toUpdate);
        return result ? 1 
            : 0;

    }

    public int Delete(Guid guid)
    {
        var account = _accountRepository.GetByGuid(guid);
        if (account is null)
        {
            return -1;
        }

        var result = _accountRepository.Delete(account);
        return result ? 1 
            : 0;
    }

    public string Login(LoginDto loginDto)
    {
        var getEmployee = _employeeRepository.GetByEmail(loginDto.Email);
        if (getEmployee is null)
        {
            return "0";
        }

        var getAccount = _accountRepository.GetByGuid(getEmployee.Guid);
        var handlerPassword = HashingHandler.ValidateHash(loginDto.Password, getAccount.Password);
        if (!handlerPassword)
        {
            return "0";
        }
        
        var claims = new List<Claim>
        {
            new Claim("Guid", getEmployee.Guid.ToString()),
            new Claim("FullName", $"{getEmployee.FirstName} {getEmployee.LastName}"),
            new Claim("Email", getEmployee.Email)
        };

        var employee = _employeeRepository.GetByEmail(loginDto.Email);
        var getRoles = _accountRoleRepository.GetRoleNamesByAccountGuid(employee.Guid);

        foreach (var getRole in getRoles)
        {
            claims.Add(new Claim(ClaimTypes.Role, getRole));
        }

        var generatedToken = _tokenHandler.GenerateToken(claims);
        if (generatedToken is null)
        {
            return "-1";
        }
        return generatedToken;
    }
    public RegisterDto? Register(RegisterDto registerDto)
    {
        using var transaction = _dbContext.Database.BeginTransaction();
        try
        {
            var checkExist = _universityRepository.isExist(registerDto.UniversityCode);
            if (checkExist is null)
            {
                University university = new University
                {
                    Guid = new Guid(),
                    Code = registerDto.UniversityCode,
                    Name = registerDto.UniversityName,
                };
                var createdUniversity = _universityRepository.Create(university);
                if (createdUniversity is null)
                {
                    return null;
                }

                checkExist = university;
            }

            var employee = _employeeRepository.Create(new Employee
            {
                Guid = new Guid(),
                Nik = GenerateHandler.Nik(_employeeRepository.Getlastnik()),
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                PhoneNumber = registerDto.PhoneNumber,
                BirthDate = registerDto.BirthDate,
                HiringDate = registerDto.HiringDate,
                Gender = registerDto.Gender,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            });


            var education = _educationRepository.Create(new Education
            {
                Guid = employee.Guid,
                Degree = registerDto.Degree,
                Major = registerDto.Major,
                Gpa = registerDto.Gpa,
                CreatedDate = employee.CreatedDate,
                ModifiedDate = employee.ModifiedDate,
                UniversityGuid = checkExist.Guid
            });

            
            
            if (registerDto.Password != registerDto.ConfirmPassword)
            {
                return null;
            }
            var account = _accountRepository.Create(new Account
            {
                Guid = employee.Guid,
                Password = HashingHandler.GenerateHash(registerDto.Password),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            });

            var accountRole = _accountRoleRepository.Create(new AccountRoleDto
            {
                AccountGuid = account.Guid,
                RoleGuid = Guid.Parse("8678b323-e9f4-441e-fecc-08db91d599ea")
            });
            
            var toDto = new RegisterDto
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                BirthDate = employee.BirthDate,
                Gender = employee.Gender,
                HiringDate = employee.HiringDate,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                Password = account.Password,
                Major = education.Major,
                Degree = education.Degree,
                Gpa = education.Gpa,
                UniversityCode = checkExist.Code,
                UniversityName = checkExist.Name
            };
            
            transaction.Commit();
            return toDto;
        }
        catch 
        {
            transaction.Rollback();
            return null;
        }
    }

    public int ForgotPassword(ForgotPasswordDto forgotPasswordDto)
    {
        //Mendapatkan Account Detail berdasarkan email
        var getAccountDetail = (from e in _employeeRepository.GetAll()
            join a in _accountRepository.GetAll() on e.Guid equals a.Guid
            where e.Email == forgotPasswordDto.Email
            select a).FirstOrDefault();
        
        _accountRepository.Clear();
        if (getAccountDetail is null)
        {
            return 0;
        }
        
        var otp = new Random().Next(111111, 999999);
        var account = new Account
        {
            Guid = getAccountDetail.Guid,   
            Password = getAccountDetail.Password,
            ExpiredDate = DateTime.Now.AddMinutes(5),
            Otp = otp,
            IsUsed = false,
            CreatedDate = getAccountDetail.CreatedDate,
            ModifiedDate = DateTime.Now
        };

        var isUpdate = _accountRepository.Update(account);

        if (!isUpdate)
        {
            return -1;
        }
        _emailHandler.SendEmail(forgotPasswordDto.Email, "Account - Forgot Password", $"Your otp is {otp}");
        
        return 1;
    }

    public int ChangePassword(ChangePasswordDto changePasswordDto)
    {
        var isExist = _employeeRepository.CheckEmail(changePasswordDto.Email);
        if (isExist is null)
        {
            return -1;
        }

        var getAccount = _accountRepository.GetByGuid(isExist.Guid);
        var account = new Account
        {
            Guid = getAccount.Guid,
            IsUsed = true,
            ModifiedDate = DateTime.Now,
            CreatedDate = getAccount.CreatedDate,
            Otp = getAccount.Otp,
            ExpiredDate = getAccount.ExpiredDate,
            Password = HashingHandler.GenerateHash(changePasswordDto.NewPassword)
        };

        if (getAccount.Otp != changePasswordDto.Otp)
        {
            return -2;
        }

        if (getAccount.IsUsed)
        {
            return -3;
        }

        if (getAccount.ExpiredDate < DateTime.Now)
        {
            return -4;
        }

        var isUpdate = _accountRepository.Update(account);
        if (!isUpdate)
        {
            return -2;
        }
        
        return 1;
    }
}