using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace YoutTubeWrapper.Models
{
    public class YoutubeSchema
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string VideoId { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public string thumbnailUrl { get; set; }

        public string channelTitle { get; set; }
        public string publishedAt { get; set; }
    }
}
