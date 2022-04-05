using FluentValidation;

namespace Pilot.Application.Features.Commands.UpdatePilot
{
    public class UpdatePilotCommandValidator : AbstractValidator<UpdatePilotCommand>
    {
        public UpdatePilotCommandValidator()
        {
            RuleFor(x => x.EmployeeNumber).NotEmpty().WithMessage("Please enter a valid {EmployeeNumber}").NotNull().WithMessage("{EmployeeNumber} is required");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("{FirstName} is required").MinimumLength(2).WithMessage("Please enter a valid {FirstName}");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("{LastName} is required").MinimumLength(2).WithMessage("Please enter a valid {LastName}");
        }
    }
}