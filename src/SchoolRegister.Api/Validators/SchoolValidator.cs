namespace SchoolRegister.Api.Validators;

public class SchoolValidator : AbstractValidator<School>
{
    public SchoolValidator()
    {
        RuleFor(ls => ls.Id).NotNull();

        RuleFor(ls => ls.DateOfConstruction)
            .NotNull();
    }
}
