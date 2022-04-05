using FluentValidation;

namespace FlightService.Application.Features.Commands.DeleteFlight
{
    public class DeleteFlightCommandValidator : AbstractValidator<DeleteFlightCommand>
    {
        public DeleteFlightCommandValidator()
        {
            RuleFor(x => x.FlightNumber).NotEmpty().WithMessage("Please enter a valid {FlightNumber}").NotNull().WithMessage("{FlightNumber} is required");
        }
    }
}