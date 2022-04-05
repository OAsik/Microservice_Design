using System;

namespace Pilot.Application.Features.Models
{
    public class PilotModel
    {
        public string Id { get; set; }

        public string EmployeeNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsCaptain { get; set; }

        public bool IsActive { get; set; }

        public bool HasSchedule { get; set; }
    }
}