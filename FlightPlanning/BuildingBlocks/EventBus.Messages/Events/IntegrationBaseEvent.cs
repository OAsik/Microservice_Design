using System;

namespace EventBus.Messages.Events
{
    public class IntegrationBaseEvent
    {
        public Guid Id { get; private set; }

        public DateTime CreateTime { get; private set; }

        public IntegrationBaseEvent(Guid id, DateTime createTime)
        {
            Id = id;
            CreateTime = createTime;
        }

        public IntegrationBaseEvent()
        {
            Id = Guid.NewGuid();
            CreateTime = DateTime.Now;
        }
    }
}