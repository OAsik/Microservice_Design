using FluentValidation;

namespace FlightService.Application.Features.Commands.UpdateFlight
{
    public class UpdateFlightCommandValidator : AbstractValidator<UpdateFlightCommand>
    {
        public UpdateFlightCommandValidator()
        {
            RuleFor(x => x.FlightNumber).NotEmpty().WithMessage("Please enter a valid {FlightNumber}").NotNull().WithMessage("{FlightNumber} is required");
            RuleFor(x => x.Origin).NotEmpty().WithMessage("{Origin} is required").MinimumLength(2).WithMessage("Please enter a valid {Origin}");
            RuleFor(x => x.Destination).NotEmpty().WithMessage("{Destination} is required").MinimumLength(2).WithMessage("Please enter a valid {Destination}");
        }
    }
}