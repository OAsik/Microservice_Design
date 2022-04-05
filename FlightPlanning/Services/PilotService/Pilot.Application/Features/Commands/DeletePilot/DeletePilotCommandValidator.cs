using FluentValidation;

namespace Pilot.Application.Features.Commands.DeletePilot
{
    public class DeletePilotCommandValidator : AbstractValidator<DeletePilotCommand>
    {
        public DeletePilotCommandValidator()
        {
            RuleFor(x => x.EmployeeNumber).NotEmpty().WithMessage("Please enter a valid {EmployeeNumber}").NotNull().WithMessage("{EmployeeNumber} is required");
        }
    }
}