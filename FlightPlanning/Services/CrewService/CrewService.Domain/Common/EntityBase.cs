using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CrewService.Domain.Common
{
    public class EntityBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        [BsonElement("IsActive")]
        public bool IsActive { get; set; }

        [BsonElement("CreateTime")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreateTime { get; set; }

        [BsonElement("UpdateTime")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? UpdateTime { get; set; }
    }
}