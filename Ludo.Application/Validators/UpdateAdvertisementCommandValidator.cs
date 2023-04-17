using FluentValidation;
using Ludo.Application.Commands.UpdateAdvertisement;

namespace Ludo.Application.Validators
{
    public class UpdateAdvertisementCommandValidator : AbstractValidator<UpdateAdvertisementCommand>
    {
        public UpdateAdvertisementCommandValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .NotNull()
                .MinimumLength(10)
                .MaximumLength(200)
                .WithMessage("Invalid number of characters");

            RuleFor(p => p.Description)
                .NotEmpty()
                .NotNull()
                .MinimumLength(30)
                .MaximumLength(500)
                .WithMessage("Invalid number of characters");

            RuleFor(p => p.TotalCost)
                .NotEmpty()
                .NotNull()
                .GreaterThan(1)
                .WithMessage("Put a valid price");
        }
    }
}
