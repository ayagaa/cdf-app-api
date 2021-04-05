using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDF.API.Models
{
    public class Sibling
    {
        [BsonElement("id")]
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [BsonElement("name")]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [BsonElement("institutionType")]
        [JsonProperty(PropertyName = "institutionType")]
        public string InstitutionType { get; set; }

        [BsonElement("institutionName")]
        [JsonProperty(PropertyName = "institutionName")]
        public string InstitutionName { get; set; }

        [BsonElement("feesPayable")]
        [JsonProperty(PropertyName = "feesPayable")]
        public double FeesPayable { get; set; }
    }
}
