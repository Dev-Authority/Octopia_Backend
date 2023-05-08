using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Marketplaces.Entites
{
    [BsonIgnoreExtraElements]
    public class MarketplaceEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string? Name { get; set; }

        [BsonElement("Slogan")]
        public string? Slogan { get; set; }

        [BsonElement("Logo")]
        public string? Logo { get; set; }

        [BsonElement("Link")]
        public string? Link { get; set; }

        [BsonElement("Description")]
        public string? Description { get; set; }

        [BsonElement("Features")]
        public string[]? Features { get; set; }

        [BsonElement("status")]
        public string? status { get; set; }

        [BsonElement("isFavorite")]
        public bool isFavorite { get; set; }

        [BsonElement("Score")]
        public double Score { get; set; }

    }
}
