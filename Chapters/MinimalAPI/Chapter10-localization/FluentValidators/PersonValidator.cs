

using Chapter10_localization.LocalizationResources;

namespace Chapter10_localization.FluentValidators;
using FluentValidation;

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(p => p.FirstName).NotEmpty().
            WithMessage(Messages.NotEmptyMessage).
            WithName(Messages.FirstName)
            .MaximumLength(30);

        RuleFor(p => p.LastName).NotEmpty().
            MaximumLength(30);
        RuleFor(p => p.Email).EmailAddress().Length(6,
            100);
    }
}
