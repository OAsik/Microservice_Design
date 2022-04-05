using CrewService.Domain.Common;
using MongoDB.Bson.Serialization.Attributes;

namespace CrewService.Domain.Entities
{
    public class Crew : EntityBase
    {
        [BsonElement("EmployeeNumber")]
        public string EmployeeNumber { get; set; }

        [BsonElement("FirstName")]
        public string FirstName { get; set; }

        [BsonElement("LastName")]
        public string LastName { get; set; }

        [BsonElement("IsSenior")]
        public bool IsSenior { get; set; }

        [BsonElement("HasSchedule")]
        public bool HasSchedule { get; set; }
    }
}