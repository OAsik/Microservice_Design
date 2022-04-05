using System;

namespace Pilot.Domain.Common
{
    public class EntityBase
    {
        public int Id { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }
    }
}