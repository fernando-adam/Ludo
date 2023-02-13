using FluentValidation;
using Ludo.Application.Commands.UpdateGameCommand;

namespace Ludo.Application.Validators
{
    public class UpdateGameCommandValidator : AbstractValidator<UpdateGameCommand>
    {
        public UpdateGameCommandValidator() 
        { 
            RuleFor(p => p.Title)
                .MinimumLength(2)
                .MaximumLength(50)
                .WithMessage("Invalid number of characteres");


            RuleFor(p => p.Description)
                .MinimumLength(5)
                .MaximumLength(200)
                .WithMessage("Invalid number of characteres");

        }
    }
}
