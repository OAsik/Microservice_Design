using Pilot.Domain.Common;

namespace Pilot.Domain.Entities
{
    public class Pilot : EntityBase
    {
        public string EmployeeNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsCaptain { get; set; }

        public bool HasSchedule { get; set; }
    }
}