using FluentValidation;

namespace CrewService.Application.Features.Commands.DeleteCrew
{
    public class DeleteCrewCommandValidator : AbstractValidator<DeleteCrewCommand>
    {
        public DeleteCrewCommandValidator()
        {
            RuleFor(x => x.ID).NotEmpty().WithMessage("Please enter a valid {EmployeeNumber}").NotNull().WithMessage("{EmployeeNumber} is required");
        }
    }
}