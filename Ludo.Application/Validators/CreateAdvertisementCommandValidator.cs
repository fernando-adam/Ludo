﻿using FluentValidation;
using Ludo.Application.Commands.AddAdvertisement;

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
                .MinimumLength(30)
                .MaximumLength(500)
                .WithMessage("Invalid number of characters");

            RuleFor(p => p.TotalCost)
                .NotNull()
                .GreaterThan(1)
                .WithMessage("Put a valid price");
                
        }
    }
}
