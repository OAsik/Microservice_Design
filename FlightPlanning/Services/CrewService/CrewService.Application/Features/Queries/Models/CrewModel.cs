using System;

namespace CrewService.Application.Features.Queries.Models
{
    public class CrewModel
    {
        public string Id { get; set; }

        public string EmployeeNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsSenior { get; set; }

        public bool IsActive { get; set; }

        public bool HasSchedule { get; set; }
    }
}