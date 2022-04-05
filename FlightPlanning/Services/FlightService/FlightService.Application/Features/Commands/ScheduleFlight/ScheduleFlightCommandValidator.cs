using FluentValidation;

namespace FlightService.Application.Features.Commands.ScheduleFlight
{
    public class ScheduleFlightCommandValidator : AbstractValidator<ScheduleFlightCommand>
    {
        public ScheduleFlightCommandValidator()
        {
            RuleFor(x => x.FlightNumber).NotEmpty().WithMessage("Please enter a valid {FlightNumber}").NotNull().WithMessage("{FlightNumber} is required");
            RuleFor(x => x.CaptainId).NotEmpty().WithMessage("{CaptainId} is required").NotNull().WithMessage("Please enter a valid {CaptainId}");
            RuleFor(x => x.CoPilotId).NotEmpty().WithMessage("{CoPilotId} is required").NotNull().WithMessage("Please enter a valid {CoPilotId}");
            RuleFor(x => x.SeniorCrewId).NotEmpty().WithMessage("{SeniorCrewId} is required").MinimumLength(2).WithMessage("Please enter a valid {SeniorCrewId}");
            RuleFor(x => x.Crew1Id).NotEmpty().WithMessage("{Crew1Id} is required").MinimumLength(2).WithMessage("Please enter a valid {Crew1Id}");
            RuleFor(x => x.Crew2Id).NotEmpty().WithMessage("{Crew2Id} is required").MinimumLength(2).WithMessage("Please enter a valid {Crew2Id}");
            RuleFor(x => x.Crew3Id).NotEmpty().WithMessage("{Crew3Id} is required").MinimumLength(2).WithMessage("Please enter a valid {Crew3Id}");
        }
    }
}