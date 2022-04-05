using System.Collections.Generic;

namespace EventBus.Messages.Events
{
    public class CrewCheckoutEvent : IntegrationBaseEvent
    {
        public List<string> EmployeeNumbers { get; set; }

        public bool HasSchedule { get; set; }
    }
}