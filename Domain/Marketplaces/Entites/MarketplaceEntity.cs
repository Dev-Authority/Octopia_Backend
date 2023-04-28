using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Marketplaces.Entites
{
    [BsonIgnoreExtraElements]
    public class MarketplaceEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("Slogan")]
        public string Slogan { get; set; } = string.Empty;

        [BsonElement("Logo")]
        public string Logo { get; set; } = string.Empty;

        [BsonElement("Link")]
        public string Link { get; set; } = string.Empty;

        [BsonElement("Description")]
        public string Description { get; set; } = string.Empty;

        [BsonElement("Features")]
        public List<string> Features { get; set; }

        [BsonElement("isFavorite")]
        public bool isFavorite { get; set; }

        [BsonElement("Score")]
        public int Score { get; set; }

    }
}
