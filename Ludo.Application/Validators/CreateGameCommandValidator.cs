using FluentValidation;
using Ludo.Application.Commands.CreateGameCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Application.Validators
{
    public class CreateGameCommandValidator : AbstractValidator<CreateGameCommand>
    {
        public CreateGameCommandValidator() 
        { 
            RuleFor(p => p.MinimumNumberOfPlayers)
                .GreaterThan(1)
                .WithMessage("You must add number of players");


            RuleFor(p => p.Title)
                .MinimumLength(2)
                .MaximumLength(50)
                .WithMessage("Invalid number of characteres");

            RuleFor(p => p.Description)
                .MinimumLength(5)
                .MaximumLength(200)
                .WithMessage("Invalid number of characteres");

            RuleFor(p => p.Age)
                .NotEmpty()
                .WithMessage("You must define an minimum age");

            RuleFor(p => p.Publisher)
                .NotEmpty()
                .WithMessage("You must define a publisher");

            RuleFor(p => p.Category)
                .NotEmpty()
                .WithMessage("You must define a category");

            RuleFor(p => p.MinimumNumberOfPlayers)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Invalid age");
        }
    }
}
