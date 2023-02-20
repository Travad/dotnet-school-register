using Microsoft.EntityFrameworkCore.Infrastructure;
using SchoolRegister.Api.Entities;

namespace SchoolRegister.Api.Validators;

public class SchoolValidator : AbstractValidator<School>
{
    public SchoolValidator()
    {
        RuleFor(ls => ls.Id)
            .NotNull();
        
        RuleFor(ls => ls.Name)
            .NotNull().WithMessage("Name field is required")
            .NotEmpty().WithMessage("Name field is required")
            .MinimumLength(1).WithMessage("Name cannot be shorter than 1 character")
            .MaximumLength(100).WithMessage("Name cannot be longer than 100 characters");
        
        RuleFor(ls => ls.DateOfConstruction)
            .NotNull();
    }
}
