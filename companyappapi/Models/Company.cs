using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace companyappapi.Models
{
    public class Company
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string CompanyName { get; set; }

        public string Cnpj{ get; set; }

        public string Address { get; set; }
        public string Email { get; set; }

    
    }
}
