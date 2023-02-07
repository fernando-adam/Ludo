using FluentValidation;
using Ludo.Application.Commands.AddAdvertisement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Application.Validators
{
    public class CreateAdvertisementCommandValidator : AbstractValidator<AddAdvertisementCommand>
    {
        public CreateAdvertisementCommandValidator() 
        {
            RuleFor(p => p.Title)
                .MinimumLength(10)
                .MaximumLength(200)
                .WithMessage("Invalid number of characters");

            RuleFor(p => p.Description)
                .MinimumLength(40)
                .MaximumLength(500)
                .WithMessage("Invalid number of characters");

            RuleFor(p => p.TotalCost)
                .NotNull()
                .GreaterThan(1)
                .WithMessage("Put a valid price");
                
        }
    }
}
