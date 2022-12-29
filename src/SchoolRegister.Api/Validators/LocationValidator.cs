namespace SchoolRegister.Api.Validators;

public class LocationSchoolValidator : AbstractValidator<Location>
{
    public LocationSchoolValidator()
    {
        RuleFor(ls => ls.Id).NotNull();

        RuleFor(ls => ls.Country)
            .Cascade(RuleLevelCascadeMode)
            .NotNull().WithMessage("{PropertyName} is Empty")
            .Length(4, 56).WithMessage(
                "Length ({TotalLength}) of {PropertyName} Invalid. Should be between 4 (shortest e.g. Chad) and 56 (longest e.g. UK...)");

        RuleFor(ls => ls.City)
            .NotNull().WithMessage("{PropertyName} is Empty")
            .Length(2, 126);
        
        RuleFor(ls => ls.Cap)
            .NotNull().WithMessage("{PropertyName} is Empty")
            .Length(5).When(ls => ls.Country.Equals(""));
        
    }
}
