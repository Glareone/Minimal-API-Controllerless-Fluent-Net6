using Chapter06_Model_FluentValidation.DTO;
using FluentValidation;

namespace Chapter06_Model_FluentValidation.DTO_Validators;

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(p =>
            p.FirstName).NotEmpty().MaximumLength(30).WithMessage("You must provide the proper name");
        RuleFor(p =>
            p.LastName).NotEmpty().MaximumLength(30);
        RuleFor(p => p.Email).EmailAddress().Length(6,
            100);
    }
}
