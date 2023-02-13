using FluentValidation;
using Ludo.Application.Commands.CreateUser;
using System.Text.RegularExpressions;

namespace Ludo.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty()
                .NotNull()
                .WithMessage("First name cannot be empty");

            RuleFor(p => p.LastName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Last name cannot be null");

            RuleFor(p => p.Email)
                .EmailAddress()
                .WithMessage("Invalid password");

            RuleFor(p => p.Password)
                .Must(ValidPassword)
                .WithMessage("Password must contain at least 8 characteres, 1 number, 1 upper-cased letter, 1 lower-cased letter and a special character");
        }

        public static bool ValidPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

            return regex.IsMatch(password);

        }
    }
}
