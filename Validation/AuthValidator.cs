using FluentValidation;
using Vns.Model.StudentModel;

namespace Vns.Validation
{
    public class AuthValidator : AbstractValidator<Student>
    {
        public AuthValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Password).MaximumLength(7);
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
